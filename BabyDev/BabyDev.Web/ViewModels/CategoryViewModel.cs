using BabyDev.Models;
using BabyDev.Web.Infrastructure.Mapping;

namespace BabyDev.Web.ViewModels
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}