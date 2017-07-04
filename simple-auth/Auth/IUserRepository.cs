using System;
using System.Collections.Generic;

namespace simple_auth.Auth
{
    public interface IUserRepository
    {
        bool IsLocked(string username);
        void LockUser(string username);
    }

    public class UserRepo : IUserRepository
    {
        private IList<string> lockedUsers = new List<string>();

        public bool IsLocked(string username)
        {
            return lockedUsers.Contains(username);
        }

        public void LockUser(string username) {
            lockedUsers.Add(username);
        }
    }
}