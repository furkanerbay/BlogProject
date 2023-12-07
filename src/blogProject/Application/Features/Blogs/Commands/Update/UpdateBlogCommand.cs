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

namespace Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommand : IRequest<UpdatedBlogResponse>
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int ApplicationUserId { get; set; }
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, UpdatedBlogResponse>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, BlogBusinessRules blogBusinessRules)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<UpdatedBlogResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog mappedBlog = _mapper.Map<Blog>(request);
            Blog updatedBlog = await _blogRepository.UpdateAsync(mappedBlog);
            UpdatedBlogResponse response = _mapper.Map<UpdatedBlogResponse>(updatedBlog);
            return response;
        }
    }

}
