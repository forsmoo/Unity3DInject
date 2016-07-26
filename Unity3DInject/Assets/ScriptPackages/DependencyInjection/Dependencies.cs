using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

namespace DependencyInjection
{
    /// <summary>
    /// This class is responsible for keeping track of dependencies
    /// </summary>
    public class Dependencies : IDependenciyCollection, IEnumerable
    {
        bool verbose = false;
        bool viewRegistrations = false;
        IDictionary dependencies;

        public Dependencies(bool verbose = false, bool viewRegistraction = false)
        {
            this.viewRegistrations = viewRegistraction;
            this.verbose = verbose;
            dependencies = new Hashtable();
        }

        public object GetDependencyType(Type type)
        {
            if (type.IsInterface)
            {
                foreach (Type objType in dependencies.Keys)
                {
                    Type[] itypes = objType.GetInterfaces();
                    foreach (Type itype in itypes)
                        if (itype == type)
                            return dependencies[objType];
                }
            }
            else if (dependencies.Contains(type))
            {
                return dependencies[type];
            }

            return null;
        }
        
        public void Register(object dep)
        {
            if (viewRegistrations)
                Debug.Log("Register type " + dep.GetType());
            dependencies.Add(dep.GetType(), dep);
        }

        public IEnumerator GetEnumerator()
        {
            return dependencies.GetEnumerator();
        }
    }
}