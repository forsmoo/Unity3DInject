using UnityEngine;
using System.Collections;

namespace DependencyInjection
{
    /// <summary>
    /// This component will set dependencies on itself and child components. If a local dependencies will override global dependencies where they exist
    /// </summary>
    public class DependencySetter : MonoBehaviour
    {
        public bool SetDependenciesOnAwake = true;
        public bool Verbose = false;

        void Awake()
        {
            if (SetDependenciesOnAwake)
                SetDependencies();
        }

        public void SetDependencies()
        {
            DependencyRegistrator localDependencies = GetComponent<DependencyRegistrator>();
            if (localDependencies == null)
                localDependencies = GetComponentInParent<DependencyRegistrator>();

            if (Verbose && localDependencies != null)
                Debug.Log("Using " + name + " as local dependencies");

            if (localDependencies == null)
            {
                //Didn't find a local dependency collection, so only inject global dependencies
                foreach (var component in GetComponentsInChildren<MonoBehaviour>())
                {
                    DependencyInjector.InjectDependencies(component, GameDependencies.Instance, Verbose);
                }
            }
            else
            {
                foreach (var component in GetComponentsInChildren<MonoBehaviour>())
                {
                    DependencyInjector.InjectDependencies(component, GameDependencies.Instance,localDependencies, Verbose);
                }
            }
        }
    }
}