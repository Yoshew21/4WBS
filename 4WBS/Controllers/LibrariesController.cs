using _4WBS.Mappers;
using Domain;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4WBS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
                var result = await _libraryService.GetAll(pageRequest.Index, pageRequest.Offset);
                var pageResponse = new PageResponse<LibraryDto>()
                {
                    Content = result.ToDto(),
                    Index = pageRequest.Index,
                    Offset = pageRequest.Offset,
                    TotalElement = await _libraryService.Count()
                }; 

                 return Ok(pageResponse);
            }

            var libraries = await _libraryService.GetByName(name); 
            if (!libraries.Any())
            {
                return NoContent(); 
            }

            return Ok(libraries.ToDto());
        }

        // GET api/<LibrariesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var lib = await _libraryService.GetById(id);
            if (lib == null)
            {
                return NotFound(); 
            }
            return Ok(lib.ToDto());
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

        // DELETE api/<LibrariesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libraryService.Delete(id);
            return NoContent(); 
        }
    }
}
