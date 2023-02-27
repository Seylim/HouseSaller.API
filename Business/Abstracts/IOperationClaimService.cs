using Core.Utilities.Results;
using Entities.Dtos.Requests.OperationClaimDtos;
using Entities.Dtos.Responses.OperationClaimDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IOperationClaimService
    {
        Task<IDataResult<GetOperationClaimByIdResponse>> AddOperationClaim(AddOperationClaimRequest request);
        Task<IDataResult<GetOperationClaimByIdResponse>> UpdateOperationClaim(UpdateOperationClaimRequest request);
        Task<IResult> DeleteOperationClaim(OperationClaimIdRequest request);
        Task<IDataResult<IList<GetAllOperationClaimsResponse>>> GetAllOperationClaims();
        Task<IDataResult<GetOperationClaimByIdResponse>> GetOperationClaimById(OperationClaimIdRequest request);
    }
}
