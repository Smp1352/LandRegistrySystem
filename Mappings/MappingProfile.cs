// Mappings/MappingProfile.cs
using AutoMapper;
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Models.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // از DTO به Entity (برای ایجاد)
        CreateMap<ParcelCreateDto, Parcel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            // CropsType به صورت خودکار Mapping می‌شود
            ;

        // از Entity به DTO (برای نمایش)
        CreateMap<Parcel, ParcelViewDto>()
            .ForMember(dest => dest.ProvinceName,
                opt => opt.MapFrom(src => src.Province != null ? src.Province.Name : null))
            .ForMember(dest => dest.CountyName,
                opt => opt.MapFrom(src => src.County != null ? src.County.Name : null))
            .ForMember(dest => dest.VillageName,
                opt => opt.MapFrom(src => src.Village != null ? src.Village.Name : null));
        // CropsType به صورت خودکار Mapping می‌شود
    }
}