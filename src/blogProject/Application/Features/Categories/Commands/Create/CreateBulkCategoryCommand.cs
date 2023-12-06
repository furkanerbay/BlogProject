using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.Create;

public class CreateBulkCategoryCommand : IRequest<List<CreatedCategoryResponse>>
{
    public List<string> NameList { get; set; }
    public class CreateBulkCategoryCommandHandler : IRequestHandler<CreateBulkCategoryCommand, List<CreatedCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        public CreateBulkCategoryCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }
        public async Task<List<CreatedCategoryResponse>> Handle(CreateBulkCategoryCommand request, CancellationToken cancellationToken)
        {
            //if(request.NameList == null || request.NameList.Count == 0)
            List<Category> mappedListCategory = request.NameList
                .Select(
                    x =>
                        new Category
                        {
                            Name = x,
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now
                        }
                ).ToList();

            IList<Category> createdListCategory = await _categoryRepository.AddRangeAsync(mappedListCategory);
            List<CreatedCategoryResponse> result = createdListCategory
                .Select(x => new CreatedCategoryResponse { Id = x.Id, Name = x.Name })
                .ToList();
            return result;
        }
    }
}
