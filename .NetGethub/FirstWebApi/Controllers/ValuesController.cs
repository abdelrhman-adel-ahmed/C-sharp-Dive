using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    public class ValuesController : ApiController
    {

        List<int> ints = new List<int> { 1, 4, 5, 7, 21 };

        // GET api/values
        public IEnumerable<int> Get()
        {
            return ints;
        }

        // GET api/values/5
        public int Get(int id)
        {
            return ints[id];
        }

        // POST api/values
        public void Post([FromBody] int value)
        {
            ints.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] int value)
        {
            ints[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            ints.RemoveAt(id);
        }
    }
}
