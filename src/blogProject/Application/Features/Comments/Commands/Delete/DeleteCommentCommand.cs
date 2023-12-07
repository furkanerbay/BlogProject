using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Commands.Delete;

public class DeleteCommentCommand : IRequest<DeletedCommentResponse>
{
    public int Id { get; set; }
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeletedCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly CommentBusinessRules _commentBusinessRules;
        public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _commentBusinessRules = commentBusinessRules;
        }
        public async Task<DeletedCommentResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            Comment mappedComment = _mapper.Map<Comment>(request);
            Comment deletedComment = await _commentRepository.DeleteAsync(mappedComment);
            DeletedCommentResponse response = _mapper.Map<DeletedCommentResponse>(deletedComment);
            return response;
        }
    }
}
