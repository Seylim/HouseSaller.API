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
    public class District : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CityId { get; set; }
        public int? ParendDistrictId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
        public virtual District ParentDistrict { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public virtual List<District> SubDistricts { get; set; }
    }
}
