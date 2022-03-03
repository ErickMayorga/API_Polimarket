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
    public class Usuario_RolController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/Usuario_Rol
        public IQueryable<Usuario_Rol> GetUsuario_Rol()
        {
            return db.Usuario_Rol;
        }

        // GET: api/Usuario_Rol/5
        [ResponseType(typeof(Usuario_Rol))]
        public IHttpActionResult GetUsuario_Rol(int id)
        {
            Usuario_Rol usuario_Rol = db.Usuario_Rol.Find(id);
            if (usuario_Rol == null)
            {
                return NotFound();
            }

            return Ok(usuario_Rol);
        }

        // PUT: api/Usuario_Rol/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario_Rol(int id, Usuario_Rol usuario_Rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario_Rol.idUsuarioRol)
            {
                return BadRequest();
            }

            db.Entry(usuario_Rol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuario_RolExists(id))
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

        // POST: api/Usuario_Rol
        [ResponseType(typeof(Usuario_Rol))]
        public IHttpActionResult PostUsuario_Rol(Usuario_Rol usuario_Rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuario_Rol.Add(usuario_Rol);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuario_Rol.idUsuarioRol }, usuario_Rol);
        }

        // DELETE: api/Usuario_Rol/5
        [ResponseType(typeof(Usuario_Rol))]
        public IHttpActionResult DeleteUsuario_Rol(int id)
        {
            Usuario_Rol usuario_Rol = db.Usuario_Rol.Find(id);
            if (usuario_Rol == null)
            {
                return NotFound();
            }

            db.Usuario_Rol.Remove(usuario_Rol);
            db.SaveChanges();

            return Ok(usuario_Rol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Usuario_RolExists(int id)
        {
            return db.Usuario_Rol.Count(e => e.idUsuarioRol == id) > 0;
        }
    }
}