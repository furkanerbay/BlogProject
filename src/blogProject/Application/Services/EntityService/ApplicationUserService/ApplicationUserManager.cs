using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityService.ApplicationUserService;

public class ApplicationUserManager : IApplicationUserService
{
    private readonly IApplicationUserRepository _applicationUserRepository;
    public ApplicationUserManager(IApplicationUserRepository applicationUserRepository)
    {
        _applicationUserRepository = applicationUserRepository;
    }
    public async Task<ApplicationUser> Add(ApplicationUser applicationUser)
    {
        ApplicationUser addedApplicationUser = await _applicationUserRepository.AddAsync(applicationUser);
        return addedApplicationUser;
    }
}
