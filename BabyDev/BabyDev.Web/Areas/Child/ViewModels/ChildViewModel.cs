namespace BabyDev.Web.Areas.Child.ViewModels
{
    using System;

    using BabyDev.Models;

    public class ChildViewModel
    {
        public string Name { get; set; }

        public DateTime Born { get; set; }

        public Gender Gender { get; set; }
    }
}