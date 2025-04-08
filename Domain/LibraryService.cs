using Dtos;
    using Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Domain;
    
    public class LibraryService : ILibraryService
    {
        private List<Library> Libraries { get; set; }
    
        public LibraryService()
        {
            Libraries = new List<Library>
            {
                new Library { Id = 1, Name = "Library1" },
                new Library { Id = 2, Name = "Library2" },
                new Library { Id = 3, Name = "Library3" }
            };
        }
        
        public Task<IEnumerable<Library>> GetAll(int index, int offset)
        {
            return Task.FromResult<IEnumerable<Library>>(Libraries.Skip(index).Take(offset));
        }
    
        public Task<int> Count()
        {
            return Task.FromResult(Libraries.Count);
        }
    
        public Task<IEnumerable<Library>> GetAll()
        {
            return Task.FromResult<IEnumerable<Library>>(Libraries);
        }
        
        public Task<IEnumerable<Library>> GetAll(string name)
        {
            return Task.FromResult<IEnumerable<Library>>(
                Libraries.Where(l => l.Name.Contains(name)));
        }
    
        public Task<Library> AddLibrary(Library library)
        {
            library.Id = Libraries.Max(l => l.Id) + 1;
            Libraries.Add(library);
            return Task.FromResult(library);
        }
    
        public Task<Library> GetLibraryById(int id)
        {
            return Task.FromResult(Libraries.FirstOrDefault(l => l.Id == id));
        }
    
        public Task<Library> UpdateLibrary(Library library)
        {
            var existingLibrary = Libraries.FirstOrDefault(l => l.Id == library.Id);
            if (existingLibrary != null)
            {
                existingLibrary.Name = library.Name;
            }
            return Task.FromResult(existingLibrary);
        }
        
        public Task<Library> DeleteLibrary(Library library)
        {
            var existingLibrary = Libraries.FirstOrDefault(l => l.Id == library.Id);
            if (existingLibrary != null)
            {
                Libraries.Remove(existingLibrary);
            }
            return Task.FromResult(existingLibrary);
        }
    }