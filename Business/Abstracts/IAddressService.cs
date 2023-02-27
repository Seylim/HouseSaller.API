using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.AddressDtos;
using Entities.Dtos.Responses.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAddressService
    {
        Task<IDataResult<GetAddressByIdResponse>> AddAddress(AddAddressRequest request);
        Task<IDataResult<GetAddressByIdResponse>> UpdateAddress(UpdateAddressRequest request);
        Task<IResult> DeleteAddress(AddressIdRequest request);
        Task<IDataResult<ICollection<GetAllAddressesResponse>>> GetAllAddresses();
        Task<IDataResult<GetAddressByIdResponse>> GetAddressById(AddressIdRequest request);
        Task<IDataResult<IList<GetAllAddressesResponse>>> GetAddressesByIsActiveAsync();
    }
}
