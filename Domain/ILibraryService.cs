using Entities;

namespace Domain;

public interface ILibraryService
{
    IEnumerable<Library> GetAll(int index, int offset);
    int Count();
    IEnumerable<Library> GetAll(string name);
    Library AddLibrary(Library library);
    Library GetLibraryById(int id);
    Library UpdateLibrary(Library library);
    Library DeleteLibrary(Library library);
}