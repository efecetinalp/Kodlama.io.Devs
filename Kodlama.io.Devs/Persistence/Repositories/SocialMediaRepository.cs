using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, BaseDbContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
