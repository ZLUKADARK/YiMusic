using YiMusic.Domain.DataTranserObjects.Music;

namespace YiMusic.BLL.Interfaces
{
    public interface IMusicServices
    {
        public Task<GetMusicDto> CreateMusic(CreateMusicDto item);
        public Task<bool> UpdateMusic(CreateMusicDto item);
        public Task<bool> DeleteMusic(int id);
        public Task<GetMusicDto> GetMusic(int id);
        public Task<IEnumerable<GetMusicDto>> GetAllMusic();
    }
}
