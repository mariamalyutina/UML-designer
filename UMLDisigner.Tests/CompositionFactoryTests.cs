using System.Drawing;
using System.Collections;
using NUnit.Framework;

namespace UMLDisigner.Tests
{
    class CompositionFactoryTests
    {
        [TestCaseSource(typeof(GetShapeOfCompositionFactoryTestSource))]
        public static void GetShapeTest(CompositionFactory factory, Color color, int width, IFigure expected)
        {
            IFigure actual = factory.GetShape(color, width);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetShapeOfCompositionFactoryTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CompositionFactory(false),
                Color.Blue,
                2,
                new Arrow(Color.Blue, 2, new StraightLine(), new FilledRombCap(),  null)
            };

            yield return new object[]
            {
                new CompositionFactory(true),
                Color.Red,
                5,
                new Arrow(Color.Red, 5, new CurvedLine(), new FilledRombCap(), null)
            };
        }
    }
}
