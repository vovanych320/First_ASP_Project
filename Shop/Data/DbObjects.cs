using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Drug.Any())
            {
                content.AddRange(
                     new Medicines
                     {
                         description = "Кардіомагніл ­­– антитромботичний засіб на основі ацетилсаліцилової кислоти," +
                         " що відома своїми аналгетичними, жарознижувальними, протизапальними та антиагрегантними властивостями.",
                         producer = "ГмбХ 'Такеда', Австрія",
                         price = 68,
                         name = "Кардіомагніл",
                         doze = "150 мг",
                         volume ="30 табл" ,
                         img = "/img/pill.png",
                         available = true,
                         isFavorite = true,
                         Category = Categories["Серцево-сцудинні"]
                     }
                      
                    );
            }

            content.SaveChanges();
        }





       
     
       
        










        private static Dictionary<string, Category> cate;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(cate ==null)
                {
                    //Серцево-сцудинні, протизастудні, дерматологічні, вітаміни, 
                    //антибактеріальні, опорно-рухова система, стоматологічні, неврологічні
                    var list = new Category[]
                    {
                        new Category{name = "Серцево-сцудинні", description = "Ліки від серця"},
                        new Category{name = "Протизастудні", description = "Ліки від ГРВІ"},
                        new Category{name = "Дерматологічні", description = "Ліки при проблемах зі шкірою"},
                        new Category{name = "Вітаміни", description = "Нехватка вітамінів в організмі?"},
                        new Category{name = "Антибактеріальні", description = "Боротьба з інфекціями"},
                        new Category{name = "Опорно-рухова система", description = "Від болю в спині"},
                        new Category{name = "Стоматологічні", description = "Від болю в зубах"},
                        new Category{name = "Неврологічні", description = "Заспокойтесь і розслабтесь"}
                    };

                    cate = new Dictionary<string, Category>();
                    foreach(Category el in list)
                    {
                        cate.Add(el.name, el);
                    }
                }

                return cate;
            }
        }
    }
}
