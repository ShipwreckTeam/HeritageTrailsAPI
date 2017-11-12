var ViewModel = function () {

    ///Below code is related to READ and DELETE trail/stop/detailStop data
    var self = this;

    self.trails = ko.observableArray();
    self.stops = ko.observableArray();
    self.error = ko.observable();

    self.trailDetail = ko.observable();
    self.stopDetail = ko.observable();

    var trailsUri = '/api/trails';
    var stopsUri = '/api/stops';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllTrails() {
        ajaxHelper(trailsUri, 'GET').done(function (data) {
            self.trails(data);
        });
    }

    function getAllStops() {
        ajaxHelper(stopsUri, 'GET').done(function (data) {
            self.stops(data);
        });
    }

    self.getTrailDetail = function (item) {
        ajaxHelper(trailsUri + "/" + item.TrailId, 'GET').done(function (data) {
            self.trailDetail(data);
        });
    }

    self.getStopDetail = function (item) {
        ajaxHelper(stopsUri + "/" + item.StopId, 'GET').done(function (data) {
            self.stopDetail(data);
        });
    }

    self.deleteTrail = function (item) {
        if (confirm('Are you sure to Delete "' + item.Name + '" Trail??')) {
            var id = item.TrailId;

            $.ajax({
                url: 'api/Trails/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: id,
                success: function (data) {
                    self.trails.remove(item);
                }
            })
        }
    }

    self.deleteStop = function (item) {
        if (confirm('Are you sure to Delete "' + item.Name + '" Stop??')) {
            var id = item.StopId;

            $.ajax({
                url: 'api/Stops/' + id,
                cache: false,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                data: id,
                success: function (data) {
                    self.stops.remove(item);
                }
            })
        }
    }

    ///Below code is for CREATE trail/stop/detailStop data

    self.newTrail = {
        TrailId: ko.observable(),
        Name: ko.observable(),
        Time: ko.observable(),
        Length: ko.observable(),
        PictureInt: ko.observable()
    }

    self.addTrail = function (formElement) {
        var trail = {
            Name: self.newTrail.Name(),
            Time: self.newTrail.Time(),
            Length: self.newTrail.Length(),
            PictureInt: self.newTrail.PictureInt()
        };

        ajaxHelper(trailsUri, 'POST', trail).done(function (item) {
            self.trails.push(item);
        });
    }


    self.newStop = {
        StopId: ko.observable(),
        TrailId: ko.observable(),
        Name: ko.observable(),
        Built: ko.observable(),
        ShortDesc: ko.observable(),
        Image: ko.observable()
    }

    self.addStop = function (formElement) {
        var stop = {
            StopId: self.newStop.StopId(),
            TrailId: self.newStop.TrailId(),
            Name: self.newStop.Name(),
            Built: self.newStop.Built(),
            ShortDesc: self.newStop.ShortDesc(),
            FullDesc: self.newStop.FullDesc(),
            Location: self.newStop.Location(),
            CoordX: self.newStop.CoordX(),
            CoordY: self.newStop.CoordY(),
            Image: self.newStop.PictureInt()
        };

        ajaxHelper(stopsUri, 'POST', stop).done(function (item) {
            self.stops.push();
        });
    }

    // Fetch the initial data.
    getAllTrails();
    getAllStops();
};

ko.applyBindings(new ViewModel());