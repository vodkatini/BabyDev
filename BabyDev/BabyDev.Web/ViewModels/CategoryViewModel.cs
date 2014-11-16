using System.Collections.Generic;
using BabyDev.Models;
using BabyDev.Web.Infrastructure.Mapping;
using System.Web.Mvc;

namespace BabyDev.Web.ViewModels
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TopicViewModel> Topics { get; set; }
    }
}