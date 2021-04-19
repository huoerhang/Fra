using System;

namespace Fra.Domain.Entities
{
    public interface IHasModifyTime
    {
        DateTime? LastModifyTime { get; set; }
    }
}
