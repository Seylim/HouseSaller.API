using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.CityDtos;
using Entities.Dtos.Requests.DistrictDtos;
using Entities.Dtos.Responses.CityDtos;
using Entities.Dtos.Responses.DistrictDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IDistrictService
    {
        Task<IDataResult<GetDistrictByIdResponse>> AddDistrict(AddDistrictRequest request);
        Task<IDataResult<GetDistrictByIdResponse>> UpdateDistrict(UpdateDistrictRequest request);
        Task<IResult> DeleteDistrict(DistrictIdRequest request);
        Task<IDataResult<ICollection<GetAllDistrictsResponse>>> GetAllDistricts();
        Task<IDataResult<GetDistrictByIdResponse>> GetDistrictById(DistrictIdRequest request);
        Task<IDataResult<GetDistrictByIdResponse>> GetDistrictByNameAsync(DistrictNameRequest request);
        Task<IDataResult<IList<GetAllDistrictsResponse>>> GetDistrictByCityIdAsync(CityIdRequest cityIdRequest);
        Task<IDataResult<GetDistrictByIdResponse>> GetParentDistrictByDistrictIdAsync(DistrictIdRequest request);
        Task<IDataResult<IList<GetAllDistrictsResponse>>> GetSubDistrictsByDistrictIdAsync(DistrictIdRequest request);
    }
}
