using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>
    {
        public string Name { get; set; }

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMediaToUpdate = await _socialMediaRepository.GetAsync(p => p.Name == request.Name);
                await _socialMediaBusinessRules.SocialMediaCanNotBeEmptyWhenRequested(socialMediaToUpdate);

                SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                SocialMedia updatedSocialMedia = await _socialMediaRepository.UpdateAsync(mappedSocialMedia);
                UpdatedSocialMediaDto updatedSocialMediaDto = _mapper.Map<UpdatedSocialMediaDto>(updatedSocialMedia);

                return updatedSocialMediaDto;
            }
        }
    }
}
