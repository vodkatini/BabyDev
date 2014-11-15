using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BabyDev.Web.Areas.Child.ViewModels
{
    using System;

    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;

    public class AddChildViewModel
    {  
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        public DateTime? Born { get; set; }

        [Required]
        public Gender Gender { get; set; }       
    }
}