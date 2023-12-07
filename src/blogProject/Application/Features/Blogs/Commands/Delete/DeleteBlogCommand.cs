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

namespace Application.Features.Blogs.Commands.Delete;

public class DeleteBlogCommand : IRequest<DeletedBlogResponse>
{
    public int Id { get; set; }
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, DeletedBlogResponse>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, BlogBusinessRules blogBusinessRules)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<DeletedBlogResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(predicate : b => b.Id == request.Id);
            Blog deletedBlog = await _blogRepository.DeleteAsync(blog);
            DeletedBlogResponse response = _mapper.Map<DeletedBlogResponse>(deletedBlog);
            return response;
        }
    }
}
