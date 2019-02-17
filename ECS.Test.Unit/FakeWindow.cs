using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Application;

namespace ECS.Test.Unit
{
    public class StubWindow : IWindow
    {
        public void Open()
        {
           
        }

        public void Close()
        {
           
        }
    }

    public class MockWindow : IWindow
    {
        public int OpenCalledTimes { get; private set; }
        public int CloseCalledTimes { get; private set; }
        public void Open()
        {
            OpenCalledTimes++;
        }

        public void Close()
        {
            CloseCalledTimes++;
        }
    }
}