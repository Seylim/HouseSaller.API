using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
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

namespace Business.Concretes
{
    public class DistrictManager : IDistrictService
    {
        private readonly IDistrictRepository _repository;
        private readonly IMapper _mapper;

        public DistrictManager(IDistrictRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetDistrictByIdResponse>> AddDistrict(AddDistrictRequest request)
        {
            var district = _mapper.Map<District>(request);
            if (district.ParendDistrictId == null)
            {
                await _repository.AddAsync(district);
            }
            else
            {
                District parentDistrict = await _repository.GetByIdAsync(district.ParendDistrictId);
                parentDistrict.SubDistricts.Add(district);
                await _repository.UpdateAsync(parentDistrict);
            }
            var addedDistrict = _mapper.Map<GetDistrictByIdResponse>(district);
            return new SuccessDataResult<GetDistrictByIdResponse>(Messages.AddedDistrict, addedDistrict);
        }

        public async Task<IResult> DeleteDistrict(DistrictIdRequest request)
        {
            var district = _mapper.Map<District>(request);
            await _repository.DeleteAsync(district.Id);
            return new SuccessResult(Messages.DeletedDistrict);
        }

        public async Task<IDataResult<ICollection<GetAllDistrictsResponse>>> GetAllDistricts()
        {
            var districts = await _repository.GetAllAsync();
            var gettedDistricts = _mapper.Map<ICollection<GetAllDistrictsResponse>>(districts);
            return new SuccessDataResult<ICollection<GetAllDistrictsResponse>>(gettedDistricts);
        }

        public async Task<IDataResult<IList<GetAllDistrictsResponse>>> GetDistrictByCityIdAsync(CityIdRequest cityIdRequest)
        {
            var districts = await _repository.GetDistrictByCityIdAsync(cityIdRequest.Id);
            var gettedDistricts = _mapper.Map<IList<GetAllDistrictsResponse>>(districts);
            return new SuccessDataResult<IList<GetAllDistrictsResponse>>(gettedDistricts);
        }

        public async Task<IDataResult<GetDistrictByIdResponse>> GetDistrictById(DistrictIdRequest request)
        {
            var district = _mapper.Map<District>(request);
            var dbDistrict = await _repository.GetByIdAsync(district.Id);
            var gettedDistrict = _mapper.Map<GetDistrictByIdResponse>(dbDistrict);
            return new SuccessDataResult<GetDistrictByIdResponse>(gettedDistrict);
        }

        public async Task<IDataResult<GetDistrictByIdResponse>> GetDistrictByNameAsync(DistrictNameRequest request)
        {
            var districtRequest = _mapper.Map<District>(request);
            var district = await _repository.GetDistrictByNameAsync(districtRequest.Name);
            var gettedDistrict = _mapper.Map<GetDistrictByIdResponse>(district);
            return new SuccessDataResult<GetDistrictByIdResponse>(gettedDistrict);
        }

        public async Task<IDataResult<GetDistrictByIdResponse>> GetParentDistrictByDistrictIdAsync(DistrictIdRequest request)
        {
            var district = await _repository.GetParentDistrictByDistrictIdAsync(request.Id);
            var gettedDistrict = _mapper.Map<GetDistrictByIdResponse>(district);
            return new SuccessDataResult<GetDistrictByIdResponse>(gettedDistrict);
        }

        public async Task<IDataResult<IList<GetAllDistrictsResponse>>> GetSubDistrictsByDistrictIdAsync(DistrictIdRequest request)
        {
            var districts = await _repository.GetSubDistrictsByDistrictIdAsync(request.Id);
            var gettedDistricts = _mapper.Map<IList<GetAllDistrictsResponse>>(districts);
            return new SuccessDataResult<IList<GetAllDistrictsResponse>>(gettedDistricts);
        }

        public async Task<IDataResult<GetDistrictByIdResponse>> UpdateDistrict(UpdateDistrictRequest request)
        {

            var district = await _repository.GetByIdAsync(request.Id);
            if (district != null)
            {
                district = _mapper.Map<District>(request);
                var updatedDistrict = await _repository.UpdateAsync(district);
                var mappedDistrict = _mapper.Map<GetDistrictByIdResponse>(updatedDistrict);
                return new SuccessDataResult<GetDistrictByIdResponse>(Messages.UpdatedDistrict, mappedDistrict);
            }
            return new ErrorDataResult<GetDistrictByIdResponse>(Messages.DistrictNotFound, null);
        }
    }
}
