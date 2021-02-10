using CustomerOrder.Core.Model.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CustomerOrder.Core.Model.DbModel
{
    [Table("Products", Schema = "dbo")]
    [Serializable]
    public class Product : PersistentEntity
    {
        public string Barcode { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
