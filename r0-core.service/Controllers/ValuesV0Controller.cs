using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace r0_core.service.Controllers
{
    [ApiVersion("0.0")]
    [Route("api/v{version:apiVersion}/values")]
    [Route("api/[controller]")]
    public class ValuesV0Controller : Controller
    {
        private readonly ILogger<ValuesV0Controller> _logger;

        public ValuesV0Controller(ILogger<ValuesV0Controller> logger)
        {
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogWarning("Entering Get for Values controller");
            return new[] { "value1", "value2" };
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
