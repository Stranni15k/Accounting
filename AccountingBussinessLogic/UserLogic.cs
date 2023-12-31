﻿using AccountingContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBussinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserStorage _userStorage;
        public UserLogic(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }
        public List<UserViewModel>? ReadList(UserSearchModel? model)
        {
            var list = model == null ? _userStorage.GetFullList() : _userStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }
        public UserViewModel? ReadElement(UserSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _userStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }
        public bool Create(UserBindingModel model)
        {
            CheckModel(model);
            if (_userStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(UserBindingModel model)
        {
            CheckModel(model, false);

            if (_userStorage.Delete(model) == null)
            {
                return false;
            }

            return true;
        }
        public bool Update(UserBindingModel model)
        {
            CheckModel(model);
            if (_userStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(UserBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.Login))
            {
                throw new ArgumentNullException("Нет логина оператора", nameof(model.Login));
            }

            var element = _userStorage.GetElement(new UserSearchModel
            {
                Login = model.Login
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Пользователь с таким логином уже есть");
            }
        }
    }
}
