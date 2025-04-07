using Dtos;
using Entities;

namespace _4WBS.Mappers;

public static class LibraryMapper
{
    public static LibraryDto ToDto(this Library library)
    {
        return new LibraryDto() { Name = library.Name };
    }
    
    public static IEnumerable<LibraryDto> ToDto(this IEnumerable<Library> libraries)
    {
        return libraries.Select(ToDto);
    }
}