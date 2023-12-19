using Lisit.Common;
using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Lisit.Services.Interfaces;

namespace Lisit.Services;
public class AuthServices : IAuthServices {

    private readonly IUsuarioRepository _repository;
    public AuthServices(IUsuarioRepository repository) {
        _repository = repository;
    }

    public async Task<Usuario> Login(string email, string password) {
        var user = await _repository.GetByEmail(email);
        if (user == null)
            throw new BusinessException("User not found");

        if (user.Password != password)
            throw new BusinessException("Password incorrect");
        return user;

    }

    public Task<int> Registrar(Usuario usuario) {
        throw new NotImplementedException();
    }
}
