using GRTAssist.API.DTOs;
using GRTAssist.API.Models;
using GRTAssist.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GRTAssist.API.Services
{
    public class MarketplaceService : IMarketplaceService
    {
        private readonly ApplicationDbContext _db;

        public MarketplaceService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ApiListingDto>> GetApisAsync()
        {
            return await _db.ApiListings
                .Where(a => a.IsActive)
                .Select(a => new ApiListingDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    BaseUrl = a.BaseUrl,
                    Category = a.Category,
                    Provider = a.Provider,
                    IsActive = a.IsActive
                })
                .ToListAsync();
        }

        public async Task<ApiListingDto> AddApiListingAsync(ApiListingDto dto, string userId)
        {
            var entity = new ApiListing
            {
                Name = dto.Name,
                Description = dto.Description,
                BaseUrl = dto.BaseUrl,
                Category = dto.Category,
                Provider = dto.Provider,
                IsActive = dto.IsActive,
                CreatedByUserId = userId
            };
            _db.ApiListings.Add(entity);
            await _db.SaveChangesAsync();
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<IEnumerable<DataSetDto>> GetDataSetsAsync()
        {
            return await _db.DataSets
                .Where(d => d.IsActive)
                .Select(d => new DataSetDto
                {
                    Id = d.Id,
                    Title = d.Title,
                    Description = d.Description,
                    Category = d.Category,
                    Price = d.Price,
                    IsVerified = d.IsVerified,
                    IsActive = d.IsActive
                })
                .ToListAsync();
        }

        public async Task<DataSetDto> AddDataSetAsync(DataSetDto dto, string userId)
        {
            var entity = new DataSet
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Price = dto.Price,
                IsVerified = dto.IsVerified,
                IsActive = dto.IsActive,
                UploadedByUserId = userId
            };
            _db.DataSets.Add(entity);
            await _db.SaveChangesAsync();
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> VerifyDataSetAsync(int id)
        {
            var ds = await _db.DataSets.FindAsync(id);
            if (ds == null) return false;
            ds.IsVerified = true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}