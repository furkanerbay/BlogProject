using Application.Features.Likes.Rules;
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

namespace Application.Features.Likes.Queries.GetList;

public class GetListLikeQuery : IRequest<GetListResponse<GetListLikeListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListLikeQueryHandler : IRequestHandler<GetListLikeQuery, GetListResponse<GetListLikeListItemDto>>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        private readonly LikeBusinessRules _likeBusinessRules;
        public GetListLikeQueryHandler(ILikeRepository likeRepository, IMapper mapper, LikeBusinessRules likeBusinessRules)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<GetListResponse<GetListLikeListItemDto>> Handle(GetListLikeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Like> likes = await _likeRepository.GetListAsync(
                //predicate:l => l.User.Status == true ,
                include: l => l.Include(l => l.Blog).Include(l => l.ApplicationUser.User),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            GetListResponse<GetListLikeListItemDto> mappedLikeListModel = _mapper.Map<GetListResponse<GetListLikeListItemDto>>(likes);
            return mappedLikeListModel;
        }
    }
}
