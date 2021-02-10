using System;

namespace CustomerOrder.Core.Interface.Data
{
    public interface IServiceProviderAccessor
    {
        IServiceProvider ServiceProvider { get; set; }
    }
}
