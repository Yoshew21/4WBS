using Entities;

namespace Domain;

public interface ILibraryService
{
    IEnumerable<Library> GetAll();
    void AddLibrary(Library library);
}