using Dumpify;

namespace App.IfElseResult;

public static class ObterPrivilegios
{
    //If-Else
    public static string GetUserRoles(UserRole userRole)
    {
        if (userRole == UserRole.Admin)
            return $"{UserRole.Admin}: Acesso total";
        else if (userRole == UserRole.User)
        {
            return $"{UserRole.User}: Acesso limitado";
        }
        else if (userRole == UserRole.Guest)
        {
            return $"{UserRole.Guest}: Acesso restrito";
        }

        return "Acesso negado";
    }


    public static string GetUserRolesByTernario(UserRole userRole)
    {
        return (userRole == UserRole.Admin) ? $"{UserRole.Admin}: Acesso total" :
               (userRole == UserRole.User) ? $"{UserRole.User}: Acesso limitado" :
               (userRole == UserRole.Guest) ? $"{UserRole.Guest}: Acesso restrito" :
               "Acesso negado";
    }
    
    public static string GetUserRolesByStrategy(UserRole userRole)
    {
        var result = userRole switch
        {
            UserRole.Admin => new AdminStrategy().GetRoleUser(userRole),
            UserRole.User => new UserStrategy().GetRoleUser(userRole),
            UserRole.Guest => new GuestStrategy().GetRoleUser(userRole),
            _ => new UserNoStrategy().GetRoleUser(userRole)
        };
        
        return result;
    }
}