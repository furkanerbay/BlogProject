using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.EnableOtpAuthenticator;

public class EnabledOtpAuthenticatorResponse : IDto
{
    public string SecretKey { get; set; }
}