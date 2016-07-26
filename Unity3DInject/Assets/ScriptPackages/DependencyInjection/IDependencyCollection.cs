using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Reflection;

namespace DependencyInjection
{
    /// <summary>
    /// Simple interface for dependency collections
    /// </summary>
    public interface IDependenciyCollection
    {
        object GetDependencyType(Type type);
    }

}