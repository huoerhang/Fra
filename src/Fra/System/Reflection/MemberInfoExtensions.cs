namespace System.Reflection
{
    public static class MemberInfoExtensions
    {
        public static TAttribute GetAttributeOfTypeOrBaseTypesOrNull<TAttribute>(this Type type, bool inherit = true)
            where TAttribute:Attribute
        {
            var attribute = type.GetTypeInfo().GetCustomAttribute<TAttribute>(inherit);

            if (attribute != null)
            {
                return attribute;
            }

            if (type.GetTypeInfo().BaseType == null)
            {
                return null;
            }

            return type.GetTypeInfo().BaseType.GetAttributeOfTypeOrBaseTypesOrNull<TAttribute>(inherit);
        }
    }
}
