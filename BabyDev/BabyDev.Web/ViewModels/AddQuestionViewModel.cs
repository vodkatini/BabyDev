using System.ComponentModel.DataAnnotations;

namespace BabyDev.Web.ViewModels
{
    using System;
    using BabyDev.Models;
    using System.Web.Mvc;

    public class AddQuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }        
    }
}