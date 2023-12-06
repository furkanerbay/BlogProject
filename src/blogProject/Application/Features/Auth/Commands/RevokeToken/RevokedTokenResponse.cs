using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.RevokeToken;

public class RevokedTokenResponse : IDto
{
    public int Id { get; set; }
    public string Token { get; set; }
}
