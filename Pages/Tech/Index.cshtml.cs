using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Urgen.Website.Data.DataService;
using Urgen.Website.Data.Entities;
using Urgen.Website.Dto;

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
        
        public string Message { get; set; }
        public bool HasTechPost { get; set; }
        public IActionResult OnGet()
        {

            var TechPostsFromRepo = _repo.ShowAllTechPostsForUser();
            if(TechPostsFromRepo.Count > 0)
            {
                HasTechPost = true;
            }
            else
            {
                HasTechPost = false;
            }
            var TechPosts = _map.Map<IEnumerable<TechPostDto>>(TechPostsFromRepo);
            return Page();
       
        }

        

        public class TechPostDto : TTGetPostsDto
        {
            public Guid TechId { get; set; }           

        } 
        

    }
}