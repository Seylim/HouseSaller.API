using Core.Utilities.Results;
using Entities.Dtos.Requests.AdDtos;
using Entities.Dtos.Requests.Photo;
using Entities.Dtos.Responses.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IPhotoService
    {
        Task<IDataResult<PhotoForResponse>> AddPhoto(AdIdRequest adIdRequest, PhotoForCreationRequest request);
        Task<IDataResult<PhotoForResponse>> GetPhoto(PhotoIdRequest request);
    }
}
