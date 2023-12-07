using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Queries.GetList;

public class GetListFollowListItemDto : IDto
{
    public int Id { get; set; }
    public string ApplicationUserIdFullName { get; set; }
    public string ApplicationUserIdFollowedFullName { get; set; }
}
