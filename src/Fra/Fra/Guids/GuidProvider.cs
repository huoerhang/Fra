﻿using Microsoft.Extensions.Options;
using System;
using Fra.DependencyInjection;

namespace Fra.Guids
{
    [Dependency]
    public class GuidProvider : IGuidProvider
    {
        public IGuidGenerator GuidGenerator { get; }

        public GuidProvider(IOptions<SequentialGuidGeneratorOptions> options)
        {
            if (options != null)
            {
                GuidGenerator = new SequentialGuidGenerator(options.Value);

                return;
            }

            GuidGenerator = SimpleGuidGenerator.Instance;
        }

        public Guid Create()
        {
            return GuidGenerator.Create();
        }
    }
}
