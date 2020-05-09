using System;
using System.Collections.Generic;
using System.Linq;

using ConditonalLinqQueryEngine.Extensions;

using NUnit.Framework;

namespace ConditionLinqQueryEngine.Test
{
    public class ReverseIfTest
    {
        [Test]
        public void ShouldReturn_SameColors_When_Parameter_IfFalse()
        {
            IEnumerable<string> colours = new string[] { "red", "blue", "yellow", "black", "white" };

            IEnumerable<string> result = colours.ReverseIf(false);

            Assert.AreEqual(colours, result);
        }

        [Test]
        public void ShouldReturn_ReverseColors_When_Parameter_IfTrue()
        {
            IEnumerable<string> colours = new string[] { "red", "blue", "yellow", "black", "white" };

            IEnumerable<string> result = colours.ReverseIf(true);

            Assert.AreEqual(colours.Reverse(), result);
        }
    }
}
