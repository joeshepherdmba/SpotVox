using System;
using System.Threading.Tasks;

namespace SpotVoxApp
{
	public interface IUserRepository
	{
		Task<User> LoginAsync (LoginViewModel loginViewModel);
		Task<User> RegisterAsync (RegisterViewModel registerViewModel);
		Task<User> GetUserByUserName (string userName);
	}
}

