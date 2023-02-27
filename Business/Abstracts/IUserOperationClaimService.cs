using Core.Utilities.Results;
using Entities.Dtos.Requests.UserOperationClaimDtos;
using Entities.Dtos.Responses.UserOperationClaimDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserOperationClaimService
    {
        Task<IDataResult<GetUserOperationClaimByIdResponse>> AddUserOperationClaim(AddUserOperationClaimRequest request);
        Task<IResult> DeleteUserOperationClaim(UserOperationClaimIdRequest request);
        Task<IDataResult<IList<GetAllUserOperationClaimsResponse>>> GetAllUserOperationClaims();
        Task<IDataResult<GetUserOperationClaimByIdResponse>> GetUserOperationClaimById(UserOperationClaimIdRequest request);
    }
}
