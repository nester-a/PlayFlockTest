using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFlockTest.Model
{
    public class UnitEventArgs
    {
        public string Message { get; }
        public UnitEventArgs(string message)
        {
            Message = message;
        }
    }
}
