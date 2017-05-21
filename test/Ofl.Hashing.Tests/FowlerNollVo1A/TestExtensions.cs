using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ofl.Hashing.Tests.FowlerNollVo1A
{
    internal static class TestExtensions
    {
        internal static byte[] GetTestBytes(object test, bool nullTerminated, int? repeat)
        {
            // Validate parameters.
            if (test == null) throw new ArgumentNullException(nameof(test));

            // If test is *not* an array, put it in an array.
            if (!(test is Array)) test = new[] { test };

            // Get the array.
            var array = (Array)test;

            // The bytes.
            var bytes = new List<byte>();

            // Cycle through the elements in the array.
            foreach (object item in array)
            {
                // Sniff the type.
                var str = item as string;
                if (str != null)
                {
                    // Add.
                    bytes.AddRange(Encoding.ASCII.GetBytes(str));

                    // Continue.
                    continue;
                }

                // Add the byte.
                bytes.Add(Convert.ToByte(item));
            }

            // If repeat isn't null, repeat test that many times.
            if (repeat != null) bytes =
                Enumerable.Repeat(bytes, repeat.Value).SelectMany(l => l).ToList();

            // If this is null terminated, add a null character to the bytes.
            if (nullTerminated) bytes.Add(0);

            // Return bytes.
            return bytes.ToArray();
        }
    }
}
