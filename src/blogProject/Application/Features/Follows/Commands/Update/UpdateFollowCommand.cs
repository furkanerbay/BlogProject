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

namespace Application.Features.Follows.Commands.Update;

public class UpdateFollowCommand : IRequest<UpdatedFollowResponse>
{
    public int Id { get; set; }
    public int ApplicationUserId { get; set; }
    public int ApplicationUserIdFollowedId { get; set; }
    public class UpdateFollowCommandHandler : IRequestHandler<UpdateFollowCommand, UpdatedFollowResponse>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        private readonly FollowBusinessRules _followBusinessRules;
        public UpdateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper, FollowBusinessRules followBusinessRules)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            _followBusinessRules = followBusinessRules;   
        }
        public async Task<UpdatedFollowResponse> Handle(UpdateFollowCommand request, CancellationToken cancellationToken)
        {
            Follow mappedFollow = _mapper.Map<Follow>(request);
            Follow updatedFollow = await _followRepository.UpdateAsync(mappedFollow);
            UpdatedFollowResponse response = _mapper.Map<UpdatedFollowResponse>(updatedFollow);
            return response;
        }
    }
}
