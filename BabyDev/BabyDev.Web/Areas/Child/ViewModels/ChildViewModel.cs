using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BabyDev.Web.Areas.Child.ViewModels
{
    using System;

    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;

    public class ChildViewModel : IMapFrom<Child>, IHaveCustomMappings
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

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            //configuration.CreateMap<Child, ChildViewModel>()
            //    .ForMember(m => m.Born, opt => opt.MapFrom(u => u.Born.ToLocalTime()));
        }
    }
}