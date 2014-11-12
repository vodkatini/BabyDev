using BabyDev.Contracts;

namespace BabyDev.Models
{
    using System;

    using System.ComponentModel.DataAnnotations;

    public class Paragraph : DeletableEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string Subtitle { get; set; }
        
        public string Content { get; set; }

        public virtual Topic Topic { get; set; }

        public int TopicId { get; set; }
    }
}
