using Application.Features.Follows.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Commands.Create;

public class CreateFollowCommand : IRequest<CreatedFollowResponse>
{
    public int ApplicationUserId { get; set; }
    public int ApplicationUserIdFollowedId { get; set; }
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, CreatedFollowResponse>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        private readonly FollowBusinessRules _followBusinessRules;
        public CreateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper, FollowBusinessRules followBusinessRules)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            _followBusinessRules = followBusinessRules;
        }
        public async Task<CreatedFollowResponse> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {
            Follow mappedFollow = _mapper.Map<Follow>(request);
            await _followBusinessRules.IsItFollow(request.ApplicationUserId,request.ApplicationUserIdFollowedId);
            Follow addedFollow = await _followRepository.AddAsync(mappedFollow);
            CreatedFollowResponse response = _mapper.Map<CreatedFollowResponse>(addedFollow);
            return response;
        }
    }
}
