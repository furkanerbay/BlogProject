using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Queries.GetById;

public class GetByIdFollowResponse
{
    public int Id { get; set; }
    public string ApplicationUserIdFullName { get; set; }
    public string ApplicationUserIdFollowedFullName { get; set; }
}
