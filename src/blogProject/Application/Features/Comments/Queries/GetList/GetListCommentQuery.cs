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

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentQuery : IRequest<GetListResponse<GetListCommentListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, GetListResponse<GetListCommentListItemDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListCommentListItemDto>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Comment> mappedComment = await _commentRepository.GetListAsync(
                include: c => c.Include(c => c.ApplicationUser.User).Include(c => c.Blog),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            GetListResponse<GetListCommentListItemDto> response = _mapper.Map<GetListResponse<GetListCommentListItemDto>>(mappedComment);
            return response;
        }
    }
}
