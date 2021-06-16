using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent app)
        {
            this.appDBContent = app;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
