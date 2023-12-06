using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }
    public virtual ICollection<Blog> Blogs { get; set; }
    public Category()
    {
        Blogs = new HashSet<Blog>();
    }

    public Category(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
