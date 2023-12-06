using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityService.ApplicationUserService;

public interface IApplicationUserService
{
    public Task<ApplicationUser> Add(ApplicationUser applicationUser);
}
