using UnityEngine;
using System.Collections;

namespace DependencyInjection
{
    /// <summary>
    /// This class is responsible for setting up all dependencies in all globally registered instances
    /// </summary>
    public class GameDependencySetter : MonoBehaviour
    {
        public bool Verbose = false;
        static GameDependencySetter instance;
        void Awake()
        {
            //Only need to set the global game dependencies once
            if (instance != null)
            {
                DestroyImmediate(this);
                return;
            }
            instance = this;
            SetDependencies();
        }

        public void SetDependencies()
        {
            foreach (DictionaryEntry entry in GameDependencies.Instance)
            {
                var obj = entry.Value;
                if (Verbose)
                    Debug.Log("Setting dependencies on type " + obj.GetType());
                DependencyInjector.InjectDependencies(obj, GameDependencies.Instance, Verbose);
            }
        }
    }
}
