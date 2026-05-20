using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms
{

    internal interface IPresenter
    {
        IModel Model { get; }
        IView View { get; }
    }

    internal interface IPresenter<TArgs> : IPresenter
    {
        void LoadArgs(TArgs args);
    }
}
