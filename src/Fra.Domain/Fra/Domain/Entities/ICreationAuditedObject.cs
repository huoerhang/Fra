using System;

namespace Fra.Domain.Entities
{
    public interface ICreationAuditedObject<TUserKey> : IHasCreationTime
    {
        TUserKey CreatorId { get; }
    }

    public interface ICreationAuditedObject : ICreationAuditedObject<Guid>
    {

    }
}
