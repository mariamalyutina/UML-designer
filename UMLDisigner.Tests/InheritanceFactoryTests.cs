using System.Drawing;
using System.Collections;
using NUnit.Framework;

namespace UMLDisigner.Tests
{
    class InheritanceFactoryTests
    {
        [TestCaseSource(typeof(GetShapeOfInheritanceFactoryTestSource))]
        public static void GetShapeTest(InheritanceFactory factory, Color color, int width, IFigure expected)
        {
            IFigure actual = factory.GetShape(color, width);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetShapeOfInheritanceFactoryTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new InheritanceFactory(false),
                Color.Blue,
                2,
                new Arrow(Color.Blue, 2, new StraightLine(), new TriangleCap(), null)
            };

            yield return new object[]
            {
                new InheritanceFactory(true),
                Color.Red,
                5,
                new Arrow(Color.Red, 5, new CurvedLine(), new TriangleCap(),  null)
            };
        }
    }
}
