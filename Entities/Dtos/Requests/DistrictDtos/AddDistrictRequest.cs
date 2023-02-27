using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests.DistrictDtos
{
    public class AddDistrictRequest
    {
        public int CityId { get; set; }
        public int? ParendDistrictId { get; set; }
        public string Name { get; set; }
    }
}
