using Domain.Entities.SideInformation;
using Domain.Entities.People;
using Domain.Entities.People.Attribute;


namespace Domain.Entities.App;


public class User : Human
{
    public string? Password { get; set; }
    public string? Login { get; set; }

    public User(string login, 
                string password,
                string firstName,
                string secondName,
                string patronymicName,
                int contactNumber,
                Address address,
                DateTime dateOfBirth,
                Sex sex,
                int id) : base(id, firstName,secondName,patronymicName,contactNumber,sex,dateOfBirth,address)
    {
        Login = login ?? throw new NullReferenceException("Login is null");
        Password = password ?? throw new NullReferenceException("Password is null");
    }

    public User() { }  
}


public class Auth
{

    public Auth(string login, string password)
    {
        Password = password;
        Login = login;
    }

    string Password { get; }
    string Login { get; }

}