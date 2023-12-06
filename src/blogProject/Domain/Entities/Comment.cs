using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Comment : Entity
{
    public int BlogId { get; set; }
    public int ApplicationUserId { get; set; }
    public string CommentMessage { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual Blog Blog { get; set; }
    public Comment()
    {

    }
    public Comment(int id, int blogId, int applicationUserId) : base(id)
    {
        BlogId = blogId;
        ApplicationUserId = applicationUserId;
    }
}
