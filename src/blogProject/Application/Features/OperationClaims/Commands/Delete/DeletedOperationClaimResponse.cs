using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Delete;

public class DeletedOperationClaimResponse : IDto
{
    public int Id { get; set; }
}
