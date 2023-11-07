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
        string UserLoginAttempts { get; }
        int CityId { get; }
        DateTime CreationDate { get; }
    }
}