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

namespace Application.Features.Follows.Commands.Delete;

public class DeleteFollowCommand : IRequest<DeletedFollowResponse>
{
    public int Id { get; set; }
    public class DeleteFollowCommandHandler : IRequestHandler<DeleteFollowCommand, DeletedFollowResponse>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        private readonly FollowBusinessRules _followBusinessRules;
        public DeleteFollowCommandHandler(IFollowRepository followRepository, IMapper mapper, FollowBusinessRules followBusinessRules)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            _followBusinessRules = followBusinessRules;
        }
        public async Task<DeletedFollowResponse> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {
            Follow? follow = await _followRepository.GetAsync(predicate : f => f.Id == request.Id);
            Follow deletedFollow = await _followRepository.DeleteAsync(follow);
            DeletedFollowResponse response = _mapper.Map<DeletedFollowResponse>(deletedFollow);
            return response;
        }
    }
}
