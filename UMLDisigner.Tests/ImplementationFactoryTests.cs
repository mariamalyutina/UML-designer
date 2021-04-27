using System.Drawing;
using System.Collections;
using NUnit.Framework;

namespace UMLDisigner.Tests
{
    class ImplementationFactoryTests
    {
        [TestCaseSource(typeof(GetShapeOfImplementationFactoryTestSource))]
        public static void GetShapeTest(ImplementationFactory factory, Color color, int width, IFigure expected)
        {
            IFigure actual = factory.GetShape(color, width);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetShapeOfImplementationFactoryTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ImplementationFactory(false),
                Color.Blue,
                2,
                new Arrow(Color.Blue, 2, new DashStraightLine(), new TriangleCap(),  null)
            };

            yield return new object[]
            {
                new ImplementationFactory(true),
                Color.Red,
                5,
                new Arrow(Color.Red, 5, new DashCurvedLine(), new TriangleCap(), null)
            };
        }
    }
}
