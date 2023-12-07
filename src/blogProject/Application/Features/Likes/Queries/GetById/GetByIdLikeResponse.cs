using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Queries.GetById;

public class GetByIdLikeResponse
{
    public int Id { get; set; }
    public string BlogName { get; set; }
    public string ApplicationUserIdName { get; set; }
}
