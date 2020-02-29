using System;

namespace AspNetCore.Hangfire.Extension.Attributes
{
    /// <summary>
    /// job配置标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SimpleJobAttribute : Attribute
    {
        /// <summary>
        /// Cron表达式
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// job唯一标识
        /// </summary>
        public string JobId { get; set; }
    }
}
