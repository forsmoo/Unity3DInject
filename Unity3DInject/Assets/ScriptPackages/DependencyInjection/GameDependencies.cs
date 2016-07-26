using UnityEngine;
using System.Collections;
using System;

namespace DependencyInjection
{
    /// <summary>
    /// This class keeps track of all global dependencies in the game
    /// </summary>
    public class GameDependencies : MonoBehaviour,IDependenciyCollection, IEnumerable
    {
        Dependencies dependencies = new Dependencies();
        static GameDependencies instance;
        public bool Verbose = false;

        public static GameDependencies Instance
        {
            get
            {
                if (instance == null)
                    instance = (new GameObject("GameDependencies")).AddComponent<GameDependencies>();
                return instance;
            }
        }

        void Awake()
        {
            instance = this;
        }

        public void RegisterDependencyObject(object obj)
        {
            dependencies.Register(obj);
        }

        public static void RegisterDependency(object obj)
        {
            Instance.RegisterDependencyObject(obj);
        }
        
        public IEnumerator GetEnumerator()
        {
            return dependencies.GetEnumerator();
        }

        public object GetDependencyType(Type type)
        {
            return dependencies.GetDependencyType(type);    
        }

        public static void SetDependencies(object obj)
        {
            DependencyInjector.InjectDependencies(obj, Instance, Instance.Verbose);
        }

        public static void SetDependencies(GameObject go)
        {
            foreach( var component in go.GetComponents<MonoBehaviour>())
                DependencyInjector.InjectDependencies(component, Instance, Instance.Verbose);
        }
    }
}