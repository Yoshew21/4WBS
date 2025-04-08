using Entities;

namespace Domain
{
    public interface ILibraryService
    {
        Task<IEnumerable<Library>> GetAll(int index, int offset);

        Task<int> Count();

        Task<IEnumerable<Library>> GetByName(string name);

        Task<Library> AddLibrary(Library library);

        Task<Library?> GetById(int id);

        Task<Library> UpdateLibrary(Library library);

        Task Delete(int id); 
    }
}