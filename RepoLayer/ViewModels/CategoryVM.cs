﻿using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; } = new Category();

        public IEnumerable<Category> categories { get; set; } = new List<Category>();
    }
}
