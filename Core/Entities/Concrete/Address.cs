using Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Address : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        public int SubDistrictId { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }

        public virtual City City { get; set; }
        public virtual District SubDistrict { get; set; }
        public virtual List<Ad> Ads { get; set; }
    }
}
