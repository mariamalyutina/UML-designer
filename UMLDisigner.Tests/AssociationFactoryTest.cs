using System.Drawing;
using System.Collections;
using NUnit.Framework;

namespace UMLDisigner.Tests
{
    class AssociationFactoryTest
    {
        [TestCaseSource(typeof(GetShapeOfAssociationFactoryTestSource))]
        public static void GetShapeTest(AssociationFactory factory, Color color, int width, IFigure expected)
        {
            IFigure actual = factory.GetShape(color, width);

            Assert.AreEqual(expected, actual);
        }
    }

    public class GetShapeOfAssociationFactoryTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AssociationFactory(false),
                Color.Blue,
                2,
                new Arrow(Color.Blue, 2, new StraightLine(), new WingsCap(),  null)
            };

            yield return new object[]
            {
                new AssociationFactory(true),
                Color.Red,
                5,
                new Arrow(Color.Red, 5, new CurvedLine(), new WingsCap(),  null)
            };
        }
    }
}

