using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands.Update;

public class UpdatedLikeResponse
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public int ApplicationUserId { get; set; }
}
