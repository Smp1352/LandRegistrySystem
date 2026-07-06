// Mappings/MappingProfile.cs
using AutoMapper;
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Mappings
{
    /// <summary>
    /// پروفایل AutoMapper برای Mapping بین Entity و DTO
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ===== Parcel =====

            // از Entity به DTO
            CreateMap<Parcel, ParcelViewDto>()
                .ForMember(dest => dest.ProvinceName,
                    opt => opt.MapFrom(src => src.Province != null ? src.Province.Name : null))
                .ForMember(dest => dest.CountyName,
                    opt => opt.MapFrom(src => src.County != null ? src.County.Name : null))
                .ForMember(dest => dest.VillageName,
                    opt => opt.MapFrom(src => src.Village != null ? src.Village.Name : null))
                .ForMember(dest => dest.OwnerName,
                    opt => opt.MapFrom(src => src.ParcelOwners != null && src.ParcelOwners.Any()
                        ? src.ParcelOwners.FirstOrDefault()!.Person!.FirstName
                        : null))
                .ForMember(dest => dest.OwnerLastName,
                    opt => opt.MapFrom(src => src.ParcelOwners != null && src.ParcelOwners.Any()
                        ? src.ParcelOwners.FirstOrDefault()!.Person!.LastName
                        : null))
                .ForMember(dest => dest.OwnerNationalCode,
                    opt => opt.MapFrom(src => src.ParcelOwners != null && src.ParcelOwners.Any()
                        ? src.ParcelOwners.FirstOrDefault()!.Person!.NationalCode
                        : null))
                .ForMember(dest => dest.OwnerMobile,
                    opt => opt.MapFrom(src => src.ParcelOwners != null && src.ParcelOwners.Any()
                        ? src.ParcelOwners.FirstOrDefault()!.Person!.Mobile
                        : null));

            // از DTO به Entity (برای ایجاد)
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

            // از DTO به Entity (برای بروزرسانی)
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

            // ===== Person =====
            // CreateMap<Person, PersonViewDto>();
            // CreateMap<PersonCreateDto, Person>();

            // ===== Province =====
            // CreateMap<Province, ProvinceViewDto>();
            // CreateMap<ProvinceCreateDto, Province>();

            // ===== County =====
            // CreateMap<County, CountyViewDto>();
            // CreateMap<CountyCreateDto, County>();

            // ===== Village =====
            // CreateMap<Village, VillageViewDto>();
            // CreateMap<VillageCreateDto, Village>();
        }
    }
}