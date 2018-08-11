using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Urgen.Website.Data.DataService;
using Urgen.Website.Data.Entities;

namespace Urgen.Website.Pages.Travel
{
    public class TravelDetailModel : PageModel
    {
        private readonly IBlogRepository _repo;

        public TravelPost TravelPost { get; set; }

        public TravelDetailModel(IBlogRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> OnGetAsync(Guid TravelId)
        {

            TravelPost = await _repo.GetTravelPostForUser(TravelId);
            if (TravelPost == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}