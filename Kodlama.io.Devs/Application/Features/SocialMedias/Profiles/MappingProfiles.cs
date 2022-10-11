using Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, DeletedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, DeleteSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, UpdatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            //mapping for programming language name
            CreateMap<SocialMedia, SocialMediaListDto>().ForMember(sm => sm.UserName, opt => opt.MapFrom(sm => sm.User.FirstName + " " + sm.User.LastName)).ReverseMap();
            CreateMap<SocialMedia, SocialMediaGetByIdDto>().ForMember(sm => sm.UserName, opt => opt.MapFrom(sm => sm.User.FirstName + " " + sm.User.LastName)).ReverseMap();
            CreateMap<IPaginate<SocialMedia>, SocialMediaListModel>().ReverseMap();
        }
    }
}
