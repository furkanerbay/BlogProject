using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Blog, CreateBlogCommand>().ReverseMap();
        CreateMap<Blog, CreatedBlogResponse>().ReverseMap();

        CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
        CreateMap<Blog, UpdatedBlogResponse>().ReverseMap();

        CreateMap<Blog, DeleteBlogCommand>().ReverseMap();
        CreateMap<Blog, DeletedBlogResponse>().ReverseMap();


        CreateMap<Blog, GetListBlogListItemDto>()
            .ForMember(destinationMember: b => b.CategoryName, memberOptions: opt => opt.MapFrom(c => c.Category.Name))
            .ForMember(destinationMember: b => b.ApplicationUserIdName, memberOptions: opt => opt.MapFrom(c => c.ApplicationUser.User.FirstName + " " + c.ApplicationUser.User.LastName))
            .ReverseMap();
        CreateMap<IPaginate<Blog>, GetListResponse<GetListBlogListItemDto>>()
            .ReverseMap();

        CreateMap<Blog, GetByIdBlogResponse>()
            .ForMember(destinationMember: b => b.CategoryName, memberOptions: opt => opt.MapFrom(c => c.Category.Name))
            .ForMember(destinationMember: b => b.ApplicationUserIdName, memberOptions: opt => opt.MapFrom(c => c.ApplicationUser.User.FirstName + " " + c.ApplicationUser.User.LastName))
            .ReverseMap();

    }
}
