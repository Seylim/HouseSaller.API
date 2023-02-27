using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class Messages
    {
        //Messages of the Ad
        public static string AddedAd = "Ad has been successfully added.";
        public static string UpdatedAd = "Ad has been successfully updated.";
        public static string DeletedAd = "Ad has been successfully deleted.";
        public static string AdNotFound = "!Ad Not Found.";

        //Messages of the Address
        public static string AddedAddress = "Addres has been successfully added.";
        public static string UpdatedAddress = "Addres has been successfully updated.";
        public static string DeletedAddress = "Addres has been successfully deleted.";
        public static string AddressNotFound = "!Address Not Found.";

        //Messages of the Category
        public static string AddedCategory = "Category has been successfully added.";
        public static string UpdatedCategory = "Category has been successfully updated.";
        public static string DeletedCategory = "Category has been successfully deleted.";
        public static string CategoryNotFound = "!Category Not Found.";

        //Messages of the City
        public static string AddedCity = "City has been successfully added.";
        public static string UpdatedCity = "City has been successfully updated.";
        public static string DeletedCity = "City has been successfully deleted.";
        public static string CityNotFound = "!City Not Found.";

        //Messages of the District
        public static string AddedDistrict = "District has been successfully added.";
        public static string UpdatedDistrict = "District has been successfully updated.";
        public static string DeletedDistrict = "District has been successfully deleted.";
        public static string DistrictNotFound = "!District Not Found.";

        //Messages of the OperationClaim
        public static string AddedOperationClaim = "OperationClaim has been successfully added.";
        public static string UpdatedOperationClaim = "OperationClaim has been successfully updated.";
        public static string DeletedOperationClaim = "OperationClaim has been successfully deleted.";
        public static string OperationClaimNotFound = "!OperationClaim Not Found.";

        //Messages of the UserOperationClaim
        public static string AddedUserOperationClaim = "UserOperationClaim has been successfully added.";
        public static string DeletedUserOperationClaim = "UserOperationClaim has been successfully deleted.";

        //Messages of the User
        public static string UpdatedUser = "User has been successfully updated.";
        public static string UserNotAuth = "!User Is Not Authorized.";

        //Messages of the Auth
        public static string CreatedAccessToken = "Access Token has been succesfuly created.";
        public static string UserNotFound = "!User Not Found.";
        public static string PasswordError = "!Password Error.";
        public static string UserRegistered = "User has been succesfuly registered.";
        public static string UserAvailable = "User Avaliable";
        public static string UserNotAvailable = "!User Not Avaliable";


        //Validator Message
        //Address
        public static string AddressDetailsNotNull = "!AddressDetails Not Null.";
        public static string AddressIdNotNull = "!AddressId Not Null.";
        public static string AddressIsActiveNotNull = "!AddressIsActive Not Null.";
        public static string AddressDetailsLength = "!AddressDetail must be less than 250 characters";

        //Ad
        public static string AdTitleNotNull = "!AdTitle Not Null.";
        public static string AdTitleLength = "!AdTitle must be less than 50 characters.";
        public static string AdDescriptionNotNull = "!AdDescription Not Null.";
        public static string AdDescriptionLength = "!AdDescription must be less than 250 characters";
        public static string AdPriceNotNull = "!AdPrice Not Null.";
        public static string AdIdNotNull = "!AdId Not Null.";
        public static string AdIsActiveNotNull = "!AdIsActive Not Null.";

        //Category
        public static string CategoryIdNotNull = "!CategoryId Not Null.";
        public static string CategoryNameNotNull = "!CategoryName Not Null.";
        public static string CategoryNameLength = "!CategoryName must be less than 20 characters";
        public static string CategoryIsActiveNotNull = "!CategoryIsActive Not Null.";

        //City
        public static string CityIdNotNull = "!CityId Not Null.";
        public static string CityNameNotNull = "!CityName Not Null.";
        public static string CityNameLength = "!CityName must be less than 20 characters";
        public static string CityNumberPlateNotNull = "!CityNumberPlate Not Null.";
        public static string CityTelephoneCodeNotNull = "!CityTelephoneCode Not Null.";

        //District
        public static string DistrictIdNotNull = "!DistrictId Not Null.";
        public static string SubDistrictIdNotNull = "!SubDistrictId Not Null.";
        public static string DistrictNameNotNull = "!DistrictName Not Null.";

        //OperationClaim
        public static string OperationClaimIdNotNull = "!OperationClaimId Not Null.";
        public static string OperationClaimNameNotNull = "!OperationClaimName Not Null.";

        //User
        public static string UserIdNotNull = "!UserId Not Null.";
        public static string UserFirstNameNotNull = "!UserFirstName Not Null.";
        public static string UserLastNameNotNull = "!UserLastName Not Null.";
        public static string UserEmailNotNull = "!UserEmail Not Null.";
        public static string UserEmailNotValid = "!UserEmail Not Valid.";
        public static string UserPasswordNotNull = "!Userpassword Not Null.";
        public static string UserpasswordMaxLength = "!UserPassword must be less than 16 characters";
        public static string UserpasswordMinLength = "!UserPassword must be more than 6 characters";

        //UserOperatinClaim
        public static string UserOperationClaimIdNotNull = "!UserOperationClaimId Not Null.";

        //Photo
        public static string PhotoIdNotNull = "!Photoid Not Null.";
        public static string PhotoUrlNotNull = "!PhotoUrl Not Null.";
        public static string PhotoFileNotNull = "!PhotoFile Not Null.";
        public static string PhotoDescriptionNotNull = "!PhotoDescription Not Null.";
        public static string PhotoPublicIdNotNull = "!PhotoPublicId Not Null.";
    }
}
