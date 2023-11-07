using AccountingContracts;
using AccountingDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingDataBaseImplemet.Models
{
    public class City : ICityModel
    {
        public int Id { get; private set; }

        [Required]
        public string CityName { get; private set; }

        [ForeignKey("CityId")]
        public virtual List<User> Users { get; set; } = new();

        [Required]
        public DateTime CreationDate { get; private set; }

        public static City? Create(CityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new City()
            {
                Id = model.Id,
                CityName = model.CityName,
            };
        }

        public void Update(CityBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            CityName = model.CityName;
        }
        public CityViewModel GetViewModel => new()
        {
            Id = Id,
            CityName = CityName,

        };
    }
}