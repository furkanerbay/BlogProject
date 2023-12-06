using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Commands.Delete;

public class DeletedApplicationUserResponse : IDto
{
    public int Id { get; set; }
}
