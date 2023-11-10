namespace LifeVenture.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LifeVenture.Data.Models.Events;

    public class EventsCategoriesSeeder : ISeeder
    {
        private Dictionary<string, string> categoriesTypes = new Dictionary<string, string>
        {
            { "ПРИРОДА", "Да опазим природата" },
            { "СОЦИАЛНИ", "Включва всякакви социални събития" },
            { "ЖИВОТНИ", "Събития свързани с домашни любимци и помощ за бездомни животни" },
            { "КУЛТУРА", "Включва всякакви културни събития" },
            { "СОЦИАЛНО СЛАБИ", "Помощ за хора в неравностойно положение" },
            { "СПОРТНИ", "Включва всякакви спортни събития" },
            { "ЗАБАВЛЕНИЯ", "Всякакви събития със забавен характер" },
            { "БЕДСТВИЯ", "Събития свързани с природни бедствия" },
            { "ЗДРАВЕ", "Събития свързани със здравеопазване, здравословен начин на живот и подпомагане на хора борещи се със здравословни проблеми" },
            { "ДЕЦА", "Всякакви събития свързани с бъдещето на обществото - децата" },
            { "ОБРАЗОВАНИЕ", "Всякакви събития свързани с образованието и науката" },
            { "ХОРА С УВРЕЖДАНИЯ", "Подпомагане на хора с увреждания" },
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = this.GetCategories();
            await dbContext.AddRangeAsync(categories);
        }

        private List<Category> GetCategories()
            => new List<Category>(this.categoriesTypes
                .Select(x => new Category()
                {
                    Name = x.Key,
                    Description = x.Value,
                }));
    }
}
