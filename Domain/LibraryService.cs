using Entities;

namespace Domain;

public class LibraryService : ILibraryService
{
    private List<Library> Libraries
    {
        get;
        set;
    } = new List<Library>();


    public LibraryService()
    {
        Libraries.Add(new Library() { Id = 1,Name = "bibli1" });
        Libraries.Add(new Library() { Id = 2, Name = "bibli2" });
        Libraries.Add(new Library() { Id = 3, Name = "bibli3" });
    }

    public Task<IEnumerable<Library>> GetAll(int index, int offset)
    {
        return Task.FromResult(Libraries.Skip(index).Take(offset)); 
    }

    public Task<int> Count()
    {
        return Task.FromResult(Libraries.Count); 
    }

    public Task<IEnumerable<Library>> GetByName(string name)
    {
        return Task.FromResult(Libraries.Where(elt => elt.Name.Contains(name))); 
    }

    public Task<Library> AddLibrary(Library library)
    {
        library.Id = Libraries.Max(elt => elt.Id) + 1; 
        Libraries.Add(library);
        return Task.FromResult(library);
    }

    public Task<Library?> GetById(int id)
    {
        return Task.FromResult(Libraries.FirstOrDefault(elt => elt.Id == id)); 
    }

    public async Task<Library> UpdateLibrary(Library library)
    {
        var libraryToUpdate = await GetById(library.Id);
        libraryToUpdate.Name = library.Name;
        return libraryToUpdate; 
    }

    public async Task Delete(int id)
    {
        var libraryToDelete = await GetById(id);
        Libraries.Remove(libraryToDelete); 
    }
}