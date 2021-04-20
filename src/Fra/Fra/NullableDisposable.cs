﻿using System;

namespace Fra
{
    public sealed class NullableDisposable : IDisposable
    {
        public static NullableDisposable Instance { get; } = new NullableDisposable();

        private NullableDisposable()
        {

        }

        public void Dispose()
        {

        }
    }
}
