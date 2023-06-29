using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.File;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Optionals
{
    public class FileRepository : IFileRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<ConsoleApp1.Models.File> _dbSet;

        public FileRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<ConsoleApp1.Models.File>();
        }

        public async Task<FileGetDto> GetByIdAsync(int id)
        {
            var file = await _dbSet.Include(s => s.Seller)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (file == null)
                return new FileGetDto();

            var result = new FileGetDto
            {
                Id = file.Id,
                Name = file.Name,
                Url = file.Url,
                Seller = file.Seller,
                SellerId = file.SellerId
            };

            return result;
        }
       
        public async Task<List<ConsoleApp1.Models.File>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> AddAsync(FileAddDto fileDto,int ownerFileId)
        {
            var entity = new ConsoleApp1.Models.File
            {
                Name = fileDto.Name,
                Url = fileDto.Url,
                SellerId = ownerFileId
            };
            await _dbSet.AddAsync(entity);
         var result=   await _context.SaveChangesAsync();
         return result;
        }

        public async Task UpdateAsync(ConsoleApp1.Models.File fileForUser)
        {
            _context.Entry(fileForUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(FileGetDto dto)
        {
            var file = await _dbSet.FirstOrDefaultAsync(f => f.Id == dto.Id);
            if (file==null)
            {
                return false;
            }
            _dbSet.Remove(file);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return true;
            return false;
        }

        public async Task<List<FileGetDto>> GetAllByOwnerFileIdAsync(int ownerFileId)
        {
           var list= await _dbSet.Where(s => s.SellerId == ownerFileId).Select(f => new FileGetDto
           {
               Id = f.Id,
               Name = f.Name,
               Url = f.Url,
               Seller = f.Seller,
               SellerId = f.SellerId
           }).ToListAsync();
           return list;
        }
    }
}
