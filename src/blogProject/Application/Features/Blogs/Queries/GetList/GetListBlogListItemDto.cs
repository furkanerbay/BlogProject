using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Queries.GetList;

public class GetListBlogListItemDto : IDto
{
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string ApplicationUserIdName { get; set; }
}
