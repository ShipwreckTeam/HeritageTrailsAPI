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
    public class TrailsController : ApiController
    {
        private HeritageTrailsAPIContext db = new HeritageTrailsAPIContext();

        // GET: api/Trails
        public IQueryable<Trail> GetTrails()
        {
            return db.Trails;
        }

        // GET: api/Trails/5
        [ResponseType(typeof(Trail))]
        public async Task<IHttpActionResult> GetTrail(int id)
        {
            Trail trail = await db.Trails.FindAsync(id);
            if (trail == null)
            {
                return NotFound();
            }

            return Ok(trail);
        }

        // PUT: api/Trails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrail(int id, Trail trail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trail.TrailId)
            {
                return BadRequest();
            }

            db.Entry(trail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailExists(id))
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

        // POST: api/Trails
        [ResponseType(typeof(Trail))]
        public async Task<IHttpActionResult> PostTrail(Trail trail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trails.Add(trail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trail.TrailId }, trail);
        }

        // DELETE: api/Trails/5
        [ResponseType(typeof(Trail))]
        public async Task<IHttpActionResult> DeleteTrail(int id)
        {
            Trail trail = await db.Trails.FindAsync(id);
            if (trail == null)
            {
                return NotFound();
            }

            db.Trails.Remove(trail);
            await db.SaveChangesAsync();

            return Ok(trail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrailExists(int id)
        {
            return db.Trails.Count(e => e.TrailId == id) > 0;
        }
    }
}