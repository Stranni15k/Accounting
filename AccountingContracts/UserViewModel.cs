using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; } = string.Empty;
        [DisplayName("Предупреждение")]
        public List<DateTime> LastLoginAttempts { get; set; }
        [DisplayName("Города проживания")]
        public List<string> CityOptions { get; set; }
        [DisplayName("Дата создания аккаунта")]
        public DateTime CreationDate { get; set; }
    }
}
