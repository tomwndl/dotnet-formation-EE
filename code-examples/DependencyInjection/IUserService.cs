namespace DependencyInjection;

public interface IUserService
{
  User? GetUser(string login);
  List<User> GetUsers();
}
