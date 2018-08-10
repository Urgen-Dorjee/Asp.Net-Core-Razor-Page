using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Urgen.Website.Data.DataService;
using Urgen.Website.Data.Entities;

namespace Urgen.Website.Pages.Travel
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

        public IList<TravelPost> TravelPosts { get; set; }
        public bool HasTravelPost => TravelPosts.Count > 0;
        public async Task<IActionResult> OnGetAsync()
        {

            TravelPosts = await _repo.ShowAllTravelPostsForUser();
            return Page();

        }

    }
}
