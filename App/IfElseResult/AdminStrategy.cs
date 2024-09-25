namespace App.IfElseResult;

public class AdminStrategy: IRoleUserStrategy
{
    public string GetRoleUser(UserRole userRole)=> $"{userRole}: Acesso total";
}

public class UserStrategy: IRoleUserStrategy
{
    public string GetRoleUser(UserRole userRole)=> $"{userRole}: Acesso limitado";

}

public class UserNoStrategy : IRoleUserStrategy
{
    public string GetRoleUser(UserRole userRole)=> $"{userRole}: Acesso negado";

}

public class GuestStrategy: IRoleUserStrategy
{
    public string GetRoleUser(UserRole userRole)=> $"{userRole}: Acesso restrito";

}