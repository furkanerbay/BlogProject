using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetById;

public class GetByIdOperationClaimResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
