using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

namespace DependencyInjection
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DependencyAttribute : Attribute
    {
        public DependencyAttribute()
        {

        }
    }
}

