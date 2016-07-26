using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

namespace DependencyInjection
{
    /// <summary>
    /// Utility class to invoke methods on objects
    /// </summary>
    public class MethodInvoker
    {
        public static void InvokeMethod(object obj, string methodName)
        {
            Type objType = obj.GetType();
            MethodInfo method = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (method != null)
            {
                method.Invoke(obj, null);
            }
        }
    }
}