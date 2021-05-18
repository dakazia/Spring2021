using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Task1.DoNotChange;

namespace Task1
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _dictionary = new Dictionary<Type, Type>();

        public void AddAssembly(Assembly assembly)
        {
            if (assembly is null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            var dicTypes = assembly.GetTypes().Where(t =>
                Attribute.IsDefined(t, typeof(ExportAttribute)) ||
                Attribute.IsDefined(t, typeof(ImportConstructorAttribute)) ||
                t.GetProperties().Any(p => Attribute.IsDefined(p, typeof(ImportAttribute))) ||
                t.GetFields().Any(f => Attribute.IsDefined(f, typeof(ImportAttribute))));

            foreach (var type in dicTypes)
            {
                if (type.GetCustomAttributes(typeof(ExportAttribute)).FirstOrDefault() is null)
                {
                    AddType(type);
                }
                else if ((type.GetCustomAttributes(typeof(ExportAttribute)).FirstOrDefault() as ExportAttribute)?.Contract != null)
                {
                    AddType(type, (type.GetCustomAttributes(typeof(ExportAttribute)).First() as ExportAttribute)?.Contract);
                }
                else
                {
                    AddType(type);
                }
            }
        }

        public void AddType(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!_dictionary.ContainsKey(type))
            {
                _dictionary.Add(type, type);
            }
            else
            {
                throw new ArgumentException("Type has already been added.", nameof(type));
            }
        }

        public void AddType(Type type, Type baseType)
        {
            if (!_dictionary.ContainsKey(type))
            {
                _dictionary.Add(baseType, type);
                _dictionary.Add(type, type);
            }
            else
            {
                throw new ArgumentException("Type has already been added.", nameof(type));
            }
        }

        private object Get(Type type)
        {

            if (!_dictionary.ContainsKey(type))
            {
                throw new ArgumentException("Type is not added to container");
            }

            var addedType = _dictionary[type];

            if (addedType.IsAbstract)
            {
                throw new ArgumentException("Type is abstract", nameof(type));
            }

            object obj;

            var ctor = addedType.GetConstructors().Where(x => x.GetParameters().Length > 0);

            if (addedType.GetCustomAttributes(typeof(ImportConstructorAttribute), true).Length >= 1)
            {
                var ctorParameters = ctor.First().GetParameters();
                obj = Activator.CreateInstance(addedType, ctorParameters.Select(p => Get(p.ParameterType)).ToArray());
                return obj;
            }

            var props = addedType.GetProperties().Where(p => p.GetCustomAttribute(typeof(ImportAttribute), true) != null);

            obj = Activator.CreateInstance(addedType);

            foreach (var p in props)
            {
                if (_dictionary.ContainsKey(p.PropertyType))
                {
                    var propInstance = Get(p.PropertyType);

                    p.SetValue(obj, propInstance);
                }
            }

            return obj;
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }
    }
}