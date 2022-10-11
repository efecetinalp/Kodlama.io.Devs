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

namespace Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand : IRequest<DeletedSocialMediaDto>
    {
        public string Name { get; set; }

        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<DeletedSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMediaToDelete = await _socialMediaRepository.GetAsync(p => p.Name == request.Name);
                await _socialMediaBusinessRules.SocialMediaCanNotBeEmptyWhenRequested(socialMediaToDelete);

                SocialMedia deletedSocialMedia = await _socialMediaRepository.DeleteAsync(socialMediaToDelete);
                DeletedSocialMediaDto deletedSocialMediaDto = _mapper.Map<DeletedSocialMediaDto>(deletedSocialMedia);

                return deletedSocialMediaDto;
            }
        }
    }
}
