using Entities;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Domain
{
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

        public async Task<int> Count()
        {
            return await _context.Libraries.CountAsync();
        }

        public async Task<IEnumerable<Library>> GetByName(string name)
        {
            return await _context.Libraries
                .Where(elt => elt.Name.Contains(name)).ToListAsync(); 
        }

        public async Task<Library> AddLibrary(Library library)
        {
            await _context.AddAsync(library);
            await _context.SaveChangesAsync(); 
            return library;
        }

        public async Task<Library?> GetById(int id)
        {
            return await _context.Libraries.FirstOrDefaultAsync(elt => elt.Id == id); 
        }

        public async Task<Library> UpdateLibrary(Library library)
        {
            _context.Libraries.Update(library);
            await _context.SaveChangesAsync();
            return library; 
        }

        public async Task Delete(int id)
        {
            _context.Libraries.Remove(new Library() {Id = id});
            await _context.SaveChangesAsync(); 
        }
    }
}