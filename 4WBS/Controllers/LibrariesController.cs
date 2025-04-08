using _4WBS.Mappers;
using Domain;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (string.IsNullOrEmpty(name))
            {
                var result = await _libraryService.GetAll(pageRequest.Index, pageRequest.Offset);
                var pageResponse = new PageResponse<LibraryDto>()
                {
                    Content = result.Select(lib => lib.ToDto()),
                    Index = pageRequest.Index,
                    Offset = pageRequest.Offset,
                    TotalElement = await _libraryService.Count()
                }; 
                return Ok(pageResponse);
            }

            var libraries = await _libraryService.GetAll(name);
            if (!libraries.Any())
            {
                return NoContent(); 
            }

            return Ok(libraries.Select(lib => lib.ToDto()));
        }

        // GET api/<LibrariesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDto>> Get(int id)        
        {
            var library = await _libraryService.GetLibraryById(id);
            if (library == null)
            {
                return NotFound(); 
            }
            return Ok(library.ToDto());
        }

        // POST api/<LibrariesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LibraryDto libraryDto)
        {
            var libraryCreated = await _libraryService.AddLibrary(libraryDto.ToEntity());
            return Created(string.Empty, libraryCreated.ToDto());
        }

        // PUT api/<LibrariesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LibraryDto libraryDto)
        {
            var library = libraryDto.ToEntity();
            library.Id = id;
            var libUpdated = await _libraryService.UpdateLibrary(library);
            return Ok(libUpdated.ToDto());
        }
        
        // PATCH api/<LibrariesController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] string value)
        {
            // Not implemented
        }

        // DELETE api/<LibrariesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var library = await _libraryService.GetLibraryById(id);
            if (library == null)
            {
                return NotFound();
            }
            var libDeleted = await _libraryService.DeleteLibrary(library);
            return Ok(libDeleted.ToDto());
        }
    }
}