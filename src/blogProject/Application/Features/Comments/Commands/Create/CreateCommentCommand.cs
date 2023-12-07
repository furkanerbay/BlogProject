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

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommand : IRequest<CreatedCommentResponse>
{
    public int BlogId { get; set; } 
    public int ApplicationUserId { get; set; }
    public string CommentMessage { get; set; }
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreatedCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly CommentBusinessRules _commentBusinessRules;
        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _commentBusinessRules = commentBusinessRules;
        }

        public async Task<CreatedCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment mappedComment = _mapper.Map<Comment>(request);
            Comment addedComment = await _commentRepository.AddAsync(mappedComment);
            CreatedCommentResponse response = _mapper.Map<CreatedCommentResponse>(addedComment);
            return response;
        }
    }
}
