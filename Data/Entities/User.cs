using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Entities
{
    public class User : IdentityUser
    {
        [Required, MaxLength(20, ErrorMessage = "First Name should not exceed more than 20 characters")]
        public string FirstName { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Last Name should not exceed more than 20 characters")]
        public string LastName { get; set; }
        public ICollection<TechPost> TechPosts { get; set; }
                           = new List<TechPost>();
        public ICollection<TravelPost> TravelPosts { get; set; }
                          = new List<TravelPost>();
    }
}
