using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Like : Entity
{
    public int BlogId { get; set; }
    public int ApplicationUserId { get; set; }
    public virtual Blog Blog { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    public Like()
    {

    }
    public Like(int id, int applicationUserId, int blogId) : base(id)
    {
        BlogId = blogId;
        ApplicationUserId = applicationUserId;
    }
}
