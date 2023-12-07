using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MailKit.Net.Imap;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Queries.GetById;

public class GetByIdBlogQuery : IRequest<GetByIdBlogResponse>
{
    public int Id { get; set; }
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, GetByIdBlogResponse>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        public GetByIdBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper, BlogBusinessRules blogBusinessRules)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }
        public async Task<GetByIdBlogResponse> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(
                predicate : b => b.Id == request.Id,
                include : b => b.Include(b => b.ApplicationUser.User).Include(b => b.Category));

            GetByIdBlogResponse response = _mapper.Map<GetByIdBlogResponse>(blog);
            return response;
        }
    }
}
