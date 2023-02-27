using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.UserDtos;
using Entities.Dtos.Responses.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<IDataResult<GetUserByIdResponse>> AddUser(User user);
        Task<IDataResult<GetUserByIdResponse>> UpdateUser(UpdateUserRequest request);
        Task<IResult> DeleteUser(UserIdRequest request);
        Task<IDataResult<IList<GetAllUsersResponse>>> GetAllUsers();
        Task<IDataResult<GetUserByIdResponse>> GetUserById(UserIdRequest request);
        Task<User> GetUserByMail(string mail);
        Task<IList<OperationClaim>> GetOperationClaims(User user);
    }
}
