using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery : IRequest<GetListResponse<GetListCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, GetListResponse<GetListCategoryListItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListCategoryListItemDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Category> getListedCategory = await _categoryRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
                );
            GetListResponse<GetListCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryListItemDto>>(getListedCategory);
            return response;
        }
    }
}