﻿using System;
using BabyDev.Contracts;
using System.ComponentModel.DataAnnotations;

namespace BabyDev.Models
{
    public class Answer : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }

        public string AuthorId { get; set; }

        public virtual BabyDevUser Author { get; set; }
        
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public DateTime AnsweredOn { get; set; }
    }
}
