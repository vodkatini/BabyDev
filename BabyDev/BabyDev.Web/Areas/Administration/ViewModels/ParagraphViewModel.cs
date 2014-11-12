namespace BabyDev.Web.Areas.Administration.ViewModels
{
    using System.Web.Mvc;
    using AutoMapper;
    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;

    public class ParagraphViewModel : AdministrationViewModel, IMapFrom<Paragraph>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Subtitle { get; set; }

        public string Content { get; set; }

        public int TopicId { get; set; }

        public string TopicTitle { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Paragraph, ParagraphViewModel>()
               .ForMember(m => m.TopicTitle, opt => opt.MapFrom(u => u.Topic.Title));
        }
    }
}