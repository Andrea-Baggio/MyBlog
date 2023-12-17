using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Post
    {
        //serve un costruttore vuoto per EF vuole poter istanziare oggetti senza informazioni
        public Post() { }

        public Post(string title, string description, string image)
        {
            Title = title;
            Description = description;
            Image = image;
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        public string? Image { get; set; } = string.Empty; 
    }
}
