using Entities;

namespace Domain;

public interface ILibraryService
{
    IEnumerable<Library> GetAll();
    Library AddLibrary(Library library);
    Library GetLibraryById(int id);
    Library UpdateLibrary(Library library);
}