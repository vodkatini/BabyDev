namespace BabyDev.Web.Areas.Child.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;

    public class TopicViewModel : IMapFrom<Topic>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int RelatedMonths { get; set; }

        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
}