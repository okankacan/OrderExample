using CustomerOrder.Core.Model.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CustomerOrder.Core.Model.DbModel
{
    [Table("CustomerOrders", Schema = "dbo")]
    [Serializable]
    public class CustomerOrders : PersistentEntity
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
