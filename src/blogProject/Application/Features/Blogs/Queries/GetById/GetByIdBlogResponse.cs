using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Queries.GetById;

public class GetByIdBlogResponse
{
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string ApplicationUserIdName { get; set; }
}
