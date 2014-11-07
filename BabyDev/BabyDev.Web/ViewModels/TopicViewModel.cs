namespace BabyDev.Web.ViewModels
{
    using BabyDev.Models;
    using BabyDev.Web.Infrastructure.Mapping;

    public class TopicViewModel : IMapFrom<Topic>
    {
        public string Title { get; set; }
    }
}