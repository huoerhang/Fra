namespace Fra.DependencyInjection
{
    public class ObjectAccessor<T> : IObjectAccessor<T>
    {

        public ObjectAccessor()
        {

        }

        public ObjectAccessor(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
