using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.Delete;

public class DeletedUserOperationClaimResponse : IDto
{
    public int Id { get; set; }
}