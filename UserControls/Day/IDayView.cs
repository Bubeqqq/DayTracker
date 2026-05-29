using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Day
{
    internal interface IDayView: IView
    {
        int PixelsPerHour { get; }
        int LeftMargin { get; }
        int TotalWidth { get;}
        event EventHandler SizeChanged;
        void CreateAndPlaceTaskControl(TestTask task, int x, int y, int taskWidth, int height);
        void ModifyControl(int index, int x, int y, int taskWidth, int height);

    }
}
