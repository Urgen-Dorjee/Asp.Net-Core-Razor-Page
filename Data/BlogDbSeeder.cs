using Blog.Data.DataService;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class BlogDbSeeder
    {
        private readonly BlogDbContext _ctx;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<User> _userManager;

        public BlogDbSeeder(BlogDbContext ctx, IHostingEnvironment env, UserManager<User> userManager)
        {
            _ctx = ctx;
            _env = env;
            _userManager = userManager;
        }
        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("urgen0240@gmail.com");
            var user1 = await _userManager.FindByEmailAsync("taykorksang@yahoo.com");

            if (user == null)
            {
                user = new User()
                {
                    FirstName = "Urgen",
                    LastName = "Dorjee",
                    UserName = "urgen0240@gmail.com",
                    Email = "urgen0240@gmail.com"
                };

                user1 = new User()
                {
                    FirstName = "Kalsang",
                    LastName = "Nyima",
                    UserName = "taykorksang",
                    Email = "taykorksang@yahoo.com"
                };
                var result1 = await _userManager.CreateAsync(user1, "Passw0rd!");
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if (result1 != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create a default user");
                }

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create a default user");
                }
            }
            if (!_ctx.TechPosts.Any())
            {
                var post = new TechPost()
                {
                    Title = "Asp.Net Core 2.1 Road Map",
                    Description = "Microsoft started to ship Asp.Net way back in early 2000 and since then it has been matured quite significantly,it has not much room left to ramp up, therefore the have started to build Asp.Net core from the scratch",
                    PostCreatedDate = DateTime.Now,
                    User = user
                };
                var post1 = new TechPost()
                {
                    Title = "MS Build 2018 Redmond Washington",
                    Description = "Microsoft instroduced Signal R in Asp.Net Core 2.1",
                    PostCreatedDate = DateTime.Now,
                    User = user,

                };
                var post2 = new TechPost()
                {
                    Title = "WASM with Blazor",
                    Description = "It is a great opportunity to a new developer, who can learn new technology that Microsoft come up with.",
                    PostCreatedDate = DateTime.Now,
                    User = user1
                };
                _ctx.TechPosts.AddRange(post);
                _ctx.TechPosts.AddRange(post1);
                _ctx.TechPosts.AddRange(post2);


                _ctx.SaveChanges();
            }

            if (!_ctx.TravelPosts.Any())
            {
                var travel = new TravelPost()
                {

                    Title = "Ravangla Road Trip 2018",
                    Description = "I have been to this place many times since it is my home town, however i have been moved to different place now but what used to be look and feel of this place has been completely overhaul and sometimes feel that I find myself in different place",
                    PostCreatedDate = DateTime.Now,
                    User = user
                };

                var travel1 = new TravelPost()
                {
                    Title = "His Holiness Birthday Celebration",
                    Description = "It is a great pride and auspicious occasion that Tibetan all over the world Celebrate the living embodiment of Avalokiteshwara HH the Dalai Lama birthday, We all tibetan feel undue of his relentless,tireless effort to keep the flame of tibet independence around the world arena.The man of peace is not only love by Tibetan but by most of the countries",
                    PostCreatedDate = DateTime.Now,
                    User = user1
                };
                _ctx.TravelPosts.AddRange(travel);
                _ctx.TravelPosts.AddRange(travel1);
                _ctx.SaveChanges();
            }

        }
    }
}
