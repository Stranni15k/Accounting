using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public interface ICityStorage
    {
        List<CityViewModel> GetFullList();
        List<CityViewModel> GetFilteredList(CitySearchModel model);
        CityViewModel? GetElement(CitySearchModel model);
        CityViewModel? Insert(CityBindingModel model);
        CityViewModel? Update(CityBindingModel model);
        CityViewModel? Delete(CityBindingModel model);
    }
}
