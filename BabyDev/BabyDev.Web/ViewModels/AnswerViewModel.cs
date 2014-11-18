namespace BabyDev.Web.ViewModels
{
    using System;

    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class AnswerViewModel : IMapFrom<Answer>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Body { get; set; }

        [Display(Name = "Expert's Name")]
        public string AuthorName { get; set; }

        [Display(Name = "Answered On")]
        public DateTime AnsweredOn { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Answer, AnswerViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}