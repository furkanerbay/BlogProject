using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Follow : Entity
{
    public int ApplicationUserId { get; set; }
    public int ApplicationUserIdFollowedId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual ApplicationUser ApplicationUserIdFollowed { get; set; }
    public Follow()
    {

    }
    public Follow(int id, int applicationUserId, int applicationUserIdFollowedId) : base(id)
    {
        ApplicationUserId = applicationUserId;
        ApplicationUserIdFollowedId = applicationUserIdFollowedId;
    }
}
