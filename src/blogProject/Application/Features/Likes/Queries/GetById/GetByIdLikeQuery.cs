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

namespace Application.Features.Likes.Queries.GetById;

public class GetByIdLikeQuery : IRequest<GetByIdLikeResponse>
{
    public int Id { get; set; }
    public class GetByIdLikeQueryHandler : IRequestHandler<GetByIdLikeQuery, GetByIdLikeResponse>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public GetByIdLikeQueryHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdLikeResponse> Handle(GetByIdLikeQuery request, CancellationToken cancellationToken)
        {
            Like like = await _likeRepository.GetAsync(
                predicate: l => l.Id == request.Id,
                include: l => l.Include(l => l.ApplicationUser.User).Include(l => l.Blog));
            GetByIdLikeResponse response = _mapper.Map<GetByIdLikeResponse>(like);
            return response;
        }
    }
}