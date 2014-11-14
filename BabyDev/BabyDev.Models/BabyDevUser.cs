using System.Collections.Generic;

namespace BabyDev.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BabyDevUser : IdentityUser
    {
        public BabyDevUser()
        {
            this.Answers = new HashSet<Answer>();
            this.Children = new HashSet<Child>();
            this.Paragraphs = new HashSet<Paragraph>();
            this.Questions = new HashSet<Question>();
            this.Topics = new HashSet<Topic>();
        }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<Child> Children { get; set; }

        public virtual ICollection<Paragraph> Paragraphs { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<BabyDevUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
