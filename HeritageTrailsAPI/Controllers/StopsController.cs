using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HeritageTrailsAPI.Models;

namespace HeritageTrailsAPI.Controllers
{
    public class StopsController : ApiController
    {
        private HeritageTrailsAPIContext db = new HeritageTrailsAPIContext();

        // GET: api/Stops
        public IQueryable<Stop> GetStops()
        {
            return db.Stops;
        }

        // GET: api/Stops/5
        [ResponseType(typeof(Stop))]
        public async Task<IHttpActionResult> GetStop(int id)
        {
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return NotFound();
            }

            return Ok(stop);
        }

        // PUT: api/Stops/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStop(int id, Stop stop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stop.StopId)
            {
                return BadRequest();
            }

            db.Entry(stop).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Stops
        [ResponseType(typeof(Stop))]
        public async Task<IHttpActionResult> PostStop(Stop stop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stops.Add(stop);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stop.StopId }, stop);
        }

        // DELETE: api/Stops/5
        [ResponseType(typeof(Stop))]
        public async Task<IHttpActionResult> DeleteStop(int id)
        {
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return NotFound();
            }

            db.Stops.Remove(stop);
            await db.SaveChangesAsync();

            return Ok(stop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StopExists(int id)
        {
            return db.Stops.Count(e => e.StopId == id) > 0;
        }
    }
}