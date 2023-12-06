using Application.Features.ApplicationUsers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Rules;

public class ApplicationUserBusinessRules : BaseBusinessRules
{
    private readonly IApplicationUserRepository _applicationUserRepository;
    public ApplicationUserBusinessRules(IApplicationUserRepository applicationUserRepository)
    {
        _applicationUserRepository = applicationUserRepository;
    }
    public async Task ApplicationUserIdShouldExist(int id)
    {
        ApplicationUser? result = await _applicationUserRepository.GetAsync(predicate : p => p.Id == id, enableTracking:false);
        if(result == null)
            throw new BusinessException(ApplicationUsersMessages.ApplicationUserNotExists);
    }

    public Task ApplicationUserShouldBeExist(ApplicationUser? applicationUser)
    {
        if(applicationUser is null)
            throw new BusinessException(ApplicationUsersMessages.ApplicationUserNotExists);
        return Task.CompletedTask;
    }
}
