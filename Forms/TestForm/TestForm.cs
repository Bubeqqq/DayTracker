using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayTracker.Forms.TestForm
{
    public partial class TestForm : UserControl, ITestView
    {
        public TestForm()
        {
            InitializeComponent();
            string test = "Shopping List (5)\r\n[] Buy whole milk (2 liters)\r\n[] Get organic eggs\r\n[] Pick up bread and cheese\r\nErrands (3)\r\n[x] Pay electricity bill (12.04)\r\n[] Drop off package at post office\r\n[x] Go to library (reserve book)\r\nProjects (2)\r\n[] Start working on WPF upgrade proposal\r\n[x] Finalize presentation slides (Q2)";

            toDoList.SetTODOList(test);
        }

        public event Action OnTestButtonClicked;

        private void button1_Click(object sender, EventArgs e)
        {
            OnTestButtonClicked?.Invoke();

            Console.WriteLine(toDoList.GetTODOList());
        }
    }
}
