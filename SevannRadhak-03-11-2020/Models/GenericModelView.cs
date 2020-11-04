using System.Collections.Generic;

namespace SevannRadhak_03_11_2020.Models
{
    public class GenericModelView
    {
        public IEnumerable<AlbumEntity> Albums { get; set; }
        public IEnumerable<CommentsEntity> Comments { get; set; }
        public IEnumerable<PhotoEntity> Photos { get; set; }
    }
}
