using System.Collections.Generic;
using System.Linq;

using ConditonalLinqQueryEngine.Extensions;

using NUnit.Framework;

namespace ConditionLinqQueryEngine.Test
{
    public class TakeIfTest
    {
        [Test]
        public void ShouldReturn_SameColors_When_Parameter_IfFalse()
        {
            IEnumerable<string> colours = new string[] { "red", "blue", "yellow", "black", "white" };

            IEnumerable<string> result = colours.TakeIf(false, 2);

            Assert.AreEqual(colours, result);
        }

        [Test]
        public void ShouldReturn_TwoColors_When_Parameter_IfTrue()
        {
            IEnumerable<string> colours = new string[] { "red", "blue", "yellow", "black", "white" };

            IEnumerable<string> result = colours.TakeIf(true, 2);

            Assert.AreEqual(colours.Take(2), result);
        }
    }
}
