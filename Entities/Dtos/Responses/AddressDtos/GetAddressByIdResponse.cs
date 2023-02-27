using Entities.Concretes;
using Entities.Dtos.Responses.AdDtos;
using Entities.Dtos.Responses.CityDtos;
using Entities.Dtos.Responses.DistrictDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.AddressDtos
{
    public class GetAddressByIdResponse
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int SubDistrictId { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }

        public GetCityByIdResponse City { get; set; }
        public GetDistrictByIdResponse SubDistrict { get; set; }
        public List<GetAllAdsResponse> Ads { get; set; }
    }
}
