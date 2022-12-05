using Microsoft.EntityFrameworkCore;
using YiMusic.Domain.Entities;

namespace YiMusic.DAL.Data
{
    public class YiMusicDBContext : DbContext
    {
        public YiMusicDBContext(DbContextOptions<YiMusicDBContext> options)
        : base(options) { }
        public DbSet<Music> Music { get; set; }
    }
}
