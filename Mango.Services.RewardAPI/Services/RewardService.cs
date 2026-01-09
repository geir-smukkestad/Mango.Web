using Mango.Services.RewardAPI.Message;
using Mango.Services.RewardAPI.Data;
using Microsoft.EntityFrameworkCore;
using Mango.Services.RewardAPI.Models;

namespace Mango.Services.RewardAPI.Services
{
    public class RewardService : IRewardService
    {
        private DbContextOptions<AppDbContext> _dbOpptions;

        public RewardService(DbContextOptions<AppDbContext> dboptions)
        {
            _dbOpptions = dboptions;
        }

        public async Task UpdateRewards(RewardsMessage rewardsMessage)
        {
            try
            {
                Rewards rewards = new Rewards()
                {
                    OrderId = rewardsMessage.OrderId,
                    RewardsActivity = rewardsMessage.RewardsActivity,
                    UserId = rewardsMessage.UserId,
                    RewardsDate = DateTime.Now
                };

                await using var db = new AppDbContext(_dbOpptions);
                await db.Rewards.AddAsync(rewards);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }
    }
}
