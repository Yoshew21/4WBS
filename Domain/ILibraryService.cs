using Entities;

namespace Domain;

public interface ILibraryService
{
    Task<IEnumerable<Library>> GetAll(int index, int offset);
    Task<int> Count();
    Task<IEnumerable<Library>> GetAll(string name);
    Task<Library> AddLibrary(Library library);
    Task<Library> GetLibraryById(int id);
    Task<Library> UpdateLibrary(Library library);
    Task<Library> DeleteLibrary(Library library);
}