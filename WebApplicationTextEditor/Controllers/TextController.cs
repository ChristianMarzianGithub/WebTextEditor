using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplicationTextEditor.Models;
using Newtonsoft.Json.Linq;

namespace WebApplicationTextEditor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        // GET api/text
        [HttpGet]
        public ActionResult<IEnumerable<Text>> Get()
        {
            var db = new DataBaseController();
            var reader = db.executeQuery("SELECT * FROM TEXT");
            var liste = new List<Text>();
            while(reader.Read())
            {
                liste.Add(new Text()
                {
                    id = reader.GetInt32(0),
                    memo = reader.GetString(1),
                    createDate = reader.GetDateTime(2),
                    fileName = reader.GetString(3)
                });               
            }
            return liste;//new string[] { "value1", "value2" };
        }

        // GET api/text/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Text>> Get(int id)
        {
            var db = new DataBaseController();
            var reader = db.executeQuery($"SELECT {id} FROM TEXT");
            var liste = new List<Text>();
            while (reader.Read())
            {
                liste.Add(new Text()
                {
                    id = reader.GetInt32(0),
                    memo = reader.GetString(1),
                    createDate = reader.GetDateTime(2),
                    fileName = reader.GetString(3)
                });
            }
            return liste;//new string[] { "value1", "value2" };
        }

        // POST api/text
        [HttpPost]
        public void Post([FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            Text text = new Text();
            text.id = int.Parse(obj["id"].ToString());
            text.memo = obj["memo"].ToString();
            text.fileName = obj["fileName"].ToString();
            text.insert();
        }

        // PUT api/text/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            Text text = new Text();
            text.id = id;
            text.memo = obj["memo"].ToString();
            text.fileName = obj["fileName"].ToString();
            text.update();
        }

        // DELETE api/text/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Text text = new Text();
            text.id = id;
            text.delete();
        }
    }
}
