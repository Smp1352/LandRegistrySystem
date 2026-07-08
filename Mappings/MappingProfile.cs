// Mappings/MappingProfile.cs
using AutoMapper;
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.DTOs.Person;
using LandRegistrySystem.Models.Entities;
using LandRegistrySystem.Models.Enums;

namespace LandRegistrySystem.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mappings/MappingProfile.cs
            CreateMap<Person, PersonViewDto>()
                .ForMember(dest => dest.BirthDatePersian,
                    opt => opt.MapFrom(src => src.BirthDate != null
                        ? src.BirthDate.Value.ToString("yyyy/MM/dd")
                        : null))
                .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PostalCode,
                    opt => opt.MapFrom(src => src.PostalCode));

            CreateMap<PersonCreateDto, Person>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.ParcelOwners, opt => opt.Ignore())
                .ForMember(dest => dest.ParcelOperators, opt => opt.Ignore());

            // ===== Parcel -> ParcelViewDto =====
            CreateMap<Parcel, ParcelViewDto>()
                // مشخصات عمومی
                .ForMember(dest => dest.PersianName, opt => opt.MapFrom(src => src.PersianName))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.EnglishName))
                .ForMember(dest => dest.Definition, opt => opt.MapFrom(src => src.Definition))
                .ForMember(dest => dest.FeatureClass, opt => opt.MapFrom(src => src.FeatureClass))
                .ForMember(dest => dest.FeatureType, opt => opt.MapFrom(src => src.FeatureType))
                .ForMember(dest => dest.Dimension, opt => opt.MapFrom(src => src.Dimension))

                // اطلاعات توصیفی
                .ForMember(dest => dest.X, opt => opt.MapFrom(src => src.X))
                .ForMember(dest => dest.Y, opt => opt.MapFrom(src => src.Y))
                .ForMember(dest => dest.Zone, opt => opt.MapFrom(src => src.Zone))
                .ForMember(dest => dest.ParcelCode, opt => opt.MapFrom(src => src.ParcelCode))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
                .ForMember(dest => dest.UniqueParcelCode, opt => opt.MapFrom(src => src.UniqueParcelCode))

                // اطلاعات مکانی
                .ForMember(dest => dest.Province,
                    opt => opt.MapFrom(src => src.Province != null ? src.Province.Name : null))
                .ForMember(dest => dest.Shahrestan,
                    opt => opt.MapFrom(src => src.County != null ? src.County.Name : null))
                .ForMember(dest => dest.AbadiName,
                    opt => opt.MapFrom(src => src.Village != null ? src.Village.Name : null))
                .ForMember(dest => dest.AbadiCode, opt => opt.MapFrom(src => src.AbadiCode))
                .ForMember(dest => dest.ProvinceName,
                    opt => opt.MapFrom(src => src.Province != null ? src.Province.Name : null))
                .ForMember(dest => dest.CountyName,
                    opt => opt.MapFrom(src => src.County != null ? src.County.Name : null))
                .ForMember(dest => dest.VillageName,
                    opt => opt.MapFrom(src => src.Village != null ? src.Village.Name : null))

                // اطلاعات ثبتی
                .ForMember(dest => dest.NahiyeSabti, opt => opt.MapFrom(src => src.NahiyeSabti))
                .ForMember(dest => dest.PlakName, opt => opt.MapFrom(src => src.PlakName))
                .ForMember(dest => dest.PlakAsli, opt => opt.MapFrom(src => src.PlakAsli))
                .ForMember(dest => dest.PlakFarei, opt => opt.MapFrom(src => src.PlakFarei))
                .ForMember(dest => dest.BakhshSabti, opt => opt.MapFrom(src => src.BakhshSabti))

                // اطلاعات کاربری
                .ForMember(dest => dest.CurrentOperationLandUse,
                    opt => opt.MapFrom(src => src.CurrentOperationLandUse))
                .ForMember(dest => dest.CropsType, opt => opt.MapFrom(src => src.CropsType))

                // ✅ اطلاعات مالک - استفاده از متدهای کمکی
                .ForMember(dest => dest.OwnerType,
                    opt => opt.MapFrom(src => ConvertOwnerType(src.OwnerType)))
                .ForMember(dest => dest.ShorakaTedad, opt => opt.MapFrom(src => src.ShorakaTedad))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.OwnerName))
                .ForMember(dest => dest.OwnerLastName, opt => opt.MapFrom(src => src.OwnerLastName))
                .ForMember(dest => dest.OwnerNationalCode,
                    opt => opt.MapFrom(src => src.OwnerNationalCode))
                .ForMember(dest => dest.OwnerMobile, opt => opt.MapFrom(src => src.OwnerMobile))
                .ForMember(dest => dest.OwnerFatherName, opt => opt.MapFrom(src => src.OwnerFatherName))
                .ForMember(dest => dest.OwnerBirthdayPersian,
                    opt => opt.MapFrom(src => src.OwnerBirthday != null
                        ? src.OwnerBirthday.Value.ToString("yyyy/MM/dd")
                        : null))
                .ForMember(dest => dest.OwnershipUnit,
                    opt => opt.MapFrom(src => ConvertOwnershipUnit(src.OwnershipUnit)))
                .ForMember(dest => dest.OwnershipQuantity,
                    opt => opt.MapFrom(src => src.OwnershipQuantity))
                .ForMember(dest => dest.OwnershipProof, opt => opt.MapFrom(src => src.OwnershipProof))

                // اطلاعات بهره‌بردار
                .ForMember(dest => dest.OperatorName, opt => opt.MapFrom(src => src.OperatorName))
                .ForMember(dest => dest.OperatorLastName,
                    opt => opt.MapFrom(src => src.OperatorLastName))
                .ForMember(dest => dest.OperatorNationalCode,
                    opt => opt.MapFrom(src => src.OperatorNationalCode))
                .ForMember(dest => dest.OperatorMobile, opt => opt.MapFrom(src => src.OperatorMobile))
                .ForMember(dest => dest.OperatorFatherName,
                    opt => opt.MapFrom(src => src.OperatorFatherName))
                .ForMember(dest => dest.OperatorBirthdayPersian,
                    opt => opt.MapFrom(src => src.OperatorBirthday != null
                        ? src.OperatorBirthday.Value.ToString("yyyy/MM/dd")
                        : null))
                .ForMember(dest => dest.RelationOwnerOperator,
                    opt => opt.MapFrom(src => src.RelationOwnerOperator))
                .ForMember(dest => dest.OwnershipConfirm,
                    opt => opt.MapFrom(src => src.OwnershipConfirm))

                // سایر اطلاعات
                .ForMember(dest => dest.ChangeLandUse, opt => opt.MapFrom(src => src.ChangeLandUse))
                .ForMember(dest => dest.SanadMafroozi, opt => opt.MapFrom(src => src.SanadMafroozi))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))

                // اطلاعات سیستمی
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            // ===== ParcelCreateDto -> Parcel =====
            CreateMap<ParcelCreateDto, Parcel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.ParcelOwners, opt => opt.Ignore())
                .ForMember(dest => dest.ParcelOperators, opt => opt.Ignore())
                .ForMember(dest => dest.Province, opt => opt.Ignore())
                .ForMember(dest => dest.County, opt => opt.Ignore())
                .ForMember(dest => dest.Village, opt => opt.Ignore());

            // ===== ParcelUpdateDto -> Parcel =====
            CreateMap<ParcelUpdateDto, Parcel>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.ParcelOwners, opt => opt.Ignore())
                .ForMember(dest => dest.ParcelOperators, opt => opt.Ignore())
                .ForMember(dest => dest.Province, opt => opt.Ignore())
                .ForMember(dest => dest.County, opt => opt.Ignore())
                .ForMember(dest => dest.Village, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                    srcMember != null && !string.IsNullOrWhiteSpace(srcMember.ToString())));
        }

        // ==========================================
        // ✅ متدهای کمکی برای تبدیل (به عنوان متدهای Instance)
        // ==========================================

        private static OwnerType? ConvertOwnerType(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value switch
            {
                "حقیقی" => OwnerType.Natural,
                "حقوقی" => OwnerType.Legal,
                _ => null
            };
        }

        private static OwnershipUnit? ConvertOwnershipUnit(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value switch
            {
                "عرصه" => OwnershipUnit.Land,
                "اعیان" => OwnershipUnit.Building,
                "عرصه و اعیان" => OwnershipUnit.LandAndBuilding,
                _ => null
            };
        }
    }
   
}