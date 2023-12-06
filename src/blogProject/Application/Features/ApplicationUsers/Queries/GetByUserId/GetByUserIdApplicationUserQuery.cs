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

namespace Application.Features.ApplicationUsers.Queries.GetByUserId;

public class GetByUserIdApplicationUserQuery : IRequest<GetByUserIdApplicationUserResponse>
{
    public int UserId { get; set; }
    public class GetByUserIdApplicationUserQueryHandler : IRequestHandler<GetByUserIdApplicationUserQuery, GetByUserIdApplicationUserResponse>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;
        public GetByUserIdApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, ApplicationUserBusinessRules applicationBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _applicationUserBusinessRules = applicationBusinessRules;
        }
        public async Task<GetByUserIdApplicationUserResponse> Handle(GetByUserIdApplicationUserQuery request, CancellationToken cancellationToken)
        {
            ApplicationUser? applicationUser = await _applicationUserRepository.GetAsync(a => a.UserId == request.UserId);
            await _applicationUserBusinessRules.ApplicationUserShouldBeExist(applicationUser);
            GetByUserIdApplicationUserResponse response = _mapper.Map<GetByUserIdApplicationUserResponse>(applicationUser);
            return response;
        }
    }
}
