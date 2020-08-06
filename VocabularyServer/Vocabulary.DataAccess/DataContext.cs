using Microsoft.EntityFrameworkCore;
using Vocabulary.DataAccess.Models;

namespace Vocabulary.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<WordSet> WordSets { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordExample> Examples { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var wordSetEntity = builder.Entity<WordSet>();
            wordSetEntity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);

            var wordEntity = builder.Entity<Word>();
            wordEntity.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(50);

            var wordExampleEntity = builder.Entity<WordExample>();
            wordExampleEntity.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(500);

            base.OnModelCreating(builder);
        }
    }
}
