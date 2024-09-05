using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImageVideoManager.Data
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumID { get; set; }

        public string UserID { get; set; }

        public string AlbumName { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }

        public string? Reserved1 { get; set; }
        public string? Reserved2 { get; set; }
    }

    public class Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaID { get; set; }

        public int AlbumID {get; set; }
        public int UserID { get; set; } 

        public string MediaType { get;set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }    
        
        public string? PictureDate { get; set; }
        public string? Place { get; set; }
        public string? PeopleRelation { get; set; }
        public DateTime DateUploaded { get; set; }

        public string? Reserved1 { get; set; }
        public string? Reserved2 { get; set; }
    }

    public class BaseTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagID { get; set; }

        public string TagName { get; set; }
        public string? Reserved1 { get; set; }
    }

    public class MediaTag
    {
        public int MediaID { get; set; }

        public int TagID { get; set; }
        public string? Reserved1 { get; set; }
    }


    public class AlbumTagDto
    {
        [Required]
        public string AlbumName { get; set; }
        [Required]
        public string Description { get; set; }

        public string TagName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AlbumID { get; set; }
        public string UserID { get; set; }
        public int TagID { get; set; }
    }

    public class TagDto
    {
        [Required]
        public string TagName { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
    }

    public class MediaDto
    {
        public string AlbumName { get; set; }
        public int UserID { get; set; }

        public string MediaType { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }

        public string? PictureDate { get; set; }
        public string? Place { get; set; }
        public string? PeopleRelation { get; set; }

        public string? Reserved1 { get; set; }
    }
}
