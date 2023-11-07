using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingDataModels.Models
{
    public interface ICityModel : IId
    {
        string CityName { get; }
    }
}