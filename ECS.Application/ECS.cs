﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Application
{
    public class ECS
    {
        private int Threshold { get; set; }

        public ECS(int threshold)
        {
            Threshold = threshold;
        }

        public void Regulate()
        {

        }

        public int GetCurrentTemperature()
        {
            return 0;
        }
    }
}