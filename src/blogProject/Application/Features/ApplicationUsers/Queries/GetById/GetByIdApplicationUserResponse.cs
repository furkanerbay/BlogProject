using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Queries.GetById;

public class GetByIdApplicationUserResponse : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
}
