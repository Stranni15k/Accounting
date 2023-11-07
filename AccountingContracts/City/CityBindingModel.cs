using AccountingDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public class CityBindingModel : ICityModel
    {
        public int Id { get; set; }
        public string CityName { get; set; } = string.Empty;
    }
}
