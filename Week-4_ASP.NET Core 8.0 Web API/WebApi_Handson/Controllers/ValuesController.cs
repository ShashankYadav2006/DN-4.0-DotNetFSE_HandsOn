using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new List<string> { "Value1", "Value2" };
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(values);
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound();
            return Ok(values[id]);
        }
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound();
            values[id] = value;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound();
            values.RemoveAt(id);
            return NoContent();
        }
    }
}
