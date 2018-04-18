using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCinema.Core;
using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HomeCinema.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IHomeCinemaDbContext ctx;

        public ValuesController(IHomeCinemaDbContext ctx)
        {
            Guard.ArgumentIsNotNull(ctx, "ctx cannot be null.");
            this.ctx = ctx;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return ctx.Set<Genre>().ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
