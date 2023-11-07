using AccountingContracts;
using AccountingDataBaseImplemet.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingDataBaseImplemet.Implements
{
    public class UserStorage : IUserStorage
    {
        public List<UserViewModel> GetFullList()
        {
            using var context = new AccountingDatabase();
            return context.Users
                .Include(x => x.City)
            .Select(x => x.GetViewModel)
           .ToList();
        }
        public List<UserViewModel> GetFilteredList(UserSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Login))
            {
                return new();
            }
            using var context = new AccountingDatabase();
            return context.Users
              .Include(x => x.City)
            .Where(x => x.Login.Contains(model.Login))
           .Select(x => x.GetViewModel)
           .ToList();
        }
        public UserViewModel? GetElement(UserSearchModel model)
        {

            using var context = new AccountingDatabase();
            return context.Users
                .Include(x => x.City)
            .FirstOrDefault(x =>
           (!string.IsNullOrEmpty(model.Login) && x.Login == model.Login) ||
            (x.Id == model.Id))?.GetViewModel;
        }
        public UserViewModel? Insert(UserBindingModel model)
        {
            var newUser = User.Create(model);
            if (newUser == null)
            {
                return null;
            }
            using var context = new AccountingDatabase();
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser.GetViewModel;
        }
        public UserViewModel? Update(UserBindingModel model)
        {
            using var context = new AccountingDatabase();
            var user = context.Users
                .Include(x => x.City).FirstOrDefault(x => x.Id == model.Id);
            if (user == null)
            {
                return null;
            }
            user.Update(model);
            context.SaveChanges();
            return user.GetViewModel;
        }
        public UserViewModel? Delete(UserBindingModel model)
        {
            using var context = new AccountingDatabase();
            var element = context.Users.Include(x => x.City).FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Users.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
