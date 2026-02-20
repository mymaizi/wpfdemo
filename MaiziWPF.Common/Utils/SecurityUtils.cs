using System;

namespace MaiziWPF.Common
{
    public class SecurityUtils
    {
        /**
         * 是否为管理员
         * 
         * @param userId 用户ID
         * @return 结果
         */
        public static bool IsAdmin(Int64 userId)
        {
            return userId != 0L && 1L == userId;
        }
    }
}
