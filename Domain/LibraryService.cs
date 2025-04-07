using Dtos;
using Entities;

namespace Domain;

public class LibraryService : ILibraryService
{
    public List<Library> Libraries
    {
        get;
        set;
        
    } = new List<Library>();

    public LibraryService()
    {
        Libraries.Add(new Library { Name = "Library1" });
        Libraries.Add(new Library { Name = "Library2" });
        Libraries.Add(new Library { Name = "Library3" });
    }

    public IEnumerable<Library> GetAll()
    {
        return Libraries;
    }

    public void AddLibrary(Library library)
    {
        Libraries.Add(library);
    }

} 