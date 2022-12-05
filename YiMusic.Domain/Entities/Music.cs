﻿namespace YiMusic.Domain.Entities
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string MusicPathUrl { get; set;}
        public string Author { get; set; }
    }
}
