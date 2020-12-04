using Aujourdhui.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Aujourdhui.Extensions
{
    public static class Constants
    {
        public enum Role
        {
            Master,
            Admin,
            Moderator,
            User
        }
    }
}
