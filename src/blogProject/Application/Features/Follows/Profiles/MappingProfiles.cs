using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using Application.Features.Follows.Commands.Create;
using Application.Features.Follows.Commands.Delete;
using Application.Features.Follows.Commands.Update;
using Application.Features.Follows.Queries.GetById;
using Application.Features.Follows.Queries.GetList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Follow, CreateFollowCommand>().ReverseMap();
        CreateMap<Follow, CreatedFollowResponse>().ReverseMap();

        CreateMap<Follow, UpdateFollowCommand>().ReverseMap();
        CreateMap<Follow, UpdatedFollowResponse>().ReverseMap();

        CreateMap<Follow, DeleteFollowCommand>().ReverseMap();
        CreateMap<Follow, DeletedFollowResponse>().ReverseMap();

        CreateMap<Follow, GetByIdFollowResponse>()
            .ForMember(destinationMember: f => f.ApplicationUserIdFullName, memberOptions: opt => opt.MapFrom(f => f.ApplicationUser.User.FirstName + " " + f.ApplicationUser.User.LastName))
            .ForMember(destinationMember: f => f.ApplicationUserIdFollowedFullName, memberOptions: opt => opt.MapFrom(f => f.ApplicationUser.User.FirstName + " " + f.ApplicationUser.User.LastName))
            .ReverseMap();

        CreateMap<IPaginate<Follow>, GetListResponse<GetListFollowListItemDto>>()
            .ReverseMap();
        CreateMap<Follow, GetListFollowListItemDto>()
            .ForMember(destinationMember: f => f.ApplicationUserIdFullName, memberOptions: opt => opt.MapFrom(f => f.ApplicationUser.User.FirstName + " " + f.ApplicationUser.User.LastName))
            .ForMember(destinationMember: f => f.ApplicationUserIdFollowedFullName, memberOptions: opt => opt.MapFrom(f => f.ApplicationUser.User.FirstName + " " + f.ApplicationUser.User.LastName))
            .ReverseMap();
            
    }
}
