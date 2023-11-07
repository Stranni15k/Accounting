using AccountingDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingContracts
{
    public class CityViewModel:ICityModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string CityName { get; set; } = string.Empty;
    }
}
