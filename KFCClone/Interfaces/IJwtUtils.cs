using KFCClone.Models;

namespace KFCClone.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwt(User user);
    }
}
