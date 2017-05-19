using System;
using System.Diagnostics;
using Xunit;

namespace Ofl.Hashing.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            unchecked
            {
                int x = Int32.MaxValue + Int32.MaxValue + Int32.MaxValue + Int32.MaxValue;
                int y = Int32.MaxValue + 10;
            }
        }
    }
}
