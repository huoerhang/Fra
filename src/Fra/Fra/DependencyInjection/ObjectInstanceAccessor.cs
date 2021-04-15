﻿namespace Fra.DependencyInjection
{
    internal class ObjectInstanceAccessor<T>
    {
        public ObjectInstanceAccessor(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
