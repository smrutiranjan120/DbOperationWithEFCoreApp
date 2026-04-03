using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasData(
                new Currency {Id = 1,Title = "INR", Description = "Indian INR" },
                new Currency { Id = 2, Title = "Dollar", Description = "Dollar" },
                new Currency { Id = 3, Title = "Euro", Description = "Euro" },
                new Currency { Id = 4, Title = "Dinar", Description = "Dinar" }
                );

            modelBuilder.Entity<Language>()
               .HasData(
               new Language { Id = 1, Title = "Hindi", Description = "Hindi" },
               new Language { Id = 2, Title = "English", Description = "English" },
               new Language { Id = 3, Title = "Spanish", Description = "Spanish" },
               new Language { Id = 4, Title = "French", Description = "French" }
               );
            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.Language)
            //    .WithMany(l => l.Books)
            //    .HasForeignKey(b => b.LanguageId);
            //modelBuilder.Entity<BookPrice>()
            //    .HasOne(bp => bp.Book)
            //    .WithMany(b => b.BookPrices)
            //    .HasForeignKey(bp => bp.BookId);
            //modelBuilder.Entity<BookPrice>()
            //    .HasOne(bp => bp.Currency)
            //    .WithMany(c => c.BookPrices)
            //    .HasForeignKey(bp => bp.CurrencyId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
