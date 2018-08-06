using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urgen.Website.Data.Entities;

namespace Urgen.Website.Data.DataService
{
    public interface IBlogRepository
    {
        IList<TechPost> ShowAllTechPostsForUser();
        TechPost GetTechPostForUser(Guid techId);
        void AddTechBlogPost(string UserId, TechPost TPost);
        void DeleteTechPost(TechPost TPost);
        void UpdateTechPostForUser(TechPost TPost);

        IList<TravelPost> ShowAllTravelPostsForUser();
        TravelPost GetTravelPostForUser(Guid id);
        void AddTravelBlogPost(TravelPost TPost);
        void DeleteTravelPost(TravelPost TPost);
        void UpdateTravelPostForUser(TravelPost TPost);

        IList<User> GetUsers();
        bool UserExists(string UserName);
        void AddUser(User user);
        User GetUser(string UserId);
        void DeleteUser(User user);



        bool Save();
    }
}
