using BabyDev.Contracts;

namespace BabyDev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Topic : DeletableEntity
    {
        public Topic()
        {
            this.Paragraphs = new HashSet<Paragraph>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        
        public int RelatedMonths { get; set; }
        
        [Required]
        public string AuthorId { get; set; }

        public virtual BabyDevUser Author { get; set; }

        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
}
