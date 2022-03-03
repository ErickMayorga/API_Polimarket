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
    public class SucursalesController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/Sucursales
        public IQueryable<Sucursal> GetSucursals()
        {
            return db.Sucursals;
        }

        // GET: api/Sucursales/5
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult GetSucursal(int id)
        {
            Sucursal sucursal = db.Sucursals.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }

        // PUT: api/Sucursales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSucursal(int id, Sucursal sucursal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal.idSucursal)
            {
                return BadRequest();
            }

            db.Entry(sucursal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExists(id))
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

        // POST: api/Sucursales
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult PostSucursal(Sucursal sucursal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursals.Add(sucursal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sucursal.idSucursal }, sucursal);
        }

        // DELETE: api/Sucursales/5
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult DeleteSucursal(int id)
        {
            Sucursal sucursal = db.Sucursals.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            db.Sucursals.Remove(sucursal);
            db.SaveChanges();

            return Ok(sucursal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SucursalExists(int id)
        {
            return db.Sucursals.Count(e => e.idSucursal == id) > 0;
        }
    }
}