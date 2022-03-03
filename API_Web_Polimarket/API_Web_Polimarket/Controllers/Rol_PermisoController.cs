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
    public class Rol_PermisoController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/Rol_Permiso
        public IQueryable<Rol_Permiso> GetRol_Permiso()
        {
            return db.Rol_Permiso;
        }

        // GET: api/Rol_Permiso/5
        [ResponseType(typeof(Rol_Permiso))]
        public IHttpActionResult GetRol_Permiso(int id)
        {
            Rol_Permiso rol_Permiso = db.Rol_Permiso.Find(id);
            if (rol_Permiso == null)
            {
                return NotFound();
            }

            return Ok(rol_Permiso);
        }

        // PUT: api/Rol_Permiso/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRol_Permiso(int id, Rol_Permiso rol_Permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rol_Permiso.idRolPermiso)
            {
                return BadRequest();
            }

            db.Entry(rol_Permiso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rol_PermisoExists(id))
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

        // POST: api/Rol_Permiso
        [ResponseType(typeof(Rol_Permiso))]
        public IHttpActionResult PostRol_Permiso(Rol_Permiso rol_Permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rol_Permiso.Add(rol_Permiso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rol_Permiso.idRolPermiso }, rol_Permiso);
        }

        // DELETE: api/Rol_Permiso/5
        [ResponseType(typeof(Rol_Permiso))]
        public IHttpActionResult DeleteRol_Permiso(int id)
        {
            Rol_Permiso rol_Permiso = db.Rol_Permiso.Find(id);
            if (rol_Permiso == null)
            {
                return NotFound();
            }

            db.Rol_Permiso.Remove(rol_Permiso);
            db.SaveChanges();

            return Ok(rol_Permiso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Rol_PermisoExists(int id)
        {
            return db.Rol_Permiso.Count(e => e.idRolPermiso == id) > 0;
        }
    }
}