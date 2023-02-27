using Entities.Concretes;
using Entities.Dtos.Responses.AddressDtos;
using Entities.Dtos.Responses.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.DistrictDtos
{
    public class GetDistrictByIdResponse
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int? ParendDistrictId { get; set; }
        public string Name { get; set; }

        public GetAllCitiesResponse City { get; set; }
        public GetAllDistrictsResponse ParentDistrict { get; set; }
        public List<GetAllAddressesResponse> Addresses { get; set; }
        public List<GetAllDistrictsResponse> SubDistricts { get; set; }
    }
}
