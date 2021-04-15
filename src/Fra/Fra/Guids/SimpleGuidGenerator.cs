using System;

namespace Fra.Guids
{
    public class SimpleGuidGenerator : IGuidGenerator
    {
        private static SimpleGuidGenerator _simpleGuidGenerator = new SimpleGuidGenerator();
        public static SimpleGuidGenerator Instance => _simpleGuidGenerator;

        private SimpleGuidGenerator()
        {
        }

        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
