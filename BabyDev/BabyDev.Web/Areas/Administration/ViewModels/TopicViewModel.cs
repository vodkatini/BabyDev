using BabyDev.Web.Infrastructure.Mapping;

namespace BabyDev.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BabyDev.Models;

    public class TopicViewModel : IMapFrom<Topic>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int RealtedMonths { get; set; }

        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
}