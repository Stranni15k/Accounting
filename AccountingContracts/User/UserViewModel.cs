using AccountingDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public class UserViewModel : IUserModel
    {
        public string CityName { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string UserLoginAttempts { get; set; } = string.Empty;
        public int CityId { get; set; }
    }
}
