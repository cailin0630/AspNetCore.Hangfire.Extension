# AspNetCore.Hangfire.Extension
hangfire extension

### Add Hangfire
```
            services.AddHangfire(config =>
            {
                config.UseRedisStorage(
                    Configuration["RedisConnectionString"],
                    new RedisStorageOptions
                    {
                        Db = 7,
                        Prefix = "abc-sys"
                    });
            });
```
### Use Hangfire
```
            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() },
                IgnoreAntiforgeryToken = true,
                AppPath = "/swagger/index.html",
                DashboardTitle = "Abc Sys Hangfire Dashboard"
            });
            app.AddOrUpdateJobs();
```

### HangfireAuthorizationFilter
```    
    /// <summary>
    /// HangfireAuthorizationFilter
    /// </summary>
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        /// <summary>
        /// no authorize
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
```

### TestJob
```
    /// <summary>
    /// TestJob
    /// </summary>
    [SimpleJob(IsOpen = true, JobId = "TestJob", CronExpression = "0 0 8 * * ?")]
    public class TestJob : BaseRecurringJob
    {
        /// <summary>
        /// execute job
        /// </summary>
        /// <returns></returns>
        public override async Task Execute()
        {
            //todo job
        }
    }
```