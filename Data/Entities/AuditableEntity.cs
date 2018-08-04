using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Entities
{
    public class AuditableEntity
    {
        [Required(ErrorMessage = "You cannot leave Title of the Post blank")]
        [MaxLength(100, ErrorMessage = "The Max length of the Title should not exceed more than 100 characters")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime PostCreatedDate { get; set; }
        public User User { get; set; }
    }
}
