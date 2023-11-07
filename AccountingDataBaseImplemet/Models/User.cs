using AccountingContracts;
using AccountingDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
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
        [Required]
        public string UserLoginAttempts { get; private set; }

        [Required]
        public int CityId { get; private set; }
        public virtual City City { get; set; }

        [Required]
        public DateTime CreationDate { get; private set; }

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
                CityId = model.CityId,
                CreationDate = model.CreationDate,
                UserLoginAttempts = model.UserLoginAttempts
            };
        }
        public void Update(UserBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Login = model.Login;
            CityId = model.CityId;
            UserLoginAttempts = UserLoginAttempts;
        }
        public UserViewModel GetViewModel => new()
        {
            Id = Id,
            Login = Login,
            CityId = CityId,
            CityName = City?.CityName,
            CreationDate = CreationDate,
            UserLoginAttempts = UserLoginAttempts

        };
    }
}