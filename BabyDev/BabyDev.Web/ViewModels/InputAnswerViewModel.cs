using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BabyDev.Web.ViewModels
{
    public class InputAnswerViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public int QuestionId { get; set; }
    }
}