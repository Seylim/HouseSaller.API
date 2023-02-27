using AutoMapper;
using Business.Abstracts;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Cloudinary;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.AdDtos;
using Entities.Dtos.Requests.Photo;
using Entities.Dtos.Responses.Photo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class PhotoManager : IPhotoService
    {
        private readonly IPhotoRepository _repository;
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IHttpContextAccessor _contextAccessor;

        private Cloudinary _cloudinary;

        public PhotoManager(IPhotoRepository repository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig, IAdRepository adRepository, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;
            _adRepository = adRepository;
            _contextAccessor = contextAccessor;

            Account account = new Account(_cloudinaryConfig.Value.CloudName, _cloudinaryConfig.Value.ApiKey, _cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
            
        }

        public async Task<IDataResult<PhotoForResponse>> AddPhoto(AdIdRequest adIdRequest, PhotoForCreationRequest request)
        {
            var adId = _mapper.Map<Ad>(adIdRequest).Id;
            var ad = await _adRepository.GetByIdAsync(adId);

            if (ad == null)
            {
                return new ErrorDataResult<PhotoForResponse>(Messages.AdNotFound, null);
            }

            //int? currentUserId = int.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            //if (currentUserId != ad.UserId)
            //{
            //    return new ErrorDataResult<PhotoForResponse>(Messages.UserNotAuth,null);
            //}

            var file = request.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }

            var photo = _mapper.Map<Photo>(request);
            photo.AdId = adId;
            photo.ImageUrl = uploadResult.Url.ToString();
            photo.PublicId = uploadResult.PublicId;

            ad.Photos.Add(photo);

            var addedPhoto = await _repository.AddAsync(photo);
            await _adRepository.UpdateAsync(ad);

            var mappedPhoto = _mapper.Map<PhotoForResponse>(addedPhoto);

            return new SuccessDataResult<PhotoForResponse>(mappedPhoto);
        }

        public async Task<IDataResult<PhotoForResponse>> GetPhoto(PhotoIdRequest request)
        {
            var photo = _mapper.Map<Photo>(request);
            var photoDb = await _repository.GetByIdAsync(photo.Id);
            var gettedPhoto = _mapper.Map<PhotoForResponse>(photoDb);
            return new SuccessDataResult<PhotoForResponse>(gettedPhoto);
        }
    }
}
