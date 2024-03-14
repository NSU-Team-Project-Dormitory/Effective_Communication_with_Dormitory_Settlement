

using Domain.Entities.App;
using Domain.Entities.SideInformation;
using Domain.Repositories.Common;
using Domain.Repositories.SideInformation;

namespace Domain.Repositories.App;


public interface IUserRepository<UserType> : IDatabaseRepository<UserType> where UserType : User
{
    public void ResetPassword(int id, string oldPassword, string newPassword)
    {
        var user = Read(id);
        Update(user);
    }
    public Type GetUserSessionType() => typeof(UserType);

    IContactRepository ContactRepository { get; }
    IAddressRepository AddressRepository { get; }

}

public class UserRepositoryException : Exception
{
    public UserRepositoryException(string message) : base(message) { }
    public static UserRepositoryException PasswordError(string oldPassword, int id)
    {
        return new UserRepositoryException($"User-password with id {id} dosn't match with {oldPassword}");
    }

}