namespace MyBlog.Models
{
    public class Post
    {
        //serve un costruttore vuoto per Entity F. vuole poter istanziare oggetti senza informazioni
        public Post() { }

        public Post(string title, string description, string image)
        {
            Title = title;
            Description = description;
            Image = image;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = string.Empty; //questo per i campi nullable
    }
}
