using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands.Delete;

public class DeleteLikeCommand : IRequest<DeletedLikeResponse>
{
    public int Id { get; set; }
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, DeletedLikeResponse>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public DeleteLikeCommandHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<DeletedLikeResponse> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            Like mappedLike = _mapper.Map<Like>(request);
            Like deletedLike = await _likeRepository.DeleteAsync(mappedLike);
            DeletedLikeResponse response = _mapper.Map<DeletedLikeResponse>(deletedLike);
            return response;
        }
    }
}
