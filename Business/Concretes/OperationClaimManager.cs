using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.OperationClaimDtos;
using Entities.Dtos.Requests.UserDtos;
using Entities.Dtos.Responses.CityDtos;
using Entities.Dtos.Responses.OperationClaimDtos;
using Entities.Dtos.Responses.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimRepository _repository;
        private readonly IMapper _mapper;

        public OperationClaimManager(IOperationClaimRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetOperationClaimByIdResponse>> AddOperationClaim(AddOperationClaimRequest request)
        {
            var operationClaim = _mapper.Map<OperationClaim>(request);
            var dbOperationClaim = await _repository.AddAsync(operationClaim);
            var addedOperationClaim = _mapper.Map<GetOperationClaimByIdResponse>(dbOperationClaim);
            return new SuccessDataResult<GetOperationClaimByIdResponse>(Messages.AddedOperationClaim, addedOperationClaim);
        }

        public async Task<IResult> DeleteOperationClaim(OperationClaimIdRequest request)
        {
            var operationClaim = _mapper.Map<OperationClaim>(request);
            var dbOperationClaim = await _repository.GetByIdAsync(operationClaim.Id);
            if (dbOperationClaim != null)
            {
                await _repository.DeleteAsync(operationClaim.Id);
            }
            return new SuccessResult(Messages.DeletedOperationClaim);
        }

        public async Task<IDataResult<IList<GetAllOperationClaimsResponse>>> GetAllOperationClaims()
        {
            var operationClaims = await _repository.GetAllAsync();
            var gettedOperationClaims = _mapper.Map<IList<GetAllOperationClaimsResponse>>(operationClaims);
            return new SuccessDataResult<IList<GetAllOperationClaimsResponse>>(gettedOperationClaims);
        }

        public async Task<IDataResult<GetOperationClaimByIdResponse>> GetOperationClaimById(OperationClaimIdRequest request)
        {
            var operationClaim = _mapper.Map<OperationClaim>(request);
            var dbOperationClaim = await _repository.GetByIdAsync(operationClaim.Id);
            var gettedOperationClaim = _mapper.Map<GetOperationClaimByIdResponse>(dbOperationClaim);
            return new SuccessDataResult<GetOperationClaimByIdResponse>(gettedOperationClaim);
        }

        public async Task<IDataResult<GetOperationClaimByIdResponse>> UpdateOperationClaim(UpdateOperationClaimRequest request)
        {

            var operationClaim = await _repository.GetByIdAsync(request.Id);
            if (operationClaim != null)
            {
                operationClaim = _mapper.Map<OperationClaim>(request);
                var updatedOperationClaim = await _repository.UpdateAsync(operationClaim);
                var mappedOperationClaim = _mapper.Map<GetOperationClaimByIdResponse>(updatedOperationClaim);
                return new SuccessDataResult<GetOperationClaimByIdResponse>(Messages.UpdatedOperationClaim, mappedOperationClaim);
            }
            return new ErrorDataResult<GetOperationClaimByIdResponse>(Messages.OperationClaimNotFound, null);
        }
    }
}
