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
        /// 无参构造
        /// </summary>
        public SimpleJobAttribute()
        {

        }

        /// <summary>
        /// 带参数构造
        /// </summary>
        /// <param name="isOpen"></param>
        /// <param name="jobId"></param>
        /// <param name="cronExpression"></param>
        public SimpleJobAttribute(bool isOpen, string jobId, string cronExpression)
        {
            IsOpen = isOpen;
            JobId = jobId;
            CronExpression = cronExpression;
        }

        /// <summary>
        /// 是否开启
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// job唯一标识
        /// </summary>
        public string JobId { get; set; }
        /// <summary>
        /// Cron表达式
        /// </summary>

        public string CronExpression { get; set; }
    }
}
