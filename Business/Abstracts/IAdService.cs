using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.AdDtos;
using Entities.Dtos.Requests.CategoryDtos;
using Entities.Dtos.Responses.AdDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAdService
    {
        Task<IDataResult<GetAdByIdResponse>> AddAd(AddAdRequest request);
        Task<IDataResult<GetAdByIdResponse>> UpdateAd(UpdateAdRequest request);
        Task<IResult> DeleteAd(AdIdRequest request);
        Task<IDataResult<ICollection<GetAllAdsResponse>>> GetAllAds();
        Task<IDataResult<GetAdByIdResponse>> GetAdById(AdIdRequest request);
        Task<IDataResult<IList<GetAllAdsResponse>>> GetAdsByIsActiveAsync();
        Task<IDataResult<IList<GetAllAdsResponse>>> GetAdsByCategoryIdAsync(CategoryIdRequest categoryIdRequest);
    }
}
