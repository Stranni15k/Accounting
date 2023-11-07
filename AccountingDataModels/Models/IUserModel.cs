using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingDataModels.Models
{
    public interface IUserModel : IId
    {
        string Login { get; }
        List<das> LoginAttempts { get; }
        List<string> CityOptions { get; }
        DateTime CreationDate { get; }
    }
}
    