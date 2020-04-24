namespace Petrolheads.Common
{
    public static class UserProfileHelper
    {
        public static bool CheckIfProfileOwner(string queryUserId, string currentUserId)
        {
            return queryUserId == currentUserId ? true : false;
        }
    }
}
