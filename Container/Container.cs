using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> bindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            bindings[interfaceType] = implementationType;
        }
        public T Get<T>()
        {
            try
            {
                Type interfaceType = typeof(T);
                if (bindings.TryGetValue(interfaceType, out Type implementatonType))
                {
                    if (Activator.CreateInstance(implementatonType) is T instance)
                    {
                        return instance;
                    }
                }
            }
            catch (exception)
            {
                return default(T);
            }
            return default(T);
        }
    }
}