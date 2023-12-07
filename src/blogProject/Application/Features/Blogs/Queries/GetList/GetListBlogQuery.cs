using Application.Features.Blogs.Rules;
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

namespace Application.Features.Blogs.Queries.GetList;

public class GetListBlogQuery : IRequest<GetListResponse<GetListBlogListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, GetListResponse<GetListBlogListItemDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        public GetListBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper, BlogBusinessRules blogBusinessRules)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<GetListResponse<GetListBlogListItemDto>> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Blog> blogs = await _blogRepository.GetListAsync(
                include: b => b.Include(b => b.Category).Include(b => b.ApplicationUser.User),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            GetListResponse<GetListBlogListItemDto> mappedBlogListModel = _mapper.Map<GetListResponse<GetListBlogListItemDto>>(blogs);
            return mappedBlogListModel;
        }
    }
}
