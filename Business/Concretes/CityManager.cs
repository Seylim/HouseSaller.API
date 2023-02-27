using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.CityDtos;
using Entities.Dtos.Responses.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CityManager : ICityService
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityManager(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetCityByIdResponse>> AddCity(AddCityRequest request)
        {
            var city = _mapper.Map<City>(request);
            var dbCity = await _repository.AddAsync(city);
            var addedCity = _mapper.Map<GetCityByIdResponse>(dbCity);
            return new SuccessDataResult<GetCityByIdResponse>(Messages.AddedCity, addedCity);
        }

        public async Task<IResult> DeleteCity(CityIdRequest request)
        {
            var city = await _repository.GetByIdAsync(request.Id);
            if (city != null)
            {
                await _repository.DeleteAsync(city.Id);
            }
            return new SuccessResult(Messages.DeletedCity);
        }

        public async Task<IDataResult<ICollection<GetAllCitiesResponse>>> GetAllCities()
        {
            var cities = await _repository.GetAllAsync();
            var gettedCities = _mapper.Map<ICollection<GetAllCitiesResponse>>(cities);
            return new SuccessDataResult<ICollection<GetAllCitiesResponse>>(gettedCities);
        }

        public async Task<IDataResult<GetCityByIdResponse>> GetCityById(CityIdRequest request)
        {
            var city = _mapper.Map<City>(request);
            var dbCity = await _repository.GetByIdAsync(city.Id);
            var gettedCity = _mapper.Map<GetCityByIdResponse>(dbCity);
            return new SuccessDataResult<GetCityByIdResponse>(gettedCity);
        }

        public async Task<IDataResult<GetCityByIdResponse>> GetCityByNameAsync(CityNameRequest request)
        {
            var cityRequest = _mapper.Map<City>(request);
            var city = await _repository.GetCityByNameAsync(cityRequest.Name);
            var gettedCity = _mapper.Map<GetCityByIdResponse>(city);
            return new SuccessDataResult<GetCityByIdResponse>(gettedCity);
        }

        public async Task<IDataResult<GetCityByIdResponse>> UpdateCity(UpdateCityRequest request)
        {
            var city = await _repository.GetByIdAsync(request.Id);
            if (city != null)
            {
                city = _mapper.Map<City>(request);
                var updatedCity = await _repository.UpdateAsync(city);
                var mappedCity = _mapper.Map<GetCityByIdResponse>(updatedCity);
                return new SuccessDataResult<GetCityByIdResponse>(Messages.UpdatedCity, mappedCity);
            }
            return new ErrorDataResult<GetCityByIdResponse>(Messages.CityNotFound, null);
        }
    }
}
