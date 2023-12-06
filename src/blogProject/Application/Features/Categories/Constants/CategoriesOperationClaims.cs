using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Constants;

public static class BrandsOperationClaims
{
    public const string Admin = "categories.admin";

    public const string Read = "categories.read";
    public const string Write = "categories.write";

    public const string Add = "categories.add";
    public const string Update = "categories.update";
    public const string Delete = "categories.delete";
}