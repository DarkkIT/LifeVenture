namespace LifeVenture.Data.Models.People
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Common;

    public class PersonOfGoodness : BaseDeletableModel<int>
    {
        public string FieldOfWork { get; set; }

        public string Description { get; set; }

        public ApplicationUser User { get; set; }

        public ImagePeople Image { get; set; }
    }
}
