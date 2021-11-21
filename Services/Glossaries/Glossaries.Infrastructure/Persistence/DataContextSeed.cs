using Glossaries.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossaries.Infrastructure.Persistence
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext orderContext, ILogger<DataContextSeed> logger)
        {
            if (!orderContext.Glossaries.Any())
            {
                orderContext.Glossaries.AddRange(GetPreconfiguredGlossaries());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(DataContext).Name);
            }
        }

        private static IEnumerable<Glossary> GetPreconfiguredGlossaries()
        {
            return new List<Glossary>
            {
                new Glossary() {Term ="abyssal plain", Definition="The ocean floor offshore from the continental margin, usually very flat with a slight slope" },
                new Glossary() {Term="accrete", Definition="v. To add terranes (small land masses or pieces of crust) to another, usually larger, land mass."},
                new Glossary() {Term="alkaline", Definition="Term pertaining to a highly basic, as opposed to acidic, subtance. For example, hydroxide or carbonate of sodium or potassium"}
            };
        }
    }
}
