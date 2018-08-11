using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urgen.Website.Data.Entities;

namespace Urgen.Website.Data.DataService
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ILogger<BlogRepository> _logger;
        private readonly BlogDbContext _ctx;
        private readonly UserManager<User> _user;

        public BlogRepository(ILogger<BlogRepository> logger, BlogDbContext ctx, UserManager<User> user)
        {
            _logger = logger;
            _ctx = ctx;
            _user = user;
        }

        public async Task<IList<TechPost>> ShowAllTechPostsForUser()
        {
            return await _ctx.TechPosts.Include(x => x.User).OrderBy(u => u.PostCreatedDate).ToListAsync();
        }
        public async Task<TechPost> GetTechPostForUser(Guid techId)
        {
            return await _ctx.TechPosts.Include(x => x.User).Where(t => t.TechId == techId).FirstOrDefaultAsync();
         
        }
        public void AddTechBlogPost(string UserId, TechPost TPost)
        {
            var user = GetUser(UserId);
            if (user != null)
            {
                if (TPost.TechId == Guid.Empty)
                {
                    TPost.TechId = Guid.NewGuid();
                }
                user.TechPosts.Add(TPost);
            }
        }
        public void DeleteTechPost(TechPost TPost)
        {
            _ctx.TechPosts.Remove(TPost);
        }
        public void UpdateTechPostForUser(TechPost TPost)
        {
            //no code in this implementation..
        }

        public async Task<IList<TravelPost>> ShowAllTravelPostsForUser()
        {
            return await _ctx.TravelPosts
                       .Include(x => x.User)
                       .OrderBy(u => u.PostCreatedDate)
                       .ToListAsync();
        }
        public async Task<TravelPost> GetTravelPostForUser(Guid Tid)
        {
            return await _ctx.TravelPosts
                       .Include(u => u.User)
                       .Where(t => t.TravelId == Tid).FirstOrDefaultAsync();
        }
        public void AddTravelBlogPost(TravelPost TPost)
        {


            if (TPost.TravelId == Guid.Empty)
            {
                TPost.TravelId = Guid.NewGuid();
            }
            _ctx.TravelPosts.Add(TPost);
        }

        public void DeleteTravelPost(TravelPost TPost)
        {
            _ctx.TravelPosts.Remove(TPost);
        }
        public void UpdateTravelPostForUser(TravelPost TPost)
        {
            //no code in this implementation..
        }


        public User GetUser(string UserId)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == UserId);

        }
        public IList<User> GetUsers()
        {
            var user = _user.Users
                        .OrderBy(a => a.FirstName)
                        .ThenBy(a => a.LastName)
                        .ToList();
            return (user);

        }
        public bool UserExists(string UserName)
        {
            return _ctx.Users.Any(u => u.UserName == UserName);
        }
        public void AddUser(User user)
        {

            _ctx.Users.Add(user);

            if (user.TechPosts.Any())
            {
                foreach (var Post in user.TechPosts)
                {
                    Post.TechId = Guid.NewGuid();
                }
            }
            if (user.TravelPosts.Any())
            {
                foreach (var Post in user.TravelPosts)
                {
                    Post.TravelId = Guid.NewGuid();
                }
            }
        }
        public void DeleteUser(User user)
        {
            _ctx.Users.Remove(user);
        }

        public bool Save()
        {
            return (_ctx.SaveChanges() >= 0);
        }


    }
}
