// DTOs/Person/PersonSearchDto.cs
namespace LandRegistrySystem.DTOs.Person
{
    public class PersonSearchDto
    {
        public string? NationalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}