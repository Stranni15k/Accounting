using AccountingContracts;
using AccountingDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingDataBaseImplemet.Models
{
    public class User : IUserModel
    {
        public int Id { get; private set; }

        [Required]
        public string Login { get; private set; }

        public List<LoginAttempt> LoginAttempts { get; set; }

        [Required]
        public List<string> CityOptions { get; private set; }

        [Required]
        public DateTime CreationDate { get; private set; }

        public User()
        {
            Login = string.Empty;
            LoginAttempts = new List<LoginAttempt>();
            CityOptions = new List<string>();
            CreationDate = DateTime.Now;
        }

        public static User? Create(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new User()
            {
                Id = model.Id,
                Login = model.Login,
                LoginAttempts = model.LoginAttempts,
                CityOptions = model.CityOptions,
                CreationDate = model.CreationDate
            };
        }

        public void Update(UserBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            Login = model.Login;
            LoginAttempts = model.LoginAttempts;
            CityOptions = model.CityOptions;
            CreationDate = model.CreationDate;
        }

        public UserViewModel GetViewModel()
        {
            return new UserViewModel
            {
                Id = Id,
                Login = Login,
                LoginAttempts = LoginAttempts,
                CityOptions = CityOptions,
                CreationDate = CreationDate
            };
        }
    }
}
