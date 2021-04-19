using System;

namespace Fra.Domain.Entities
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; }
    }
}
