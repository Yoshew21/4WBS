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
        public async Task<ActionResult<IEnumerable<LibraryDto>>> Get([FromQuery] PageRequest pageRequest, string name = "")
        {
            if (string.Empty == name)
            {
                var result = _libraryService.GetAll(pageRequest.Index, pageRequest.Offset);
                var pageResponse = new PageResponse<LibraryDto>()
                {
                    Content = result.ToDto(),
                    Index = pageRequest.Index,
                    Offset = pageRequest.Offset,
                    TotalElement = _libraryService.Count()
                }; 
                return Ok(pageResponse);
            }

            var libraries = _libraryService.GetAll(name); 
            if (!libraries.Any())
            {
                return NoContent(); 
            }

            return Ok(libraries.ToDto());
        }

        // GET api/<LibrariesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDto>> Get(int id)        
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
        public async Task<IActionResult> Post([FromBody] LibraryDto libraryDto)
        {
            var libraryCreated = _libraryService.AddLibrary(libraryDto.ToEntity());
            return Created(string.Empty, libraryCreated.ToDto());
        }

        // PUT api/<LibrariesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LibraryDto libraryDto)
        {
            var library = libraryDto.ToEntity();
            library.Id = id;
            var libUpdated = _libraryService.UpdateLibrary(library);
            return Ok(libUpdated.ToDto());
        }
        
        // PATCH api/<LibrariesController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<LibrariesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var library = _libraryService.GetLibraryById(id);
            if (library == null)
            {
                return NotFound();
            }
            var libDeleted = _libraryService.DeleteLibrary(library);
            return Ok(libDeleted.ToDto());
        }
    }
}
