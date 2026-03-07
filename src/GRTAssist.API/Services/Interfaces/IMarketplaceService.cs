using GRTAssist.API.DTOs;

namespace GRTAssist.API.Services.Interfaces
{
    public interface IMarketplaceService
    {
        Task<IEnumerable<ApiListingDto>> GetApisAsync();
        Task<ApiListingDto> AddApiListingAsync(ApiListingDto dto, string userId);

        Task<IEnumerable<DataSetDto>> GetDataSetsAsync();
        Task<DataSetDto> AddDataSetAsync(DataSetDto dto, string userId);
        Task<bool> VerifyDataSetAsync(int id);
    }
}