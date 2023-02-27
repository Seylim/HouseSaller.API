using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.UserDtos;
using Entities.Dtos.Responses.CityDtos;
using Entities.Dtos.Responses.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetUserByIdResponse>> AddUser(User user)
        {
            var dbuser = await _repository.AddAsync(user);
            var addedUser = _mapper.Map<GetUserByIdResponse>(dbuser);
            return new SuccessDataResult<GetUserByIdResponse>(addedUser);
        }

        public async Task<IResult> DeleteUser(UserIdRequest request)
        {
            var user = _mapper.Map<User>(request);
            var dbUser = await _repository.GetByIdAsync(user.Id);
            if (dbUser != null && user.IsActive)
            {
                await _repository.DeleteAsync(user.Id);
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<IList<GetAllUsersResponse>>> GetAllUsers()
        {
            var users = await _repository.GetAllAsync();
            var gettedUsers = _mapper.Map<IList<GetAllUsersResponse>>(users);
            return new SuccessDataResult<IList<GetAllUsersResponse>>(gettedUsers);
        }

        public async Task<IList<OperationClaim>> GetOperationClaims(User user)
        {
            var claims = await _repository.GetOperationClaims(user);
            return claims;
        }

        public async Task<IDataResult<GetUserByIdResponse>> GetUserById(UserIdRequest request)
        {
            var user = _mapper.Map<User>(request);
            var dbUser = await _repository.GetByIdAsync(user.Id);
            var gettedUser = _mapper.Map<GetUserByIdResponse>(dbUser);
            return new SuccessDataResult<GetUserByIdResponse>(gettedUser);
        }

        public async Task<User> GetUserByMail(string mail)
        {
            var user = await _repository.GetUserByMail(mail);
            return user;
        }

        public async Task<IDataResult<GetUserByIdResponse>> UpdateUser(UpdateUserRequest request)
        {

            var user = await _repository.GetByIdAsync(request.Id);
            if (user != null)
            {
                user = _mapper.Map<User>(request);
                var updatedUser = await _repository.UpdateAsync(user);
                var mappedUser = _mapper.Map<GetUserByIdResponse>(updatedUser);
                return new SuccessDataResult<GetUserByIdResponse>(Messages.UpdatedUser, mappedUser);
            }
            return new ErrorDataResult<GetUserByIdResponse>(Messages.UserNotFound, null);
        }
    }
}
