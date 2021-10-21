using System;

namespace Infrostructure
{
    public class AuthenticationInformation
    {
        public static Guid UserId { get; private set; }
        public static string UserName { get; private set; }
        public static void SetLoginInformation(Guid userId, string userName)
        {
            if(userId != Guid.Empty && UserName == null)
            {
                UserId = userId;
                UserName = userName;
            }
        }
    }
}
