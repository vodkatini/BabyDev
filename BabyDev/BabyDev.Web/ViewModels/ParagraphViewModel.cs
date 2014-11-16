namespace BabyDev.Web.ViewModels
{
    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ParagraphViewModel : IMapFrom<Paragraph>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Subtitle { get; set; }

        public string Content { get; set; }

        public virtual BabyDevUser Author { get; set; }
    }
}