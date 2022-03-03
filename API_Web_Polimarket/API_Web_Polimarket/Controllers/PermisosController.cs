using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API_Web_Polimarket.Models;

namespace API_Web_Polimarket.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PermisosController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/Permisos
        public IQueryable<Permiso> GetPermisoes()
        {
            return db.Permisoes;
        }

        // GET: api/Permisos/5
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult GetPermiso(int id)
        {
            Permiso permiso = db.Permisoes.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(permiso);
        }

        // PUT: api/Permisos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermiso(int id, Permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permiso.idPermiso)
            {
                return BadRequest();
            }

            db.Entry(permiso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisoExists(id))
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

        // POST: api/Permisos
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult PostPermiso(Permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Permisoes.Add(permiso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permiso.idPermiso }, permiso);
        }

        // DELETE: api/Permisos/5
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult DeletePermiso(int id)
        {
            Permiso permiso = db.Permisoes.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            db.Permisoes.Remove(permiso);
            db.SaveChanges();

            return Ok(permiso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermisoExists(int id)
        {
            return db.Permisoes.Count(e => e.idPermiso == id) > 0;
        }
    }
}