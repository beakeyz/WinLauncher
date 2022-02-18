using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using WinLauncher.src.net.events.data;
using WinLauncher.src.net.events.impl;

namespace WinLauncher.src.net.events
{
    public class EventBus
    {
        //TODO
        public Dictionary<object, List<EventCall>> calls;

        public EventBus()
        {
            calls = new Dictionary<object, List<EventCall>>();
        }

        public void Register(object c)
        {
            Type t = c.GetType();
            foreach (MethodInfo info in t.GetMethods())
            {
                Console.WriteLine("Method loop ... ");
                foreach (var at in info.CustomAttributes)
                {
                    Console.WriteLine("Attribute loop ...");
                    if (at.AttributeType == typeof(EventTarget))
                    {
                        Console.WriteLine("Found Function");
                        RegisterFunction((Func<Event, bool>)Delegate.CreateDelegate(typeof(Func<Event, bool>), null, info));
                    }
                }
            }
        }

        public void CallEvent(Event e)
        {
            List<EventCall> callList = calls[e.GetType()];
            if (callList != null && callList.Count != 0)
            {
                foreach (EventCall call in callList)
                {
                    call.call(e);
                }
            }
        }

        public void RegisterFunction(Func<Event, bool> func)
        {
            if (!func.Method.IsPublic)
            {
                Console.WriteLine("Method is not public");
                return;
            }

            ParameterInfo[] types = func.Method.GetParameters();

            if (types.Length > 0)
            {
                Console.WriteLine("Found params");
                object t = types[0].ParameterType;

                if (t != null)
                {
                    EventCall call = new EventCall(t, func);

                    if (!calls.ContainsKey(t))
                    {
                        calls.Add(t, new List<EventCall>());
                    }

                    Console.WriteLine("Call is added!");
                    Console.WriteLine(t.ToString());
                    Console.WriteLine(func.Method.Name);
                    calls[t].Add(call);
                }
                else
                {
                    Console.WriteLine("ParamType is null");
                }
            }
            else
            {
                Console.WriteLine("No params found");
            }
        }
    }

    public class EventCall
    {
        object clazz;
        Func<Event, bool> method;

        public EventCall(object pClass, Func<Event, bool> pMethod)
        {
            this.clazz = pClass;
            this.method = pMethod;
        }

        public void call(Event e){
            try
            {
                method.DynamicInvoke(e);
            }
            catch (MemberAccessException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }catch(ArgumentException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
