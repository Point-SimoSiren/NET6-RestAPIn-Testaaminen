using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using KurssiTestiApiNET6.Models;
using System.Text;

namespace KurssiTestiApiNET6.Tests
{
   
    [TestClass]
    public class Kurssitestit
    {
       
        [TestMethod]
            public async Task Test1()
            {

            WebApplicationFactory<Program> webAppFactory = new WebApplicationFactory<Program>();
            HttpClient client = webAppFactory.CreateDefaultClient();

            Kurssit uusiKurssi = new Kurssit();
                uusiKurssi.Nimi = "Testikurssi";
                uusiKurssi.Laajuus = 1;

                // Muutetaan edellä luotu objekti Jsoniksi
                string input = JsonConvert.SerializeObject(uusiKurssi);
                StringContent content = new StringContent(input, Encoding.UTF8, "application/json");

                // Lähetetään muodostettu data testattavalle api:lle post pyyntönä
                var responsePost = await client.PostAsync("api/kurssit", content);

                // Tarkistetaan onko vastauksen statuskoodi ok
                Assert.AreEqual(responsePost.StatusCode.ToString().ToLower(), "ok");

                // Koitetaan hakea saman niminen kurssi
                var responseGet = await client.GetAsync("api/kurssit");
                var json = await responseGet.Content.ReadAsStringAsync();

                var kurssit = JsonConvert.DeserializeObject<Kurssit[]>(json).ToList();

                 var kurssi = kurssit.Where(k => k.Nimi == "Testikurssi").FirstOrDefault();

                 Assert.AreEqual("Testikurssi", kurssi.Nimi);

                 var responseDelete = await client.DeleteAsync("api/kurssit/" + kurssi.KurssiId);

                Assert.AreEqual("ok", responseDelete.StatusCode.ToString().ToLower());

                var response = await client.GetAsync("api/kurssit/" + kurssi.KurssiId);

                Assert.AreEqual("nocontent", response.StatusCode.ToString().ToLower());

        }

    }
}
