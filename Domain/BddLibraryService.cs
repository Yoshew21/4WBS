using Entities;
using Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class BddLibraryService : ILibraryService
{
    private readonly AppDbContext _context;

    public BddLibraryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Library>> GetAll(int index, int offset)
    {
        return await _context.Libraries
            .Skip(index)
            .Take(offset)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Library>> GetAll(string name)
    {
        return await _context.Libraries
            .Where(l => l.Name.Contains(name))
            .ToListAsync();
    }

    public async Task<int> Count()
    {
        return await _context.Libraries.CountAsync();
    }

    public async Task<Library> AddLibrary(Library library)
    {
        await _context.Libraries.AddAsync(library);
        await _context.SaveChangesAsync();
        return library;
    }

    public async Task<Library> GetLibraryById(int id)
    {
        return await _context.Libraries.FindAsync(id);
    }

    public async Task<Library> UpdateLibrary(Library library)
    {
        _context.Libraries.Update(library);
        await _context.SaveChangesAsync();
        return library;
    }

    public async Task<Library> DeleteLibrary(Library library)
    {
        _context.Libraries.Remove(library);
        await _context.SaveChangesAsync();
        return library;
    }
}
