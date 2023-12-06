using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Queries.GetList;

public class GetListApplicationUserQuery : IRequest<GetListResponse<GetListApplicationUserListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListApplicationUserQueryHandler : IRequestHandler<GetListApplicationUserQuery, GetListResponse<GetListApplicationUserListItemDto>>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;
        public GetListApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, ApplicationUserBusinessRules applicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _applicationUserBusinessRules = applicationUserBusinessRules;
        }

        public async Task<GetListResponse<GetListApplicationUserListItemDto>> Handle(GetListApplicationUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ApplicationUser> applicationUsers = await _applicationUserRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
                );
            var mappedApplicationUserListModel = _mapper.Map<GetListResponse<GetListApplicationUserListItemDto>>(applicationUsers);
            return mappedApplicationUserListModel;
        }
    }
}
