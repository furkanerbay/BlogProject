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

namespace Application.Features.ApplicationUsers.Commands.Delete;

public class DeleteApplicationUserCommand : IRequest<DeletedApplicationUserResponse>
{
    public int Id { get; set; }
    public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand, DeletedApplicationUserResponse>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;
        public DeleteApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository,IMapper mapper,ApplicationUserBusinessRules applicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _applicationUserBusinessRules = applicationUserBusinessRules;
        }
        public async Task<DeletedApplicationUserResponse> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
        {
            await _applicationUserBusinessRules.ApplicationUserIdShouldExist(request.Id);
            ApplicationUser mappedApplicationUser = _mapper.Map<ApplicationUser>(request);
            ApplicationUser deletedApplicationUser = await _applicationUserRepository.DeleteAsync(mappedApplicationUser);
            DeletedApplicationUserResponse response = _mapper.Map<DeletedApplicationUserResponse>(deletedApplicationUser);
            return response;
        }
    }
}
