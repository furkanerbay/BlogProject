using Application.Services.EntityService.ApplicationUserService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityService.UserService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IApplicationUserService _applicationUserService;

    public UserManager(IUserRepository userRepository, IMapper mapper, IApplicationUserService applicationUserService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _applicationUserService = applicationUserService;
    }

    public async Task<User> AddWithApplicationUser(User user)
    {
        ApplicationUser mappedApplicationUser = new();
        mappedApplicationUser.UserId = user.Id;
        _applicationUserService.Add(mappedApplicationUser);
        return user;
    }

    public async Task<User?> GetByEmail(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        return user;
    }

    public async Task<User> GetById(int id)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        return user;
    }

    public async Task<User> Update(User user)
    {
        User updatedUser = await _userRepository.UpdateAsync(user);
        return updatedUser;
    }
}
