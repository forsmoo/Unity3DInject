using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using DependencyInjection;
using System;

public class TestGamDependencyInjection {

	[Test]
	public void TestObjectDependencyInjection()
	{
        Dependencies dependencies = new Dependencies();
        DependentTestClass dependentObj = new DependentTestClass();
        DependencyTestClass dependency = new DependencyTestClass();
        dependencies.Register(dependency);
        DependencyInjector.InjectDependencies(dependentObj, dependencies, false);
        
        Assert.AreSame(dependentObj.testDependency,dependency);
    }
    
    [Test]
    public void TestInheritedObjectDependencyInjection()
    {
        Dependencies dependencies = new Dependencies();
        DependantBaseTestClass dependentObj = new DependantBaseTestClass();
        DependencyTestClass dependency = new DependencyTestClass();
        dependencies.Register(dependency);
        DependencyInjector.InjectDependencies(dependentObj, dependencies, false);

        Assert.AreSame(dependentObj.inheritedPublicDep, dependency);
    }

    [Test]
    public void TestInterfaceDependencyInjection()
    {
        Dependencies dependencies = new Dependencies();
        DependantBaseTestClass dependentObj = new DependantBaseTestClass();
        DependencyTestClass dependency = new DependencyTestClass();
        dependencies.Register(dependency);
        DependencyInjector.InjectDependencies(dependentObj, dependencies, false);

        Assert.AreSame(dependentObj.GetInterfaceDependency(), dependency);
    }

    class DependentTestBaseClass
    {
        [Dependency]
        public DependencyTestClass inheritedPublicDep;
        public float someValue;
    }

    class DependentTestClass
    {
        [Dependency]
        public DependencyTestClass testDependency;
        
    }

    class DependantBaseTestClass : DependentTestBaseClass
    {
        [Dependency]
        ITestDependencyInterface interfaceDependency;

        public ITestDependencyInterface GetInterfaceDependency()
        {
            return interfaceDependency;
        }
    }

    interface ITestDependencyInterface
    {
        void TestMethod(float newValue);
    }

    class DependencyTestClass : ITestDependencyInterface
    {
        public float SomenormalVariable = 0;

        public DependencyTestClass()
        {
            SomenormalVariable = 10;
        }
        
        public void TestMethod(float newValue)
        {
            SomenormalVariable = newValue;
        }
    }

}
