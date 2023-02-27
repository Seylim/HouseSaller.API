using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests.CityDtos
{
    public class AddCityRequest
    {
        public string Name { get; set; }
        public int NumberPlate { get; set; }
        public int TelephoneCode { get; set; }
    }
}
