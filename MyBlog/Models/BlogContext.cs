using Microsoft.EntityFrameworkCore;

namespace MyBlog.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BlogDb;Integrated Security=True;Pooling=False;TrustServerCertificate=True");
        }

        public void Seed()
        {
            if (!this.Posts.Any()) // Se non ci sono elementi, inizializzia
            {
                var seed = new Post[]
                {
                    new Post
                    {
                        Title = "Il mio primo post nel DB",
                        Description = "Li vuoi quei kiwi?",
                        Image = "https://picsum.photos/200",
                    },
                    new Post
                    {
                        Title = "Il mio SECONDO post nel DB",
                        Description = "Qua qua qua",
                        Image = "https://picsum.photos/200/300",
                    }
                };

                this.Posts.AddRange(seed); // Aggiunge gli elementi al DbSet
                this.SaveChanges(); // Salva i cambiamenti nel database
            }
        }
    }
}
