﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fra.Modularity
{
    internal static class ModuleTypeExtensions
    {
        public static void CheckEntryModuleType(this Type type)
        {
            if (!type.IsAssignableTo<IAppEntryModule>())
            {
                throw new Exception($"The {type.AssemblyQualifiedName} is not IAppEntryModule");
            }
        }

        public static bool IsAppModuleType(this Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return typeInfo.IsClass
                && !typeInfo.IsAbstract
                && !typeInfo.IsGenericType
                && typeInfo.IsAssignableTo<IAppModule>();
        }

        public static void CheckAppModuleType(this Type type)
        {
            if (!type.IsAppModuleType())
            {
                throw new ArgumentException($"The type {type.AssemblyQualifiedName} is not App Module:");
            }
        }
    }
}
