using System.IO;
using YiMusic.BLL.Interfaces;
using YiMusic.DAL.Interfaces;
using YiMusic.Domain.DataTranserObjects.Music;
using YiMusic.Domain.Entities;

namespace YiMusic.BLL.Services
{
    public class MusicServices : IMusicServices
    {
        private readonly IRepository<Music> _musicRepository;
       
        public MusicServices(IRepository<Music> musicRepository) 
        {
            _musicRepository = musicRepository;
        }

        public async Task<GetMusicDto> CreateMusic(CreateMusicDto item)
        {
            var music = await CreateLocal(item);
            if (music == null)
                return null;
            var result = await _musicRepository.Create(music);
            
            return new GetMusicDto 
            { 
                Id = result.Id, 
                Author = result.Author, 
                Description = result.Description, 
                Title = result.Title, 
                MusicPathUrl = result.MusicPathUrl, 
                Image = result.Image 
            };
        }

        public async Task<bool> DeleteMusic(int id)
        {
            var result = await _musicRepository.Delete(id);
            return await DeleteLocal(result);
        }

        public async Task<IEnumerable<GetMusicDto>> GetAllMusic()
        {
            var result = from m in await _musicRepository.GetAll()
                         select new GetMusicDto
                         {
                             Id = m.Id,
                             Author = m.Author,
                             Description = m.Description,
                             Title = m.Title,
                             MusicPathUrl = m.MusicPathUrl,
                             Image = m.Image
                         };
            return result.ToList();
        }

        public async Task<GetMusicDto> GetMusic(int id)
        {
            var result = await _musicRepository.Get(id);
            return new GetMusicDto
            {
                Id = result.Id,
                Author = result.Author,
                Description = result.Description,
                Title = result.Title,
                MusicPathUrl = result.MusicPathUrl,
                Image = result.Image
            };
        }

        public Task<bool> UpdateMusic(CreateMusicDto item)
        {
            throw new NotImplementedException();
        }

        private async Task<Music> CreateLocal(CreateMusicDto item)
        {
            if (!item.Music.ContentType.Contains("audio"))
                return null;
            if (!item.Image.ContentType.Contains("image"))
                return null;
            string musicPath = $"/DataFiels/{item.Author}/Music/" + item.Music.FileName;
            string musicImage = $"/DataFiels/{item.Author}/Image/" + item.Image.FileName;
            string musicfullPath = Path.GetFullPath(Environment.CurrentDirectory + $"/wwwroot/DataFiels/{item.Author}/Music/");
            string imagefullPath = Path.GetFullPath(Environment.CurrentDirectory + $"/wwwroot/DataFiels/{item.Author}/Image/");
            string fulpath = Path.GetFullPath(Environment.CurrentDirectory + "/wwwroot");
            if (!Directory.Exists(musicfullPath) & !Directory.Exists(imagefullPath))
            {
                Directory.CreateDirectory(musicfullPath);
                Directory.CreateDirectory(imagefullPath);
            }

            using (var stream = new FileStream(fulpath + musicPath, FileMode.Create))
            {
                await item.Music.CopyToAsync(stream);
            }

            using (var stream = new FileStream(fulpath + musicImage, FileMode.Create))
            {
                await item.Image.CopyToAsync(stream);
            }

            return new Music() { Author = item.Author, Description = item.Description, Title = item.Title, MusicPathUrl = musicPath, Image = musicImage };
        }
        private async Task<bool> DeleteLocal(Music item)
        {
            string fulpath = Path.GetFullPath(Environment.CurrentDirectory + "/wwwroot");
            try
            {
                File.Delete(fulpath + item.MusicPathUrl);
                File.Delete(fulpath + item.Image);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
