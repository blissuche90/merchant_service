using GoTap.MerchantService.Application.Interfaces;
using GoTap.MerchantService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Persistence.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly MerchantDbContext _dbContext;

        public MerchantRepository(MerchantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Merchant?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Merchants.FindAsync(id);
        }

        public async Task<IEnumerable<Merchant>> GetAllAsync()
        {
            return await _dbContext.Merchants.ToListAsync();
        }

        public async Task AddAsync(Merchant merchant)
        {
            await _dbContext.Merchants.AddAsync(merchant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Merchant merchant)
        {
            _dbContext.Merchants.Update(merchant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Merchant merchant)
        {
            _dbContext.Merchants.Remove(merchant);
            await _dbContext.SaveChangesAsync();
        }
    }
}
