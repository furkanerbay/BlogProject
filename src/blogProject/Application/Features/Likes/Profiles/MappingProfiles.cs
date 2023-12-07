using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Commands.Delete;
using Application.Features.Likes.Commands.Update;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Like, CreateLikeCommand>().ReverseMap();
        CreateMap<Like, CreatedLikeResponse>().ReverseMap();

        CreateMap<Like, UpdateLikeCommand>().ReverseMap();
        CreateMap<Like, UpdatedLikeResponse>().ReverseMap();


        CreateMap<Like, DeleteLikeCommand>().ReverseMap();
        CreateMap<Like, DeletedLikeResponse>().ReverseMap();

        CreateMap<Like, GetByIdLikeResponse>()
            .ForMember(destinationMember: l => l.BlogName, memberOptions: opt => opt.MapFrom(c => c.Blog.Title))
            .ForMember(destinationMember: b => b.ApplicationUserIdName, memberOptions: opt => opt.MapFrom(c => c.ApplicationUser.User.FirstName + " " + c.ApplicationUser.User.LastName))
            .ReverseMap();

        CreateMap<Like, GetListLikeListItemDto>()
            .ForMember(destinationMember: l => l.BlogName, memberOptions: opt => opt.MapFrom(c => c.Blog.Title))
            .ForMember(destinationMember: b => b.ApplicationUserIdName, memberOptions: opt => opt.MapFrom(c => c.ApplicationUser.User.FirstName + " " + c.ApplicationUser.User.LastName))
            .ReverseMap();
        CreateMap<IPaginate<Like>, GetListResponse<GetListLikeListItemDto>>()
            .ReverseMap();
    }
}
