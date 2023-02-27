using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.AdDtos;
using Entities.Dtos.Requests.CategoryDtos;
using Entities.Dtos.Responses.AdDtos;
using Entities.Dtos.Responses.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AdManager : IAdService
    {
        private readonly IAdRepository _repository;
        private readonly IMapper _mapper;

        public AdManager(IAdRepository repository, IMapper mapper)
        {
            _repository= repository;
            _mapper= mapper;
        }

        public async Task<IDataResult<GetAdByIdResponse>> AddAd(AddAdRequest request)
        {
            var ad = _mapper.Map<Ad>(request);
            ad.AddedAt = DateTime.Now;
            var dbAd = await _repository.AddAsync(ad);
            var addedAd = _mapper.Map<GetAdByIdResponse>(dbAd);
            return new SuccessDataResult<GetAdByIdResponse>(Messages.AddedAd, addedAd);
        }

        public async Task<IResult> DeleteAd(AdIdRequest request)
        {
            var ad = _mapper.Map<Ad>(request);
            var dbAd = await _repository.GetByIdAsync(ad.Id);
            if (dbAd != null && dbAd.IsActive)
            {
                await _repository.DeleteAsync(dbAd.Id);
            }
            return new SuccessResult(Messages.DeletedAd);
        }

        public async Task<IDataResult<GetAdByIdResponse>> GetAdById(AdIdRequest request)
        {
            var ad = _mapper.Map<Ad>(request);
            var dbAd = await _repository.GetByIdAsync(ad.Id);
            var gettedAd = _mapper.Map<GetAdByIdResponse>(dbAd);
            return new SuccessDataResult<GetAdByIdResponse>(gettedAd);
        }

        public async Task<IDataResult<IList<GetAllAdsResponse>>> GetAdsByCategoryIdAsync(CategoryIdRequest categoryIdRequest)
        {
            var ads = await _repository.GetAdsByCategoryIdAsync(categoryIdRequest.Id);
            var gettedAds = _mapper.Map<IList<GetAllAdsResponse>>(ads);
            return new SuccessDataResult<IList<GetAllAdsResponse>>(gettedAds);
        }

        public async Task<IDataResult<IList<GetAllAdsResponse>>> GetAdsByIsActiveAsync()
        {
            var ads = await _repository.GetAdsByIsActiveAsync();
            var gettedAds = _mapper.Map<IList<GetAllAdsResponse>>(ads);
            return new SuccessDataResult<IList<GetAllAdsResponse>>(gettedAds);
        }

        public async Task<IDataResult<ICollection<GetAllAdsResponse>>> GetAllAds()
        {
            var ads = await _repository.GetAllAsync();
            var mappedAds = _mapper.Map<ICollection<GetAllAdsResponse>>(ads);
            return new SuccessDataResult<ICollection<GetAllAdsResponse>>(mappedAds);
        }

        public async Task<IDataResult<GetAdByIdResponse>> UpdateAd(UpdateAdRequest request)
        {

            var ad = await _repository.GetByIdAsync(request.Id);
            if (ad != null)
            {
                ad = _mapper.Map<Ad>(request);
                var updatedAd = await _repository.UpdateAsync(ad);
                var mappedAd = _mapper.Map<GetAdByIdResponse>(updatedAd);
                return new SuccessDataResult<GetAdByIdResponse>(Messages.UpdatedAd, mappedAd);
            }
            return new ErrorDataResult<GetAdByIdResponse>(Messages.AdNotFound, null);
        }
    }
}
