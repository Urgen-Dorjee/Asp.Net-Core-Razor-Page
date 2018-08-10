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
using static Urgen.Website.Pages.Tech.IndexModel;

namespace Urgen.Website.Pages.Tech
{
    public class TechDetailModel : PageModel
    {
        private readonly IBlogRepository _repo;
        private readonly UserManager<User> _user;
        private readonly IMapper _map;
        private readonly ILogger _log;

        public TechDetailModel(IBlogRepository repo, UserManager<User> user, IMapper mapper, ILogger<TechDetailModel> logger)
        {
            _repo = repo;
            _user = user;
            _map = mapper;
            _log = logger;
        }

        
        public TechPost TechPost { get; set; }     
             

        public async Task<IActionResult> OnGetAsync(Guid TechId)
        {            
            TechPost = await _repo.GetTechPostForUser(TechId);
            if (TechPost == null)
            {
                return RedirectToPage("Index");
            }
            
           return Page();
        }

    }
}