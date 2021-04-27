using System.Drawing;
using System.Collections;
using NUnit.Framework;

namespace UMLDisigner.Tests
{
    class CompositionPlusFactoryTests
    {
        [TestCaseSource(typeof(GetShapeOfCompositionPlusFactoryTestSource))]
        public static void GetShapeTest(CompositionPlusFactory  factory, Color color, int width, IFigure expected)
        {
            IFigure actual = factory.GetShape(color, width);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetShapeOfCompositionPlusFactoryTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CompositionPlusFactory(false),
                Color.Blue,
                2,
                new Arrow(Color.Blue, 2, new StraightLine(), new WingsCap(),  new FilledRombCap())
            };

            yield return new object[]
            {
                new CompositionPlusFactory(true),
                Color.Red,
                5,
                new Arrow(Color.Red, 5, new CurvedLine(), new WingsCap(), new FilledRombCap())
            };
        }
    }
}
