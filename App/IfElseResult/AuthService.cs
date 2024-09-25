namespace App.IfElseResult;

public class AuthService
{
    private readonly IRoleUserStrategy _roleUserStrategy;

    public AuthService(IRoleUserStrategy roleUserStrategy)
    {
        _roleUserStrategy = roleUserStrategy;
    }

    public string GetUser(UserRole userRole)
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