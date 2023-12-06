using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Queries.GetById;

public class GetByIdApplicationUserQuery : IRequest<GetByIdApplicationUserResponse>
{
    public int Id { get; set; }
    public class GetByIdApplicationUserQueryHandler : IRequestHandler<GetByIdApplicationUserQuery, GetByIdApplicationUserResponse>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;
        public GetByIdApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, ApplicationUserBusinessRules applicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _applicationUserBusinessRules = applicationUserBusinessRules;
        }
        public async Task<GetByIdApplicationUserResponse> Handle(GetByIdApplicationUserQuery request, CancellationToken cancellationToken)
        {
            ApplicationUser? applicationUser = await _applicationUserRepository.GetAsync(b => b.Id == request.Id);
            await _applicationUserBusinessRules.ApplicationUserShouldBeExist(applicationUser);
            GetByIdApplicationUserResponse response = _mapper.Map<GetByIdApplicationUserResponse>(applicationUser);
            return response;
        }
    }
}
