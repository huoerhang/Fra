using System;

namespace Fra.Guids
{
    public interface IGuidProvider
    {
        IGuidGenerator GuidGenerator { get; }

        Guid Create();
    }
}
