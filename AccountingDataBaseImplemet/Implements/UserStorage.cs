using AccountingContracts;
using AccountingDataBaseImplemet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingDataBaseImplemet.Implements
{
    public class UserStorage : IUserStorage
    {
        public List<UserViewModel> GetFullList()
        {
            using var context = new AccountingDatabase();
            return context.Users
                .Select(x => x) // Select all columns from the database
                .AsEnumerable() // Switch to in-memory operations
                .Select(x => x.GetViewModel())
                .ToList();
        }

        public List<UserViewModel> GetFilteredList(UserSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Login))
            {
                return new List<UserViewModel>();
            }

            using var context = new AccountingDatabase();
            return context.Users
                .Where(x => x.Login.Contains(model.Login))
                .Select(x => x)
                .AsEnumerable()
                .Select(x => x.GetViewModel())
                .ToList();
        }

        public UserViewModel? GetElement(UserSearchModel model)
        {
            using var context = new AccountingDatabase();
            return context.Users
                .FirstOrDefault(x =>
                    (!string.IsNullOrEmpty(model.Login) && x.Login == model.Login) ||
                    (x.Id == model.Id))
                ?.GetViewModel();
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
            return newUser.GetViewModel();
        }

        public UserViewModel? Update(UserBindingModel model)
        {
            using var context = new AccountingDatabase();
            var user = context.Users.FirstOrDefault(x => x.Id == model.Id);
            if (user == null)
            {
                return null;
            }
            user.Update(model);
            context.SaveChanges();
            return user.GetViewModel();
        }

        public UserViewModel? Delete(UserBindingModel model)
        {
            using var context = new AccountingDatabase();
            var element = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Users.Remove(element);
                context.SaveChanges();
                return element.GetViewModel();
            }
            return null;
        }
    }
}
