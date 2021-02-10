using CustomerOrder.Core.Contexts;
using CustomerOrder.Core.Interface.Base;
using CustomerOrder.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Infrastructure.Base
{
    public class CustomerRepository : BaseRepository<Customer, BaseDbContext>, ICustomerRepository
    {
    }
  
}
