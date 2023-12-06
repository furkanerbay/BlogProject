using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Constants;

public class ApplicationUsersOperationClaims
{
    public const string Admin = "applicationuser.admin";

    public const string Read = "applicationuser.read";
    public const string Write = "applicationuser.write";

    public const string Add = "applicationuser.add";
    public const string Update = "applicationuser.update";
    public const string Delete = "applicationuser.delete";
}
