﻿namespace BabyDev.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;
    using System.ComponentModel;

    public class TopicViewModel : IMapFrom<Topic>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        [DisplayName("related months")]
        public int RelatedMonths { get; set; }

        public virtual ICollection<ParagraphViewModel> Paragraphs { get; set; }
    }
}