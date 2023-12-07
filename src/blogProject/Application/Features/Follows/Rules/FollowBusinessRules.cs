using Application.Features.Follows.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Rules;

public class FollowBusinessRules : BaseBusinessRules
{
    private readonly IFollowRepository _followRepository;
    public FollowBusinessRules(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }
    //public async Task CategoryIdShouldExistWhenSelected(int )
    public async Task IsItFollow(int applicationUserId, int applicationUserIdFollowedId)
    {
        Follow? follow = await _followRepository.GetAsync(
            predicate : p => p.ApplicationUserId == applicationUserId && p.ApplicationUserIdFollowedId == applicationUserIdFollowedId);
        if (follow is not null)
            throw new BusinessException(FollowsMessages.IsItFollow);
    }

}
