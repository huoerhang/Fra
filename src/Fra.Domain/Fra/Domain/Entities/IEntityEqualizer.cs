﻿namespace Fra.Domain.Entities
{
    public interface IEntityEqualizer
    {
        bool EntityEquals(IEntity self, IEntity other);
    }
}
