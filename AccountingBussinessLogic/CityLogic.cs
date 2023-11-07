using AccountingContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBussinessLogic
{
    public class CityLogic : ICityLogic
    {
        private readonly ICityStorage _CityStorage;
        public CityLogic(ICityStorage CityStorage)
        {
            _CityStorage = CityStorage;
        }
        public List<CityViewModel>? ReadList(CitySearchModel? model)
        {
            var list = model == null ? _CityStorage.GetFullList() : _CityStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }
        public CityViewModel? ReadElement(CitySearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _CityStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }
        public bool Create(CityBindingModel model)
        {
            CheckModel(model);
            if (_CityStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(CityBindingModel model)
        {
            CheckModel(model, false);


            if (_CityStorage.Delete(model) == null)
            {
                return false;
            }

            return true;
        }
        public bool Update(CityBindingModel model)
        {
            CheckModel(model);
            if (_CityStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(CityBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.CityName))
            {
                throw new ArgumentNullException("Нет названия города", nameof(model.CityName));
            }

            var element = _CityStorage.GetElement(new CitySearchModel
            {
                CityName = model.CityName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Пользователь с таким логином уже есть");
            }
        }
    }
}
