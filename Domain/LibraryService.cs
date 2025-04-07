﻿using Dtos;
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
        Libraries.Add(new Library { Id = 1, Name = "Library1" });
        Libraries.Add(new Library { Id = 2, Name = "Library2" });
        Libraries.Add(new Library { Id = 3, Name = "Library3" });
    }

    public IEnumerable<Library> GetAll()
    {
        return Libraries;
    }

    public Library AddLibrary(Library library)
    {
        library.Id = Libraries.Max(l => l.Id) + 1;
        Libraries.Add(library);
        return library;
    }

} 