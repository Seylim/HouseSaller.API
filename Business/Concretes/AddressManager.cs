using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.AddressDtos;
using Entities.Dtos.Responses.AddressDtos;
using Entities.Dtos.Responses.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;
        public AddressManager(IAddressRepository repository, IMapper mapper)
        {
            _repository= repository;
            _mapper= mapper;
        }

        public async Task<IDataResult<GetAddressByIdResponse>> AddAddress(AddAddressRequest request)
        {
            var address = _mapper.Map<Address>(request);
            await _repository.AddAsync(address);
            var addedAddress = _mapper.Map<GetAddressByIdResponse>(address);
            return new SuccessDataResult<GetAddressByIdResponse>(Messages.AddedAddress, addedAddress);
        }

        public async Task<IResult> DeleteAddress(AddressIdRequest request)
        {
            var address = _mapper.Map<Address>(request);
            await _repository.DeleteAsync(address.Id);
            return new SuccessResult(Messages.DeletedAddress);
        }

        public async Task<IDataResult<GetAddressByIdResponse>> GetAddressById(AddressIdRequest request)
        {
            var address = _mapper.Map<Address>(request);
            var dbAddress = await _repository.GetByIdAsync(address.Id);
            var gettedAddress = _mapper.Map<GetAddressByIdResponse>(dbAddress);
            return new SuccessDataResult<GetAddressByIdResponse>(gettedAddress);
        }

        public async Task<IDataResult<IList<GetAllAddressesResponse>>> GetAddressesByIsActiveAsync()
        {
            var addresses = await _repository.GetAddressesByIsActiveAsync();
            var gettedAddresses = _mapper.Map<IList<GetAllAddressesResponse>>(addresses);
            return new SuccessDataResult<IList<GetAllAddressesResponse>>(gettedAddresses);
        }

        public async Task<IDataResult<ICollection<GetAllAddressesResponse>>> GetAllAddresses()
        {
            var addresses = await _repository.GetAllAsync();
            var gettedAddresses = _mapper.Map<ICollection<GetAllAddressesResponse>>(addresses);
            return new SuccessDataResult<ICollection<GetAllAddressesResponse>>(gettedAddresses);
        }

        public async Task<IDataResult<GetAddressByIdResponse>> UpdateAddress(UpdateAddressRequest request)
        {

            var address = await _repository.GetByIdAsync(request.Id);
            if (address != null)
            {
                address = _mapper.Map<Address>(request);
                var updatedAddress = await _repository.UpdateAsync(address);
                var mappedAddress = _mapper.Map<GetAddressByIdResponse>(updatedAddress);
                return new SuccessDataResult<GetAddressByIdResponse>(Messages.UpdatedAddress, mappedAddress);
            }
            return new ErrorDataResult<GetAddressByIdResponse>(Messages.AddressNotFound, null);
        }
    }
}
