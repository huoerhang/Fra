using Microsoft.Extensions.Options;
using System;
using Fra.DependencyInjection;

namespace Fra.Guids
{
    [Dependency]
    public class GuidProvider : IGuidProvider
    {
        public SequentialGuidGeneratorOptions? Options { get; }

        public GuidProvider(IOptions<SequentialGuidGeneratorOptions> options)
        {
            if (options != null)
            {
                Options = options.Value;
            }
        }

        public Guid Create()
        {
            if (Options == null)
            {
                return SimpleGuidGenerator.Instance.Create();
            }

            return new SequentialGuidGenerator(Options).Create();
        }
    }
}
