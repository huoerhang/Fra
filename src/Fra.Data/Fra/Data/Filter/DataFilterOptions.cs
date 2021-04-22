using System;
using System.Collections.Generic;

namespace Fra.Data.Filter
{
    public  class DataFilterOptions
    {
        public Dictionary<Type,DataFilterState> DefaultStates { get; }

        public DataFilterOptions()
        {
            DefaultStates = new Dictionary<Type, DataFilterState>();
        }
    }
}
