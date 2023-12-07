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

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommand : IRequest<UpdatedCommentResponse>
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public int ApplicationUserId { get; set; }
    public string CommentMessage { get; set; }
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdatedCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly CommentBusinessRules _commentBusinessRules;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _commentBusinessRules = commentBusinessRules;
        }

        public async Task<UpdatedCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment mappedComment = _mapper.Map<Comment>(request);
            Comment updateComment = await _commentRepository.UpdateAsync(mappedComment);
            UpdatedCommentResponse response = _mapper.Map<UpdatedCommentResponse>(updateComment);
            return response;
        }
    }
}
