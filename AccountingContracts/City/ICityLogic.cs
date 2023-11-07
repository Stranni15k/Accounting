using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public interface ICityLogic
    {
        List<CityViewModel>? ReadList(CitySearchModel? model);
        CityViewModel? ReadElement(CitySearchModel model);
        bool Create(CityBindingModel model);
        bool Update(CityBindingModel model);
        bool Delete(CityBindingModel model);
    }
}
