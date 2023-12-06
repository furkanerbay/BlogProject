using Application.Features.Categories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Rules;

public class CategoryBusinessRules : BaseBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task CategoryIdShouldExistWhenSelected(int categoryId)
    {
        Category? result = await _categoryRepository.GetAsync(c => c.Id == categoryId);

        if (result == null)
            throw new BusinessException(CategoriesMessages.CategoryNotExists);
    }
    public async Task CanNotBeDuplicatedWhenInserted(string name)
    {
        Category? result = await _categoryRepository.GetAsync(c => c.Name.ToLower() == name.ToLower());

        if (result != null)
            throw new BusinessException(CategoriesMessages.CategoryNameExists);
    }
}