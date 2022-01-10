using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_DI
{
     class Container : IoContainer
    {
        public List<object> list = new List<object>();

        public void Register<T>() where T: class
        {
            list.Add((T)Activator.CreateInstance(typeof(T)));
        }
        public void Register<T,R>() where R: class, T
        {
            if (typeof(T).IsAssignableFrom(typeof(R)))
            {
                list.Add(Activator.CreateInstance(typeof(R)));
            }
        }
        public void Register<T>(Func<T> factory)
        {
            list.Add(factory());
        }
        public T Resolve<T>()
        {
            foreach(var item in list)
            {
                if (typeof(T).IsAssignableFrom(item.GetType()))
                {
                    return (T)item;
                }
            }
            throw new Exception();
        }   
    }
}
