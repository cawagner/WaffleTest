using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WaffleTest;
using WaffleTest.Structure;

namespace WaffleTestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var testBase = typeof (BehaviorTests);
            foreach (string dll in args)
            {
                Assembly testAssembly = Assembly.LoadFrom(dll);
                IEnumerable<Type> testTypes = testAssembly.GetTypes().Where(t => !t.IsAbstract && testBase.IsAssignableFrom(t));

                foreach (var testType in testTypes)
                {
                    Console.WriteLine("** tests in " + testType.FullName);
                    Console.WriteLine();

                    var testMethods = testType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                    foreach (var testMethod in testMethods)
                    {
                        var testExecutor = new ConsoleTestExecutor();
                        dynamic testInstance = Activator.CreateInstance(testType);
                        testInstance.TestExecutor = testExecutor;

                        Console.WriteLine("* batch " + testMethod.Name);
                        testMethod.Invoke(testInstance, null);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
