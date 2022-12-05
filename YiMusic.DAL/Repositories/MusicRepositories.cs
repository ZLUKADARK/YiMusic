using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data.Common;
using YiMusic.DAL.Data;
using YiMusic.DAL.Interfaces;
using YiMusic.Domain.Entities;

namespace YiMusic.DAL.Repositories
{
    public class MusicRepositories : IRepository<Music>
    {
        private readonly YiMusicDBContext _context;
        public MusicRepositories(YiMusicDBContext context)
        {
            _context = context;
        }

        public async Task<Music> Create(Music item)
        {
            _context.Music.Add(item);
            try
            {
                await _context.SaveChangesAsync();
                return item;
            }
            catch(DbUpdateException)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _context.Music.FindAsync(id);
            if (item == null)
                return false;
            _context.Music.Remove(item);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbException)
            {
                return false;
            }
        }

        public async Task<Music> Get(int id)
        {
            var item = await _context.Music.FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<Music>> GetAll()
        {
            return await _context.Music.ToListAsync();
        }

        public async Task<bool> Update(int id, Music item)
        {
            if (id != item.Id)
                return false;
            if (await MusicExists(item.Id))
                return false;
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }
        private async Task<bool> MusicExists(int id)
        {
           return await _context.Music.AnyAsync(x => x.Id == id);
        }
    }
}
