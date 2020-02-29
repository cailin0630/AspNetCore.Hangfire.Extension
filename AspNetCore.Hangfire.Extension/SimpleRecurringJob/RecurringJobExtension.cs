using AspNetCore.Hangfire.Extension.Attributes;
using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Hangfire.Extension.SimpleRecurringJob
{
    /// <summary>
    /// RecurringJob扩展类
    /// </summary>
    public static class RecurringJobExtension
    {
        /// <summary>
        /// 添加或更新循环任务
        /// </summary>
        /// <param name="app"></param>
        public static void AddOrUpdateJobs(this IApplicationBuilder app)
        {
            var recurringJobs = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(BaseRecurringJob))
                .ToArray();
            foreach (var recurringJob in recurringJobs)
            {
                var simpleJobAttr = recurringJob.GetCustomAttribute<SimpleJobAttribute>();
                if (simpleJobAttr == null)
                    continue;
                if (string.IsNullOrWhiteSpace(simpleJobAttr.JobId))
                {
                    throw new Exception($"{recurringJob}: JobId is null");
                }
                if (!simpleJobAttr.IsOpen)
                {
                    global::Hangfire.RecurringJob.RemoveIfExists(simpleJobAttr.JobId);
                    continue;
                }
                if (string.IsNullOrWhiteSpace(simpleJobAttr.CronExpression))
                {
                    throw new Exception($"{recurringJob}: CronExpression is null");
                }
                var recurringJobInst = (BaseRecurringJob)Activator.CreateInstance(recurringJob);
                global::Hangfire.RecurringJob.AddOrUpdate(simpleJobAttr.JobId, () => recurringJobInst.Execute(),
                    simpleJobAttr.CronExpression,
                    TimeZoneInfo.Local);
            }
        }
    }
}
