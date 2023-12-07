using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
        CreateMap<Comment, CreateCommentCommand>().ReverseMap();
        CreateMap<Comment, CreatedCommentResponse>().ReverseMap();

        CreateMap<Comment, DeleteCommentCommand>().ReverseMap();
        CreateMap<Comment, DeletedCommentResponse>().ReverseMap();

        CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
        CreateMap<Comment, UpdatedCommentResponse>().ReverseMap();

        CreateMap<Comment, GetListCommentListItemDto>()
            .ForMember(destinationMember: c => c.BlogName, memberOptions: opt => opt.MapFrom(c => c.Blog.Body))
            .ForMember(destinationMember: c => c.ApplicationUserIdName, memberOptions: opt => opt.MapFrom(c => c.ApplicationUser.User.FirstName + " " + c.ApplicationUser.User.LastName))
            .ReverseMap();

        CreateMap<IPaginate<Comment>, GetListResponse<GetListCommentListItemDto>>().ReverseMap();

        CreateMap<Comment, GetByIdCommentResponse>()
            .ForMember(destinationMember: c => c.BlogName, memberOptions: opt => opt.MapFrom(c => c.Blog.Body))
            .ForMember(destinationMember: c => c.ApplicationUserIdName, memberOptions: opt => opt.MapFrom(c => c.ApplicationUser.User.FirstName))
            .ReverseMap();

    }
}
