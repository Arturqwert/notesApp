using Microsoft.EntityFrameworkCore;
using notesApp.Models;

namespace notesApp.DataAccess
{
    public class NotesDBContext : DbContext 
    {
        private readonly IConfiguration _configuration;
        public NotesDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Note> notes => Set<Note>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }
    }
}
