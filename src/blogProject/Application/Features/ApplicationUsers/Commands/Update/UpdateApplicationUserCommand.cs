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

namespace Application.Features.ApplicationUsers.Commands.Update;

public class UpdateApplicationUserCommand : IRequest<UpdatedApplicationUserResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public class UpdateApplicationUserCommandHandler : IRequestHandler<UpdateApplicationUserCommand, UpdatedApplicationUserResponse>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;
        public UpdateApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository,IMapper mapper, ApplicationUserBusinessRules applicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _applicationUserBusinessRules = applicationUserBusinessRules;
        }
        public async Task<UpdatedApplicationUserResponse> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser mappedApplicationUser = _mapper.Map<ApplicationUser>(request);
            ApplicationUser updatedApplicationUser = await _applicationUserRepository.UpdateAsync(mappedApplicationUser);
            UpdatedApplicationUserResponse response = _mapper.Map<UpdatedApplicationUserResponse>(updatedApplicationUser);
            return response;
        }
    }
}
