using UnityEngine;
using System.Collections;
using System;

namespace DependencyInjection
{
    /// <summary>
    /// Registers all monobehaviours on this GameObject in it's local dependency collection
    /// </summary>
    public class DependencyRegistrator : MonoBehaviour,IDependenciyCollection
    {

        Dependencies locator = null;
        public bool RegisterAllComponents = true;

        public Dependencies Dependencies
        {
            get
            {
                if (locator == null)
                    locator = new Dependencies(false, false);
                return locator;
            }
        }

        void Awake()
        {
            foreach (var component in gameObject.GetComponents<MonoBehaviour>())
            {
                if( !(component is DependencyRegistrator || component is DependencySetter)) 
                    Dependencies.Register(component);
            }
        }
        
        public void Register(object dep)
        {
            Dependencies.Register(dep);
        }

        public object GetDependencyType(Type type)
        {
            return Dependencies.GetDependencyType(type);
        }
    }
}
