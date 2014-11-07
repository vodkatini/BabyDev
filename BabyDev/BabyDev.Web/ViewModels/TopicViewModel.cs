using System.Collections.Generic;

namespace BabyDev.Web.ViewModels
{
    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;

    public class TopicViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
}