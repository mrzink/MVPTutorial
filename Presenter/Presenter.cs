using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Presenter
{
    public class Presenter<T> where T : class
    {
        protected  IModel Model { get; private set; }
        protected T View { get; private set; }
        public Presenter(T view)
        {
            View = view;
        }
    }
}
