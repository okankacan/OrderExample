

using System;

namespace CustomerOrder.Core.Model.DbModels.Interface
{
    public interface IDbEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime CreateDate { get; set; }
    }
}