using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concretes;
using Entities.Dtos.Requests.AddressDtos;
using Entities.Dtos.Requests.AdDtos;
using Entities.Dtos.Requests.CategoryDtos;
using Entities.Dtos.Requests.CityDtos;
using Entities.Dtos.Requests.DistrictDtos;
using Entities.Dtos.Requests.OperationClaimDtos;
using Entities.Dtos.Requests.Photo;
using Entities.Dtos.Requests.UserDtos;
using Entities.Dtos.Requests.UserOperationClaimDtos;
using Entities.Dtos.Responses.AddressDtos;
using Entities.Dtos.Responses.AdDtos;
using Entities.Dtos.Responses.CategoryDtos;
using Entities.Dtos.Responses.CityDtos;
using Entities.Dtos.Responses.DistrictDtos;
using Entities.Dtos.Responses.OperationClaimDtos;
using Entities.Dtos.Responses.Photo;
using Entities.Dtos.Responses.UserDtos;
using Entities.Dtos.Responses.UserOperationClaimDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //ADDRESS
            CreateMap<Address, AddAddressRequest>().ReverseMap();
            CreateMap<Address, UpdateAddressRequest>().ReverseMap();
            CreateMap<Address, AddressIdRequest>().ReverseMap();
            CreateMap<Address, GetAddressByIdResponse>().ReverseMap();
            CreateMap<Address, GetAllAddressesResponse>().ReverseMap();

            //AD
            CreateMap<Ad, AddAdRequest>().ReverseMap();
            CreateMap<Ad, UpdateAdRequest>().ReverseMap();
            CreateMap<Ad, AdIdRequest>().ReverseMap();
            CreateMap<Ad, GetAdByIdResponse>().ReverseMap();
            CreateMap<Ad, GetAllAdsResponse>().ReverseMap();

            //CATEGORY
            CreateMap<Category, AddCategoryRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
            CreateMap<Category, CategoryIdRequest>().ReverseMap();
            CreateMap<Category, GetCategoryByIdResponse>().ReverseMap();
            CreateMap<Category, GetAllCategoriesResponse>().ReverseMap();

            //CITY
            CreateMap<City, AddCityRequest>().ReverseMap();
            CreateMap<City, UpdateCityRequest>().ReverseMap();
            CreateMap<City, CityIdRequest>().ReverseMap();
            CreateMap<City, GetCityByIdResponse>().ReverseMap();
            CreateMap<City, GetAllCitiesResponse>().ReverseMap();
            CreateMap<City, CityNameRequest>().ReverseMap();

            //DISTRICT
            CreateMap<District, AddDistrictRequest>().ReverseMap();
            CreateMap<District, UpdateDistrictRequest>().ReverseMap();
            CreateMap<District, DistrictIdRequest>().ReverseMap();
            CreateMap<District, GetDistrictByIdResponse>().ReverseMap();
            CreateMap<District, GetAllDistrictsResponse>().ReverseMap();
            CreateMap<District, DistrictNameRequest>().ReverseMap();

            //User
            CreateMap<User, UserForLoginDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UserIdRequest>().ReverseMap();
            CreateMap<User, GetUserByIdResponse>().ReverseMap();
            CreateMap<User, GetAllUsersResponse>().ReverseMap();

            //OperationClaim
            CreateMap<OperationClaim, AddOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimIdRequest>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, GetAllOperationClaimsResponse>().ReverseMap();
            CreateMap<OperationClaim, GetOperationClaimByIdResponse>().ReverseMap();

            //OperationClaim
            CreateMap<UserOperationClaim, AddUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimIdRequest>().ReverseMap();
            CreateMap<UserOperationClaim, GetAllUserOperationClaimsResponse>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimByIdResponse>().ReverseMap();

            //Photo
            CreateMap<Photo, PhotoForCreationRequest>().ReverseMap();
            CreateMap<Photo, PhotoForResponse>().ReverseMap();
            CreateMap<Photo, PhotoIdRequest>().ReverseMap();

        }
    }
}
