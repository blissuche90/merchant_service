using GoTap.MerchantService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Interfaces
{
    public interface IMerchantRepository
    {
        Task<Merchant?> GetByIdAsync(Guid id);
        Task<IEnumerable<Merchant>> GetAllAsync();
        Task AddAsync(Merchant merchant);
        Task UpdateAsync(Merchant merchant);
        Task DeleteAsync(Merchant merchant);
    }
}
