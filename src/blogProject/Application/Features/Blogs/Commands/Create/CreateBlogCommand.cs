using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.Create;

public class CreateBlogCommand : IRequest<CreatedBlogResponse>
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int ApplicationUserId { get; set; }
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreatedBlogResponse>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, BlogBusinessRules blogBusinessRules)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<CreatedBlogResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(request);
            Blog addedBlog = await _blogRepository.AddAsync(blog);
            CreatedBlogResponse response = _mapper.Map<CreatedBlogResponse>(addedBlog);
            return response;
        }
    }
}
