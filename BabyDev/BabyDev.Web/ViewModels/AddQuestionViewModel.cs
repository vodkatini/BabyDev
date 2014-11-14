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

        public string AuthorId { get; set; }

        public virtual BabyDevUser Author { get; set; }

        public DateTime AskedOn { get; set; }

        public bool IsAnswered { get; set; }
    }
}