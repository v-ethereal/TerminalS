using System;

namespace Arsis.RentalSystem.Core.Bll
{
    public abstract class UserServiceHelper
    {
        public static  string GetNewAccessCode()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode()) + "X";
        }

        public static bool IsAccessCode(string accessCode)
        {
            return accessCode.EndsWith("X");
        }
    }
}