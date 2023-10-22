using KurssiTestiApiNET6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KurssiTestiApiNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurssitController : ControllerBase
    {
        KurssiDBContext db = new KurssiDBContext();

        // Hae kaikki
        [HttpGet]
        public ActionResult GetAll()
        {
            var kurssit = db.Kurssits.ToList();
            return Ok(kurssit);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            Kurssit kurssi = db.Kurssits.Find(id);
            return Ok(kurssi);
        }


        [HttpPost]
        public ActionResult AddKurssi([FromBody]Kurssit kurssi) {
            db.Kurssits.Add(kurssi);
            db.SaveChanges();
            return Ok("Lisätty uusi kurssi: " + kurssi.Nimi);
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id) {
            var kurssi = db.Kurssits.Find(id);

            if (kurssi != null)
            {
                db.Kurssits.Remove(kurssi);
                db.SaveChanges();
                return Ok("Kurssi " + kurssi.Nimi + " poistettu.");
            }
            return BadRequest("Kurssia annetulla id:llä ei löydy.");
        }

    }
}
