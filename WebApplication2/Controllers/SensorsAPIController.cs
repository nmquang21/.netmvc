using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SensorsAPIController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/SensorsAPI
        public IQueryable<Sensor> GetSensors()
        {
            return db.Sensors;
        }

        // GET: api/SensorsAPI/5
        [ResponseType(typeof(Sensor))]
        public IHttpActionResult GetSensor(string id)
        {
            Sensor sensor = db.Sensors.Find(id);
            if (sensor == null)
            {
                return NotFound();
            }

            return Ok(sensor);
        }

        // PUT: api/SensorsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSensor(string id, Sensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sensor.id)
            {
                return BadRequest();
            }

            db.Entry(sensor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
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

        // POST: api/SensorsAPI
        [ResponseType(typeof(Sensor))]
        public IHttpActionResult PostSensor(Sensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            sensor.createAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            db.Sensors.Add(sensor);

            try
            {
                db.SaveChanges();
                Debug.WriteLine("------->New Information: Temperature:"+sensor.temperature+"--Humid:"+sensor
                                    .humid);
            }
            catch (DbUpdateException)
            {
                if (SensorExists(sensor.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sensor.id }, sensor);
        }

        // DELETE: api/SensorsAPI/5
        [ResponseType(typeof(Sensor))]
        public IHttpActionResult DeleteSensor(string id)
        {
            Sensor sensor = db.Sensors.Find(id);
            if (sensor == null)
            {
                return NotFound();
            }

            db.Sensors.Remove(sensor);
            db.SaveChanges();

            return Ok(sensor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SensorExists(string id)
        {
            return db.Sensors.Count(e => e.id == id) > 0;
        }
    }
}