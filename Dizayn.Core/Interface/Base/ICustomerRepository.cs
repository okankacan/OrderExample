﻿using CustomerOrder.Core.Contexts;
using CustomerOrder.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Core.Interface.Base
{
    public interface ICustomerRepository : IBaseRepository<Customer, BaseDbContext>
    {
    }
   
}
