﻿using System;

namespace Fra.Data.Filter
{
    public interface IDataFilter<TFilter>
        where TFilter : class
    {
        IDisposable Enable();

        IDisposable Disable();

        bool IsEnable { get; }
    }

    public interface IDataFilter
    {
        IDisposable Enable<TFilter>()
            where TFilter : class;

        IDisposable Disable<TFilter>()
            where TFilter : class;

        bool IsEnabled<TFilter>()
            where TFilter : class;
    }
}
