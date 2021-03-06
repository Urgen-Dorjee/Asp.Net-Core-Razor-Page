﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urgen.Website.Data.Entities;

namespace Urgen.Website.Data.DataService
{
    public class BlogDbContext : IdentityDbContext<User>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        { }
        public DbSet<TechPost> TechPosts { get; set; }
        public DbSet<TravelPost> TravelPosts { get; set; }
    }
}
