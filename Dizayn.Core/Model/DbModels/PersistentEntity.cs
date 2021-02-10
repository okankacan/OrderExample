using CustomerOrder.Core.Model.Attributes;
using CustomerOrder.Core.Model.DbModels.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CustomerOrder.Core.Model.DbModels

{

    [Serializable]
    public   class PersistentEntity: IPersistentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        [EditorType("Key")]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
