using Microsoft.AspNetCore.Http;

namespace YiMusic.Domain.DataTranserObjects.Music
{
    public class CreateMusicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Music { get; set; }
        public string Author { get; set; }
    }
    public class GetMusicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string MusicPathUrl { get; set; }
        public string Author { get; set; }
    }
}
