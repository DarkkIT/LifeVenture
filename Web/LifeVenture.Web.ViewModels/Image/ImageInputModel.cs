﻿namespace LifeVenture.Web.ViewModels.Image
{
    using System.IO;

    public class ImageInputModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Stream Content { get; set; }
    }
}
