﻿namespace LifeVenture.Web.ViewModels.Common
{
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Common;
    using LifeVenture.Data.Models.Common;
    using LifeVenture.Services.Mapping;

    public class MessageInputModel : IMapTo<Message>
    {
        [Required(ErrorMessage = ErrorConstants.RequiredField)]
        [Display(Name = "Изпращач", Prompt = "Име")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = ErrorConstants.RequiredField)]
        [Display(Name = "Емайл", Prompt = "Електрона Поща")]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorConstants.RequiredField)]
        [Display(Name = "Заглавие", Prompt = "Заглавие")]
        public string Subject { get; set; }

        [Required(ErrorMessage = ErrorConstants.RequiredField)]
        [Display(Name = "Съобщение", Prompt = "Съобщение")]
        public string Description { get; set; }

        [Display(Name ="Телефон", Prompt = "Не е задължителен")]
        public int? Phone { get; set; }
    }
}
