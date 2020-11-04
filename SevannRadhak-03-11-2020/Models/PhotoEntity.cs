namespace SevannRadhak_03_11_2020.Models
{
    public class PhotoEntity
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }

        public AlbumEntity Album { get; set; }
    }
}
