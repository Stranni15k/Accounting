using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public interface IUserStorage
    {
        List<UserViewModel> GetFullList();
        List<UserViewModel> GetFilteredList(UserSearchModel model);
        UserViewModel? GetElement(UserSearchModel model);
        UserViewModel? Insert(UserBindingModel model);
        UserViewModel? Update(UserBindingModel model);
        UserViewModel? Delete(UserBindingModel model);
    }
}
