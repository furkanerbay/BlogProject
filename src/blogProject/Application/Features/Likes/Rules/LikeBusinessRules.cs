using Application.Features.Follows.Constants;
using Application.Features.Likes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Rules;

public class LikeBusinessRules : BaseBusinessRules
{
    private readonly ILikeRepository _likeRepository;
    public LikeBusinessRules(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }
    public async Task IsItLike(int blogId, int applicationUserId)
    {
        Like? like = await _likeRepository.GetAsync(
            predicate : l => l.BlogId == blogId && l.ApplicationUserId == applicationUserId);

        if (like is not null)
            throw new BusinessException(LikesMessages.IsItLike);
    }
}
