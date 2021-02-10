using CustomerOrder.Core.Model.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerOrder.Core.Model.DbModel
{
    [Table("Customers", Schema = "dbo")]
    [Serializable]
    public class Customer : PersistentEntity
    {
        public string UserName { get; set; }
        public string Email  { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }
}
