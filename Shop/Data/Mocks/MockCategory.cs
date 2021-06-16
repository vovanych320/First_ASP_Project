using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{name = "Серцево-сцудинні", description = "Ліки від болю в серці"},
                     new Category{name = "Протизастудні", description = "Ліки від застуди"}
                };
            }
        }
    }
}
