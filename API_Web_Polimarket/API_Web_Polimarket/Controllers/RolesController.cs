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
    public class RolesController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/Roles
        public IQueryable<Rol> GetRols()
        {
            return db.Rols;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Rol))]
        public IHttpActionResult GetRol(int id)
        {
            Rol rol = db.Rols.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRol(int id, Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rol.idRol)
            {
                return BadRequest();
            }

            db.Entry(rol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(Rol))]
        public IHttpActionResult PostRol(Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rols.Add(rol);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rol.idRol }, rol);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Rol))]
        public IHttpActionResult DeleteRol(int id)
        {
            Rol rol = db.Rols.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            db.Rols.Remove(rol);
            db.SaveChanges();

            return Ok(rol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolExists(int id)
        {
            return db.Rols.Count(e => e.idRol == id) > 0;
        }
    }
}