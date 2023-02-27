using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.UserDtos;
using Entities.Dtos.Requests.UserOperationClaimDtos;
using Entities.Dtos.Responses.OperationClaimDtos;
using Entities.Dtos.Responses.UserDtos;
using Entities.Dtos.Responses.UserOperationClaimDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _repository;
        private readonly IMapper _mapper;

        public UserOperationClaimManager(IUserOperationClaimRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetUserOperationClaimByIdResponse>> AddUserOperationClaim(AddUserOperationClaimRequest request)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            var dbUserOperationClaim = await _repository.AddAsync(userOperationClaim);
            var addedUserOperationClaim = _mapper.Map<GetUserOperationClaimByIdResponse>(dbUserOperationClaim);
            return new SuccessDataResult<GetUserOperationClaimByIdResponse>(Messages.AddedUserOperationClaim, addedUserOperationClaim);
        }

        public async Task<IResult> DeleteUserOperationClaim(UserOperationClaimIdRequest request)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            var dbUserOperationClaim = await _repository.GetByIdAsync(userOperationClaim.Id);
            if (dbUserOperationClaim != null)
            {
                await _repository.DeleteAsync(userOperationClaim.Id);
            }
            return new SuccessResult(Messages.DeletedUserOperationClaim);
        }

        public async Task<IDataResult<IList<GetAllUserOperationClaimsResponse>>> GetAllUserOperationClaims()
        {
            var userOperationClaims = await _repository.GetAllAsync();
            var gettedUserOperationClaims = _mapper.Map<IList<GetAllUserOperationClaimsResponse>>(userOperationClaims);
            return new SuccessDataResult<IList<GetAllUserOperationClaimsResponse>>(gettedUserOperationClaims);
        }

        public async Task<IDataResult<GetUserOperationClaimByIdResponse>> GetUserOperationClaimById(UserOperationClaimIdRequest request)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            var dbUserOperationClaim = await _repository.GetByIdAsync(userOperationClaim.Id);
            var gettedUserOperationClaim = _mapper.Map<GetUserOperationClaimByIdResponse>(dbUserOperationClaim);
            return new SuccessDataResult<GetUserOperationClaimByIdResponse>(gettedUserOperationClaim);
        }
    }
}
