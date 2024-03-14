using FutureProjects.Domain.Entities.DTOs;

namespace FutureProjects.Application.Abstractions.IServices
{
    public interface IAuthService
    {
        public Task<ResponseLogin> GenerateToken(RequestLogin user);
    }
}
