namespace BabyDev.Web.ViewModels
{
    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class QuestionViewModel : IMapFrom<Question>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorId { get; set; }

        public virtual BabyDevUser Author { get; set; }

        public DateTime AskedOn { get; set; }

        public bool IsAnswered { get; set; }
    }
}