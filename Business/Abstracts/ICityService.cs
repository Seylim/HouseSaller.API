using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.CityDtos;
using Entities.Dtos.Responses.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICityService
    {
        Task<IDataResult<GetCityByIdResponse>> AddCity(AddCityRequest request);
        Task<IDataResult<GetCityByIdResponse>> UpdateCity(UpdateCityRequest request);
        Task<IResult> DeleteCity(CityIdRequest request);
        Task<IDataResult<ICollection<GetAllCitiesResponse>>> GetAllCities();
        Task<IDataResult<GetCityByIdResponse>> GetCityById(CityIdRequest request);
        Task<IDataResult<GetCityByIdResponse>> GetCityByNameAsync(CityNameRequest request);
    }
}
