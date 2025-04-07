using _4WBS.Mappers;
using Domain;
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
        private readonly ILibraryService _libraryService;
      
        public LibrariesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: api/<LibrariesController>
        [HttpGet]
        public ActionResult<IEnumerable<LibraryDto>> Get()
        {
            var libraries = _libraryService.GetAll(); 
            if (!libraries.Any())
            {
                return NoContent(); 
            }

            return Ok(libraries.ToDto());
        }

        // GET api/<LibrariesController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<LibraryDto>> Get(int id)        
        {
            var libraries = _libraryService.GetLibraryById(id); 
            if (libraries == null)
            {
                return NotFound(); 
            }
            return Ok(libraries.ToDto());
        }

        // POST api/<LibrariesController>
        [HttpPost]
        public IActionResult Post([FromBody] LibraryDto libraryDto)
        {
            var libraryCreated = _libraryService.AddLibrary(libraryDto.ToEntity());
            return Created(string.Empty, libraryCreated);
        }

        // PUT api/<LibrariesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LibraryDto libraryDto)
        {
            var library = libraryDto.ToEntity();
            library.Id = id;
            var libUpdated = _libraryService.UpdateLibrary(library);
            return Ok(libUpdated);
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
