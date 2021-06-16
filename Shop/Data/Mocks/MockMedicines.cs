using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockMedicines : IMedicines
    {
        private readonly ICategory _categoryDrugs = new MockCategory();

        public IEnumerable<Medicines> drugs
        {
            get
            {
                return new List<Medicines>
                {
                    new Medicines
                    {
                        description = "Кардіомагніл ­­– антитромботичний засіб на основі ацетилсаліцилової кислоти," +
                         " що відома своїми аналгетичними, жарознижувальними, протизапальними та антиагрегантними властивостями.",
                        producer = "ГмбХ 'Такеда', Австрія",
                        price = 12,
                        name = "трикардин",
                        doze = "45",
                        volume = "150",
                        img = "/img/drugImg/kardiomagnil.jpg",
                        available = true,
                        isFavorite = true,
                        Category = _categoryDrugs.AllCategories.First()
                    }
                };
            }
        }

        public IEnumerable<Medicines> getFavDrugs { get; set; }

        public Medicines getDrug(int drugId)
        {
            throw new NotImplementedException();
        }
    }
}
