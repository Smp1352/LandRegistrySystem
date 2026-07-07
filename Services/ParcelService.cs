// Services/ParcelService.cs
using AutoMapper;
using LandRegistrySystem.Data.Repositories;
using LandRegistrySystem.DTOs.Common;
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Services
{
    public class ParcelService : IParcelService
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public ParcelService(IParcelRepository parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        // ===== دریافت با DTO =====
        public async Task<ParcelViewDto?> GetParcelViewDtoByIdAsync(int id)
        {
            var parcel = await _parcelRepository.GetParcelWithDetailsAsync(id);
            return parcel == null ? null : _mapper.Map<ParcelViewDto>(parcel);
        }
        
        public async Task<IEnumerable<ParcelViewDto>> GetAllParcelViewDtosAsync()
        {
            var parcels = await _parcelRepository.GetAllAsync(
                orderBy: q => q.OrderByDescending(p => p.CreatedAt),
                includeProperties: "Province,County,Village"
            );
            return _mapper.Map<IEnumerable<ParcelViewDto>>(parcels);
        }

        public async Task<PagedResultDto<ParcelViewDto>> GetPagedParcelDtosAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm = null)
        {
            var (items, totalCount) = await _parcelRepository.GetPagedAsync(
                pageNumber,
                pageSize,
                orderBy: q => q.OrderByDescending(p => p.CreatedAt),
                includeProperties: "Province,County,Village"
            );

            var itemDtos = _mapper.Map<IEnumerable<ParcelViewDto>>(items);

            return new PagedResultDto<ParcelViewDto>
            {
                Items = itemDtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        // ===== عملیات CRUD با DTO =====

        public async Task<int> CreateParcelAsync(ParcelCreateDto createDto)
        {
            // اگر OwnershipProof خالی است، از Checkboxها مقدار بگیرید
            if (string.IsNullOrEmpty(createDto.OwnershipProof))
            {
                // در صورت نیاز، مقدار پیش‌فرض یا خطا
            }

            var parcel = _mapper.Map<Parcel>(createDto);
            parcel.CreatedAt = DateTime.UtcNow;

            await _parcelRepository.AddAsync(parcel);
            await _parcelRepository.SaveChangesAsync();

            return parcel.Id;
        }
        public async Task<bool> UpdateParcelAsync(ParcelUpdateDto updateDto)
        {
            var existingParcel = await _parcelRepository.GetByIdAsync(updateDto.Id);
            if (existingParcel == null)
                return false;

            _mapper.Map(updateDto, existingParcel);
            existingParcel.UpdatedAt = DateTime.UtcNow;

            _parcelRepository.Update(existingParcel);
            await _parcelRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteParcelAsync(int id)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id);
            if (parcel == null)
                return false;

            _parcelRepository.SoftDelete(parcel);
            await _parcelRepository.SaveChangesAsync();

            return true;
        }

        // ===== جستجو =====
        public async Task<IEnumerable<ParcelViewDto>> SearchParcelDtosAsync(ParcelSearchDto searchDto)
        {
            var parcels = await _parcelRepository.SearchParcelsAsync(
                parcelCode: searchDto.ParcelCode,
                ownerNationalCode: searchDto.OwnerNationalCode,
                province: searchDto.ProvinceName,
                shahrestan: searchDto.CountyName,
                abadiName: searchDto.VillageName,
                minArea: searchDto.MinArea,
                maxArea: searchDto.MaxArea
            );

            return _mapper.Map<IEnumerable<ParcelViewDto>>(parcels);
        }

        // ===== متدهای کمکی =====
        public async Task<int> GetParcelsCountAsync()
        {
            return await _parcelRepository.CountAsync();
        }
    }
}