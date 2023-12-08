using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CreatedLikeResponse>
{
    public int BlogId { get; set; }
    public int ApplicationUserId { get; set; }
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CreatedLikeResponse>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        private readonly LikeBusinessRules _likeBusinessRules;
        public CreateLikeCommandHandler(ILikeRepository likeRepository, IMapper mapper, LikeBusinessRules likeBusinessRules)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            _likeBusinessRules = likeBusinessRules;
        }
        public async Task<CreatedLikeResponse> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            await _likeBusinessRules.IsItLike(request.BlogId,request.ApplicationUserId);

            Like mappedLike = _mapper.Map<Like>(request);
            Like addedLike = await _likeRepository.AddAsync(mappedLike);
            CreatedLikeResponse response = _mapper.Map<CreatedLikeResponse>(addedLike);
            return response;
        }
    }
}
