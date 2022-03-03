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
    public class TarjetasCreditoController : ApiController
    {
        private db_web_polimarketEntities db = new db_web_polimarketEntities();

        // GET: api/TarjetasCredito
        public IQueryable<TarjetaCredito> GetTarjetaCreditoes()
        {
            return db.TarjetaCreditoes;
        }

        // GET: api/TarjetasCredito/5
        [ResponseType(typeof(TarjetaCredito))]
        public IHttpActionResult GetTarjetaCredito(int id)
        {
            TarjetaCredito tarjetaCredito = db.TarjetaCreditoes.Find(id);
            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            return Ok(tarjetaCredito);
        }

        // PUT: api/TarjetasCredito/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarjetaCredito(int id, TarjetaCredito tarjetaCredito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarjetaCredito.idTarjetaCredito)
            {
                return BadRequest();
            }

            db.Entry(tarjetaCredito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaCreditoExists(id))
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

        // POST: api/TarjetasCredito
        [ResponseType(typeof(TarjetaCredito))]
        public IHttpActionResult PostTarjetaCredito(TarjetaCredito tarjetaCredito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TarjetaCreditoes.Add(tarjetaCredito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tarjetaCredito.idTarjetaCredito }, tarjetaCredito);
        }

        // DELETE: api/TarjetasCredito/5
        [ResponseType(typeof(TarjetaCredito))]
        public IHttpActionResult DeleteTarjetaCredito(int id)
        {
            TarjetaCredito tarjetaCredito = db.TarjetaCreditoes.Find(id);
            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            db.TarjetaCreditoes.Remove(tarjetaCredito);
            db.SaveChanges();

            return Ok(tarjetaCredito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarjetaCreditoExists(int id)
        {
            return db.TarjetaCreditoes.Count(e => e.idTarjetaCredito == id) > 0;
        }
    }
}