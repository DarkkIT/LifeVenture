namespace LifeVenture.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LifeVenture.Data.Models.Locations;
    using LifeVenture.Data.Models.Locations.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    public class LocationsSeeder : ISeeder
    {
        private const string AttributeValue = "value";
        private const string RegionId = "oblast";
        private const string MunicipalityId = "obshtina";
        private const string SettlementId = "nm";
        private const int SleepSeconds = 2000;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Regions.Any())
            {
                return;
            }

            var regions = this.ScrapeData();
            await dbContext.AddRangeAsync(regions);
        }

        private IEnumerable<Region> ScrapeData()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ekatte.com/%D0%B0-%D1%8F");

            var items = new List<string[]>();

            var regionsDropDown = new SelectElement(driver.FindElement(By.Id(RegionId)));
            var locations = new List<Region>();

            for (int i = 1; i < regionsDropDown.Options.Count; i++)
            {
                regionsDropDown.SelectByIndex(i);
                var region = this.GetLocation<Region>(regionsDropDown, i);

                var municipalityDropDown = new SelectElement(driver.FindElement(By.Id(MunicipalityId)));
                municipalityDropDown = this.GetDropdown(driver, municipalityDropDown, MunicipalityId);

                for (int y = 1; y < municipalityDropDown.Options.Count; y++)
                {
                    municipalityDropDown.SelectByIndex(y);
                    var municipality = this.GetLocation<Municipality>(municipalityDropDown, y);
                    region.Municipalities.Add(municipality);

                    var settlementDropDown = new SelectElement(driver.FindElement(By.Id(SettlementId)));
                    settlementDropDown = this.GetDropdown(driver, settlementDropDown, SettlementId);

                    municipality.Settlements = settlementDropDown
                        .Options
                        .Skip(1)
                        .Select(s =>
                        {
                            var settlement = new Settlement();
                            settlement.Name = s.Text;
                            settlement.Code = s.GetAttribute(AttributeValue);
                            return settlement;
                        })
                        .ToList();
                }

                locations.Add(region);
            }

            driver.Quit();
            return locations;
        }

        private SelectElement GetDropdown(ChromeDriver driver, SelectElement municipalityDropDown, string elementId)
        {
            while (municipalityDropDown.Options.Count == 0)
            {
                System.Threading.Thread.Sleep(SleepSeconds);
                municipalityDropDown = new SelectElement(driver.FindElement(By.Id(elementId)));
            }

            return municipalityDropDown;
        }

        private T GetLocation<T>(SelectElement regionsDropDown, int i)
            where T : ILocation, new()
        {
            var regionOption = regionsDropDown.Options[i];
            var location = new T();
            location.Name = regionOption.Text;
            location.Code = regionOption.GetAttribute(AttributeValue);
            return location;
        }
    }
}
