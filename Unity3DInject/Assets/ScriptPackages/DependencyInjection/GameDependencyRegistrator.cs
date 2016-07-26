using UnityEngine;

namespace DependencyInjection
{
    /// <summary>
    /// This class registeres all MonoBehaviours on the current gameobject in the global dependency collection
    /// </summary>
    public class GameDependencyRegistrator : MonoBehaviour
    {
        void Awake()
        {
            foreach (var component in gameObject.GetComponents<MonoBehaviour>())
            {
                if (!(component is GameDependencyRegistrator) && !(component is GameDependencySetter))
                    GameDependencies.RegisterDependency(component);
            }
        }
    }
}