using AccountingContracts;
using AccountingDataBaseImplemet.Models;
using System.Data;

namespace AccountingDataBaseImplemet.Implements
{
    public class CityStorage : ICityStorage
    {
        public List<CityViewModel> GetFullList()
        {
            using var context = new AccountingDatabase();
            return context.Citys
            .Select(x => x.GetViewModel)
           .ToList();
        }
        public List<CityViewModel> GetFilteredList(CitySearchModel model)
        {
            if (string.IsNullOrEmpty(model.CityName))
            {
                return new();
            }
            using var context = new AccountingDatabase();
            return context.Citys
            .Where(x => x.CityName.Contains(model.CityName))
           .Select(x => x.GetViewModel)
           .ToList();
        }
        public CityViewModel? GetElement(CitySearchModel model)
        {
            using var context = new AccountingDatabase();
            return context.Citys
            .FirstOrDefault(x =>
           (!string.IsNullOrEmpty(model.CityName) && x.CityName == model.CityName) ||
            (model.Id != null && x.Id == model.Id))?.GetViewModel;
        }
        public CityViewModel? Insert(CityBindingModel model)
        {
            var newCity = City.Create(model);
            if (newCity == null)
            {
                return null;
            }
            using var context = new AccountingDatabase();
            context.Citys.Add(newCity);
            context.SaveChanges();
            return newCity.GetViewModel;
        }
        public CityViewModel? Update(CityBindingModel model)
        {
            using var context = new AccountingDatabase();
            var City = context.Citys.FirstOrDefault(x => x.Id == model.Id);
            if (City == null)
            {
                return null;
            }
            City.Update(model);
            context.SaveChanges();
            return City.GetViewModel;
        }
        public CityViewModel? Delete(CityBindingModel model)
        {
            using var context = new AccountingDatabase();
            var element = context.Citys.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Citys.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
