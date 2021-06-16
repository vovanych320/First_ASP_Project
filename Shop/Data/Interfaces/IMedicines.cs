using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IMedicines
    {
        IEnumerable<Medicines> drugs { get; }//todo set;
        IEnumerable<Medicines> getFavDrugs { get; }//todo set;
        Medicines getDrug(int drugId);
    }
}
