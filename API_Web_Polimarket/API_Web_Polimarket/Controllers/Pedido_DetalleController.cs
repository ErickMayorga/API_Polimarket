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
    public class Pedido_DetalleController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/Pedido_Detalle
        public IQueryable<Pedido_Detalle> GetPedido_Detalle()
        {
            return db.Pedido_Detalle;
        }

        // GET: api/Pedido_Detalle/5
        [ResponseType(typeof(Pedido_Detalle))]
        public IHttpActionResult GetPedido_Detalle(int id)
        {
            Pedido_Detalle pedido_Detalle = db.Pedido_Detalle.Find(id);
            if (pedido_Detalle == null)
            {
                return NotFound();
            }

            return Ok(pedido_Detalle);
        }

        // PUT: api/Pedido_Detalle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido_Detalle(int id, Pedido_Detalle pedido_Detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido_Detalle.idCompra)
            {
                return BadRequest();
            }

            db.Entry(pedido_Detalle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pedido_DetalleExists(id))
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

        // POST: api/Pedido_Detalle
        [ResponseType(typeof(Pedido_Detalle))]
        public IHttpActionResult PostPedido_Detalle(Pedido_Detalle pedido_Detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedido_Detalle.Add(pedido_Detalle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido_Detalle.idCompra }, pedido_Detalle);
        }

        // DELETE: api/Pedido_Detalle/5
        [ResponseType(typeof(Pedido_Detalle))]
        public IHttpActionResult DeletePedido_Detalle(int id)
        {
            Pedido_Detalle pedido_Detalle = db.Pedido_Detalle.Find(id);
            if (pedido_Detalle == null)
            {
                return NotFound();
            }

            db.Pedido_Detalle.Remove(pedido_Detalle);
            db.SaveChanges();

            return Ok(pedido_Detalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pedido_DetalleExists(int id)
        {
            return db.Pedido_Detalle.Count(e => e.idCompra == id) > 0;
        }
    }
}