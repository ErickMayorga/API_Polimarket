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
    public class Sucursal_ProductoController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/Sucursal_Producto
        public IQueryable<Sucursal_Producto> GetSucursal_Producto()
        {
            return db.Sucursal_Producto;
        }

        // GET: api/Sucursal_Producto/5
        [ResponseType(typeof(Sucursal_Producto))]
        public IHttpActionResult GetSucursal_Producto(int id)
        {
            Sucursal_Producto sucursal_Producto = db.Sucursal_Producto.Find(id);
            if (sucursal_Producto == null)
            {
                return NotFound();
            }

            return Ok(sucursal_Producto);
        }

        // PUT: api/Sucursal_Producto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSucursal_Producto(int id, Sucursal_Producto sucursal_Producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal_Producto.idSucursalProducto)
            {
                return BadRequest();
            }

            db.Entry(sucursal_Producto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sucursal_ProductoExists(id))
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

        // POST: api/Sucursal_Producto
        [ResponseType(typeof(Sucursal_Producto))]
        public IHttpActionResult PostSucursal_Producto(Sucursal_Producto sucursal_Producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursal_Producto.Add(sucursal_Producto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sucursal_Producto.idSucursalProducto }, sucursal_Producto);
        }

        // DELETE: api/Sucursal_Producto/5
        [ResponseType(typeof(Sucursal_Producto))]
        public IHttpActionResult DeleteSucursal_Producto(int id)
        {
            Sucursal_Producto sucursal_Producto = db.Sucursal_Producto.Find(id);
            if (sucursal_Producto == null)
            {
                return NotFound();
            }

            db.Sucursal_Producto.Remove(sucursal_Producto);
            db.SaveChanges();

            return Ok(sucursal_Producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sucursal_ProductoExists(int id)
        {
            return db.Sucursal_Producto.Count(e => e.idSucursalProducto == id) > 0;
        }
    }
}