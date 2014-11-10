using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BabyDev.Web.Areas.Child.ViewModels
{
    using System;

    using BabyDev.Models;

    public class ChildViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        public DateTime Born { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}