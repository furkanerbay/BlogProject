using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentListItemDto : IDto
{
    public string BlogName { get; set; }
    public string ApplicationUserIdName { get; set; }
    public string CommentMessage { get; set; }
}
