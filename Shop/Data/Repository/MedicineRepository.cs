using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Repository
{
    public class MedicineRepository : IMedicines
    {
        private readonly AppDBContent appDBContent;

        public MedicineRepository(AppDBContent app)
        {
            this.appDBContent = app;
        }

        public IEnumerable<Medicines> drugs => appDBContent.Drug.Include(c => c.Category);

        public IEnumerable<Medicines> getFavDrugs => appDBContent.Drug.Where(p => p.isFavorite).Include(c => c.Category);

        public Medicines getDrug(int drugId) => appDBContent.Drug.FirstOrDefault(p => p.id == drugId); 
        
    }
}
