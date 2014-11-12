using BabyDev.Contracts;

namespace BabyDev.Models
{
    using System;

    public class Question : DeletableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string AuthorId { get; set; }

        public virtual BabyDevUser Author { get; set; }

        public DateTime AskedOn { get; set; }

        public bool IsAnswered { get; set; }
    }
}
