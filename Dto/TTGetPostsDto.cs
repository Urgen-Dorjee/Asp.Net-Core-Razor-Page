﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urgen.Website.Dto
{
    public class TTGetPostsDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostCreatedDate { get; set; }
    }
}
