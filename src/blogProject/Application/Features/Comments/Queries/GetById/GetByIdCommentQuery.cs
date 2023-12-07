using Application.Features.Comments.Rules;
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

namespace Application.Features.Comments.Queries.GetById;

public class GetByIdCommentQuery : IRequest<GetByIdCommentResponse>
{
    public int Id { get; set; }
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, GetByIdCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly CommentBusinessRules _commentBusinessRules;
        public GetByIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _commentBusinessRules = commentBusinessRules;
        }
        public async Task<GetByIdCommentResponse> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            Comment comment = await _commentRepository.GetAsync(
                predicate: c => c.Id == request.Id,
                include: c => c.Include(c => c.ApplicationUser.User).Include(c => c.Blog));
            GetByIdCommentResponse response = _mapper.Map<GetByIdCommentResponse>(comment);
            return response;
        }
    }
}
