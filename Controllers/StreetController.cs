using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace liberaNet.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StreetController : ControllerBase
    {
        List<Street> Streets = new List<Street>();
        private readonly ILogger<StreetController> _logger;
        public StreetController(ILogger<StreetController> logger)
        {
            _logger = logger;
            var street1 = new Street("Heredia", 12.1, 24.3, 40.4, 40.9);
            Streets.Add(street1);
            street1 = new Street("Alajuela", 15.1, 30.3, 23.4, 35.9);
            Streets.Add(street1);
            street1 = new Street("Cartago", 14.1, 23.3, 35.4, 24.9);
            Streets.Add(street1);
            street1 = new Street("Guanacaste", 13.1, 21.3, 33.4, 14.9);
            Streets.Add(street1);
            street1 = new Street("Puntarenas", 27.1, 30.3, 10.4, 22.9);
            Streets.Add(street1);
            street1 = new Street("San Jose", 17.1, 20.3, 30.4, 23.9);
            Streets.Add(street1);
        }

        [HttpGet]
        public IEnumerable<string> closest()
        {
            return new string[] { "jairo", "pablo" };
            //.ToArray();
        }


        // GET: api/TodoItems/5
        [HttpGet]

        public IEnumerable<Street> GetStreet(string name)
        {
            var st = Streets.Where(x => x.name == name);
            if (st == null)
            {
                return null;
            }

            return st;
        }

        [HttpPost]

        public ActionResult insertstreet([FromBody] object inputstring)
        {
            Street deserializedStreet = JsonSerializer.Deserialize<Street>(inputstring.ToString());
            Console.WriteLine("before insert");
            Console.WriteLine(deserializedStreet);
            Street street1 = new Street(deserializedStreet.name, deserializedStreet.startx, deserializedStreet.starty,
            deserializedStreet.endx, deserializedStreet.endy);

            try
            {

                Streets.Insert(Streets.Count, street1);
                Console.WriteLine("after insert");
            }
            catch (Exception ex) { Console.WriteLine("CRASHHHHHHHHHHH"); }

            return Ok(Streets);
        }

        [HttpGet]
        public IEnumerable<Street> listAllStreets()
        {
            return Streets;
            //.ToArray();
        }

        [HttpGet]
        public IEnumerable<string> test()
        {
            return new string[] { "jairo", "pablo" };
            //.ToArray();
        }
    }
}
