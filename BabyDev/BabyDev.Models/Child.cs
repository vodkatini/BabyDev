using BabyDev.Contracts;

namespace BabyDev.Models
{
    using System;

    public class Child : DeletableEntity
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Born { get; set; }

        public Gender Gender { get; set; }

        public string ParentId { get; set; }

        public virtual  BabyDevUser Parent { get; set; }
    }
}
