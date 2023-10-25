using Core.Entities.Concrete;

namespace Core.Utilities.Security.Tokens
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
