using Entities.Concretes;
using Entities.Dtos.Responses.AddressDtos;
using Entities.Dtos.Responses.DistrictDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.CityDtos
{
    public class GetCityByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberPlate { get; set; }
        public int TelephoneCode { get; set; }

        public List<GetAllAddressesResponse> Addresses { get; set; }
        public List<GetAllDistrictsResponse> Districts { get; set; }
    }
}
