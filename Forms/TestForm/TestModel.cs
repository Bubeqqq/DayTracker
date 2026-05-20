using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TestForm
{
    internal class TestModel : ITestModel
    {
        private ISceneLoader _sceneLoader;
        public ISceneLoader SceneLoader { get => _sceneLoader; set => _sceneLoader = value; }

        public void Print()
        {
            Console.WriteLine("TestModel Print method called.");
        }
    }
}
