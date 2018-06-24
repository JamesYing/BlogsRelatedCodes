using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireWeb
{
    public class MyActivator : Hangfire.JobActivator
    {
        private readonly IServiceProvider _serviceProvider;
        public MyActivator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public override object ActivateJob(Type jobType)
        {
            return _serviceProvider.GetService(jobType);
        }
    }
}
