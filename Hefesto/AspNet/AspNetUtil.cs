using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hefesto.AspNet
{
    public class AspNetUtil
    {
        /// <summary>
        /// Obtiene listado de acciones de todos los controladores escaneados de los Assemblies del proyecto
        /// </summary>
        /// <param name="controllerType">typeof(Microsoft.AspNetCore.Mvc.Controller)</param>
        /// <returns></returns>
        public static List<object> jsonGetAllControllerActions(Type controllerType)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            assemblies = assemblies.Where(x => x.FullName.StartsWith("Dorothy")).ToArray();

            List<object> list = new List<object>();

            if (assemblies != null && assemblies.Count() > 0)
            {
                foreach (Assembly asm in assemblies)
                {
                    var controlleraction = asm.GetTypes();

                    foreach (var type in controlleraction)
                    {
                        try
                        {
                            var rr = type.CustomAttributes.Where(x => x.AttributeType.Name.Contains("RouteAttribute")).Select(y => y.ConstructorArguments.FirstOrDefault().Value);

                            if (controllerType.IsAssignableFrom(type))
                            {
                                MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
                                methods = methods.Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any()).ToArray();

                                foreach (var m in methods)
                                {
                                    if (m.ReturnType.Name == "IActionResult")
                                    {
                                        List<string> endpoints = new List<string>();
                                        foreach (var endpoint in rr)
                                        {
                                            string ep = endpoint.ToString().Replace("[area]", m.DeclaringType.Namespace.Split('.').Reverse().Skip(1).FirstOrDefault());
                                            ep = ep.Replace("[controller]", m.DeclaringType.Name.Replace("Controller", ""));

                                            foreach (var mAction in m.CustomAttributes)
                                            {
                                                if (mAction.ConstructorArguments != null && mAction.ConstructorArguments.Count > 0)
                                                {
                                                    if (mAction.ConstructorArguments.Count > 1)
                                                    {
                                                        ep = $"{ep}/{mAction.ConstructorArguments.FirstOrDefault().Value.ToString()}";
                                                    }
                                                    else
                                                    {
                                                        ep = $"{ep}/{mAction.ConstructorArguments.FirstOrDefault().Value.ToString()}";
                                                    }
                                                }
                                            }

                                            ep = ep.Replace("//", "/");
                                            ep = ep.ToLower();

                                            endpoints.Add(ep);
                                        }

                                        Dictionary<object, object> dic = new Dictionary<object, object>();

                                        dic.Add("Controller", m.DeclaringType.Name);
                                        dic.Add("Area", m.DeclaringType.Namespace.Split('.').Reverse().Skip(1).FirstOrDefault());
                                        dic.Add("Action", m.Name);
                                        dic.Add("Route", String.Join(", ", rr));
                                        dic.Add("RouteUrl", String.Join(", ", endpoints));
                                        dic.Add("Attributes", String.Join(", ", m.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))));
                                        dic.Add("ReturnType", m.ReturnType.Name);

                                        list.Add(dic);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
            }

            return list;
        }
    }
}
