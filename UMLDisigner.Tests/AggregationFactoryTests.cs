using System.Drawing;
using System.Collections;
using NUnit.Framework;

namespace UMLDisigner.Tests
{
    class AggregationFactoryTests
    {
        [TestCaseSource(typeof(GetShapeOfAggregationFactoryTestSource))]
        public static void GetShapeTest(AggregationFactory factory, Color color, int width, IFigure expected)
        {
            IFigure actual = factory.GetShape(color, width);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetShapeOfAggregationFactoryTestSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AggregationFactory(false),
                Color.Blue,
                2,
                new Arrow(Color.Blue, 2, new StraightLine(), new WhiteRombCap(), null)
            };

            yield return new object[]
            {
                new AggregationFactory(true),
                Color.Red,
                5,
                new Arrow(Color.Red, 5, new CurvedLine(), new WhiteRombCap(),  null)
            };
        }
    }
}
