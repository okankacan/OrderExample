using CustomerOrder.Core.Model.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerOrder.Core.Model.DbModel
{
    [Table("CustomerOrderDetails", Schema = "dbo")]
    [Serializable]
    public class CustomerOrderDetail : PersistentEntity
    {
        public int CustomerOrderId { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
