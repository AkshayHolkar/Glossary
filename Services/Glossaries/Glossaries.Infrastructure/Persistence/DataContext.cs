using Glossaries.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Glossaries.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Glossary> Glossaries { get; set; }
    }
}
