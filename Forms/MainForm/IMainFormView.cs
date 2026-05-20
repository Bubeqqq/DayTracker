using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.MainForm
{
    internal interface IMainFormView : IView
    {
        void SetControl(UserControl form);
    }
}
