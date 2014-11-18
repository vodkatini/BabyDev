namespace BabyDev.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BabyDev.Contracts;

    using System;

    public class Question : DeletableEntity
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Body { get; set; }

        public string AuthorId { get; set; }

        public virtual BabyDevUser Author { get; set; }

        public bool IsAnswered { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
