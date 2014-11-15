using System.ComponentModel.DataAnnotations;
using BabyDev.Contracts;

namespace BabyDev.Models
{
    using System;

    public class Question : DeletableEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Body { get; set; }

        public string AuthorId { get; set; }

        public virtual BabyDevUser Author { get; set; }

        public bool IsAnswered { get; set; }
    }
}
