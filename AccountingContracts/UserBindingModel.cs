using AccountingDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public class UserBindingModel : IUserModel
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public List<DateTime> LoginAttempts { get; set; }
        public List<string> CityOptions { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
