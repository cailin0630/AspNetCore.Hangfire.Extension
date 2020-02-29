using System.Threading.Tasks;

namespace AspNetCore.Hangfire.Extension.SimpleRecurringJob
{
    /// <summary>
    /// 基础循环任务类，后续可能有扩展应用
    /// </summary>
    public abstract class BaseRecurringJob
    {
        /// <summary>
        /// 执行job
        /// </summary>
        /// <returns></returns>
        public abstract Task Execute();
    }
}
