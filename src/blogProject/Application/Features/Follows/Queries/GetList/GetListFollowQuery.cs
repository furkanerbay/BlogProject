using Application.Features.Follows.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Queries.GetList;

public class GetListFollowQuery : IRequest<GetListResponse<GetListFollowListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListFollowQueryHandler : IRequestHandler<GetListFollowQuery, GetListResponse<GetListFollowListItemDto>>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        private readonly FollowBusinessRules _followBusinessRules;
        public GetListFollowQueryHandler(IFollowRepository followRepository, IMapper mapper, FollowBusinessRules followBusinessRules)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            _followBusinessRules = followBusinessRules;
        }
        public async Task<GetListResponse<GetListFollowListItemDto>> Handle(GetListFollowQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Follow> getListedFollow = await _followRepository.GetListAsync(
                include : f => f.Include(f => f.ApplicationUser.User),
                index : request.PageRequest.Page,
                size : request.PageRequest.PageSize
                );
            GetListResponse<GetListFollowListItemDto> response = _mapper.Map<GetListResponse<GetListFollowListItemDto>>(getListedFollow);
            return response;
        }
    }
}
