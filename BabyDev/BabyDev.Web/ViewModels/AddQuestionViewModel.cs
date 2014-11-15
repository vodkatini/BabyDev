using System.ComponentModel.DataAnnotations;

namespace BabyDev.Web.ViewModels
{
    using System;
    using BabyDev.Models;

    public class AddQuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }        
    }
}