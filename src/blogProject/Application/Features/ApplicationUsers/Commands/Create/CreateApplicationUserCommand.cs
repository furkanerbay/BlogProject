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

namespace Application.Features.ApplicationUsers.Commands.Create;

public class CreateApplicationUserCommand : IRequest<CreatedApplicationUserResponse>
{
    public int UserId { get; set; }
    public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, CreatedApplicationUserResponse>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;
        public CreateApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, ApplicationUserBusinessRules applicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _applicationUserBusinessRules = applicationUserBusinessRules;
        }

        public async Task<CreatedApplicationUserResponse> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser mappedApplicationUser = _mapper.Map<ApplicationUser>(request);
            ApplicationUser createdApplicationUser = await _applicationUserRepository.AddAsync(mappedApplicationUser);
            CreatedApplicationUserResponse response = _mapper.Map<CreatedApplicationUserResponse>(createdApplicationUser);
            return response;
        }
    }
}
