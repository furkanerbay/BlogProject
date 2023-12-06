using Application.Features.ApplicationUsers.Commands.Create;
using Application.Features.ApplicationUsers.Commands.Delete;
using Application.Features.ApplicationUsers.Commands.Update;
using Application.Features.ApplicationUsers.Queries.GetById;
using Application.Features.ApplicationUsers.Queries.GetByUserId;
using Application.Features.ApplicationUsers.Queries.GetList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationUser, CreateApplicationUserCommand>().ReverseMap();
        CreateMap<ApplicationUser, CreatedApplicationUserResponse>().ReverseMap();
        CreateMap<ApplicationUser, UpdateApplicationUserCommand>().ReverseMap();
        CreateMap<ApplicationUser, UpdatedApplicationUserResponse>().ReverseMap();
        CreateMap<ApplicationUser, DeleteApplicationUserCommand>().ReverseMap();
        CreateMap<ApplicationUser, DeletedApplicationUserResponse>().ReverseMap();
        CreateMap<ApplicationUser, GetByIdApplicationUserResponse>().ReverseMap();
        CreateMap<ApplicationUser, GetByUserIdApplicationUserQuery>().ReverseMap();
        CreateMap<ApplicationUser, GetListApplicationUserListItemDto>().ReverseMap();
        CreateMap<IPaginate<ApplicationUser>, GetListResponse<GetListApplicationUserListItemDto>>().ReverseMap();
    }
}