namespace BabyDev.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;

    public class TopicViewModel : AdministrationViewModel, IMapFrom<Topic>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        public string Title { get; set; }

        public int RelatedMonths { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        
        public string AuthorId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Topic, TopicViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name));
        }
    }
}