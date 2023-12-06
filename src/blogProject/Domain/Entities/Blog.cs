using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Blog : Entity
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int ApplicationUserId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public Blog()
    {
        Comments = new HashSet<Comment>();
        Likes = new HashSet<Like>();
    }

    public Blog(int id, int categoryId, string title, string body, int applicationUserId) : this()
    {
        Id = id;
        CategoryId = categoryId;
        Title = title;
        Body = body;
        ApplicationUserId = applicationUserId;
    }
}
