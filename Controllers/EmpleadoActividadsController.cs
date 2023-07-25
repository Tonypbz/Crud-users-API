using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PombosaExamen2.Models;

namespace PombosaExamen2.Controllers
{
    public class EmpleadoActividadsController : ApiController
    {
        private PombosaExamenEntities db = new PombosaExamenEntities();

        // GET: api/EmpleadoActividads
        public IQueryable<EmpleadoActividad> GetEmpleadoActividad()
        {
            return db.EmpleadoActividad;
        }

        // GET: api/EmpleadoActividads/5
        [ResponseType(typeof(EmpleadoActividad))]
        public IHttpActionResult GetEmpleadoActividad(int id)
        {
            EmpleadoActividad empleadoActividad = db.EmpleadoActividad.Find(id);
            if (empleadoActividad == null)
            {
                return NotFound();
            }

            return Ok(empleadoActividad);
        }

        // PUT: api/EmpleadoActividads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleadoActividad(int id, EmpleadoActividad empleadoActividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleadoActividad.id)
            {
                return BadRequest();
            }

            db.Entry(empleadoActividad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoActividadExists(id))
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

        // POST: api/EmpleadoActividads
        [ResponseType(typeof(EmpleadoActividad))]
        public IHttpActionResult PostEmpleadoActividad(EmpleadoActividad empleadoActividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpleadoActividad.Add(empleadoActividad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleadoActividad.id }, empleadoActividad);
        }

        // DELETE: api/EmpleadoActividads/5
        [ResponseType(typeof(EmpleadoActividad))]
        public IHttpActionResult DeleteEmpleadoActividad(int id)
        {
            EmpleadoActividad empleadoActividad = db.EmpleadoActividad.Find(id);
            if (empleadoActividad == null)
            {
                return NotFound();
            }

            db.EmpleadoActividad.Remove(empleadoActividad);
            db.SaveChanges();

            return Ok(empleadoActividad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoActividadExists(int id)
        {
            return db.EmpleadoActividad.Count(e => e.id == id) > 0;
        }
    }
}