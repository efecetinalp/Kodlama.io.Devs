using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<SocialMedia> result = await _socialMediaRepository.GetListAsync(sm => sm.Name == name);
            if (result.Items.Any()) throw new BusinessException(name + " " + Messages.EntityNameExists);
        }

        public async Task SocialMediaCanNotBeEmptyWhenRequested(SocialMedia socialMedia)
        {
            if (socialMedia == null) throw new BusinessException(Messages.EntityNotExists);
        }
    }
}
