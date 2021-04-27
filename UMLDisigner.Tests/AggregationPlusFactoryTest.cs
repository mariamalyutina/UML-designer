using System.Drawing;
using System.Collections;
using NUnit.Framework;

namespace UMLDisigner.Tests
{
    class AggregationPlusFactoryTest
    {
        [TestCaseSource(typeof(GetShapeOfAggregationPlusFactoryTestSource))]
        public static void GetShapeTest(AggregationPlusFactory factory, Color color, int width, IFigure expected)
        {
            IFigure actual = factory.GetShape(color, width);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetShapeOfAggregationPlusFactoryTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AggregationPlusFactory(false),
                Color.Blue,
                2,
                new Arrow(Color.Blue, 2, new StraightLine(), new WingsCap(),  new WhiteRombCap())
            };

            yield return new object[]
            {
                new AggregationPlusFactory(true),
                Color.Red,
                5,
                new Arrow(Color.Red, 5, new CurvedLine(), new WingsCap(),  new WhiteRombCap())
            };
        }
    }
}

