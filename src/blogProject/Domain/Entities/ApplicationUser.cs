using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ApplicationUser : Entity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
    public virtual ICollection<Blog>? Blogs { get; set; }
    public ApplicationUser()
    {
        Comments = new HashSet<Comment>();
        Likes = new HashSet<Like>();
        Blogs = new HashSet<Blog>();
    }
    public ApplicationUser(int id, int userId) : this()
    {
        Id = id;
        UserId = userId;
    }
}
