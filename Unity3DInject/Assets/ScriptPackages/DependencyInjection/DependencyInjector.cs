using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

namespace DependencyInjection
{
    public class DependencyInjector : MonoBehaviour
    {
        public static void InjectDependencies(object obj, IDependenciyCollection dependencies, bool verbose)
        {
            Type objType = obj.GetType();
            FieldInfo[] fields = objType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                if (Attribute.IsDefined(field, typeof(DependencyAttribute)))
                {
                    object dep = dependencies.GetDependencyType(field.FieldType);
                    if (dep != null)
                        field.SetValue(obj, dep);
                    else if (verbose)
                        Debug.Log(objType.FullName + " " + "<color=red>Couldn't find dependency</color> " + field.FieldType.FullName);

                }
            }
        }

        public static void InjectDependencies(object obj, IDependenciyCollection dependencies,IDependenciyCollection localDependencies, bool verbose)
        {
            Type objType = obj.GetType();
            FieldInfo[] fields = objType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                if (Attribute.IsDefined(field, typeof(DependencyAttribute)))
                {
                    object dep = localDependencies.GetDependencyType(field.FieldType);
                    if (dep == null)
                        dep = dependencies.GetDependencyType(field.FieldType);

                    if (dep != null)
                        field.SetValue(obj, dep);
                    else if (verbose)
                        Debug.Log(objType.FullName + " " + "<color=red>Couldn't find dependency</color> " + field.FieldType.FullName);

                }
            }
        }
    }
}