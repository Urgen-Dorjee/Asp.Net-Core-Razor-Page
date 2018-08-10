using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Urgen.Website.Data.DataService;
using Urgen.Website.Data.Entities;

namespace Urgen.Website.Pages.Tech
{
    public class IndexModel : PageModel
    {
        private readonly IBlogRepository _repo;
        private readonly UserManager<User> _user;
        private readonly IMapper _map;

        public IndexModel(IBlogRepository repo, UserManager<User> user, IMapper mapper)
        {
            _repo = repo;
            _user = user;
            _map = mapper;
        }
        
        public IList<TechPost> TechPosts { get; set; }   
        public bool HasTechPost => TechPosts.Count > 0;
        public async Task<IActionResult> OnGetAsync()
        {

            TechPosts = await _repo.ShowAllTechPostsForUser();    
            return Page();
       
        }                

    }
}