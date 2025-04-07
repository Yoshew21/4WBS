using _4WBS.Mappers;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4WBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {

        private List<Library> libraries
        {
            get;
            set;
        } = new List<Library>();
        public LibrariesController()
        {
            libraries.Add(new Library { Name = "Library1" });
            libraries.Add(new Library { Name = "Library2" });
            libraries.Add(new Library { Name = "Library3" });
        }
        
        // GET: api/<LibrariesController>
        [HttpGet]
        public ActionResult<IEnumerable<LibraryDto>> Get()
        {
            if (libraries.Count == 0)
            {
                return NoContent();
            }
            return Ok(libraries.ToDto());
        }

        // GET api/<LibrariesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibrariesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LibrariesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
        // PATCH api/<LibrariesController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrariesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
