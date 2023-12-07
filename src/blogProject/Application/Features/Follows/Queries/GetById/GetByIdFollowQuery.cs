using Application.Features.Follows.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Queries.GetById;

public class GetByIdFollowQuery : IRequest<GetByIdFollowResponse>
{
    public int Id { get; set; }
    public class GetByIdFollowQueryHandler : IRequestHandler<GetByIdFollowQuery, GetByIdFollowResponse>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        private readonly FollowBusinessRules _followBusinessRules;
        public GetByIdFollowQueryHandler(IFollowRepository followRepository,IMapper mapper,FollowBusinessRules followBusinessRules)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            _followBusinessRules = followBusinessRules;
        }
        public async Task<GetByIdFollowResponse> Handle(GetByIdFollowQuery request, CancellationToken cancellationToken)
        {
            Follow? getByFollow = await _followRepository.GetAsync(
                predicate: f => f.Id == request.Id,
                include: f => f.Include(f => f.ApplicationUser.User).Include(f => f.ApplicationUserIdFollowed.User)
                );
            GetByIdFollowResponse response = _mapper.Map<GetByIdFollowResponse>(getByFollow);
            return response;
        }
    }
}
