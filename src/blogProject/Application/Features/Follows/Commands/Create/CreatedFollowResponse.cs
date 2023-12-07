using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Commands.Create;

public class CreatedFollowResponse
{
    public int Id { get; set; }
    public int ApplicationUserId { get; set; }
    public int ApplicationUserIdFollowedId { get; set; }
}
