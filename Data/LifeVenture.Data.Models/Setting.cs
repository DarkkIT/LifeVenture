namespace LifeVenture.Data.Models
{
    using LifeVenture.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
