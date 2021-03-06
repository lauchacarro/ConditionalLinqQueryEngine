﻿using System.Collections.Generic;
using System.Linq;

using ConditonalLinqQueryEngine.Extensions;

using NUnit.Framework;

namespace ConditionLinqQueryEngine.Test
{
    public class WhereIfTest
    {
        [Test]
        public void ShouldReturn_SameColors_When_Parameter_IfFalse()
        {
            IEnumerable<string> colours = new string[] { "red", "blue", "yellow", "black", "white" };

            IEnumerable<string> result = colours.WhereIf(false, x => x == "red");

            Assert.AreEqual(colours, result);
        }

        [Test]
        public void Should_Return_OnlyRed_When_Parameter_IfTrue()
        {
            IEnumerable<string> colours = new string[] { "red", "blue", "yellow", "black", "white" };

            IEnumerable<string> result = colours.WhereIf(true, x => x == "red");

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(colours.First(), result.First());

        }
    }
}
