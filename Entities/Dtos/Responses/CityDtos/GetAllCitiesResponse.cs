using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.CityDtos
{
    public class GetAllCitiesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberPlate { get; set; }
        public int TelephoneCode { get; set; }
    }
}
