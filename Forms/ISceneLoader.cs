using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms
{
    internal interface ISceneLoader
    {
        void LoadScene<TPresenter>() where TPresenter : IPresenter;

    }
}
