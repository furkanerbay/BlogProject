using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommand : IRequest<UpdatedLikeResponse>
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public int ApplicationUserId { get; set; }
    public class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommand, UpdatedLikeResponse>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public UpdateLikeCommandHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedLikeResponse> Handle(UpdateLikeCommand request, CancellationToken cancellationToken)
        {
            Like mappedLike = _mapper.Map<Like>(request);
            Like updatedLike = await _likeRepository.UpdateAsync(mappedLike);
            UpdatedLikeResponse response = _mapper.Map<UpdatedLikeResponse>(updatedLike);
            return response;
        }
    }
}