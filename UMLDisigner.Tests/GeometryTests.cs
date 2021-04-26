using NUnit.Framework;
using System.Drawing;


namespace UMLDisigner.Tests
{
    public class GeometryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public static void GetArrowTest(int mockNumber)
        {
            Point[] inputPoints = InputDataInGetArrowMockTests(mockNumber);
            Point endPoint = inputPoints[0]; 
            Point startPoint = inputPoints[1];

            Point[] expected = ExpectedPointsInGetArrowMockTests(mockNumber);
            Point[] actual = Geometry.GetArrow(endPoint, startPoint);

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }

        public static Point[] InputDataInGetArrowMockTests(int number)
        {
            Point[] points = new Point[2];
            switch (number)
            {
                case 1:
                    points[0] = new Point(0, 0);
                    points[1] = new Point(20, 20);
                    break;
                case 2:
                    points[0] = new Point(30, 30);
                    points[1] = new Point(2, 2);
                    break;
                case 3:
                    points[0] = new Point(30, 2);
                    points[1] = new Point(2, 40);
                    break;
                case 4:
                    points[0] = new Point(2, 40);
                    points[1] = new Point(30, 2);
                    break;
                case 5:
                    points[0] = new Point(20, 5);
                    points[1] = new Point(20, 30);
                    break;
                case 6:
                    points[0] = new Point(40, 10);
                    points[1] = new Point(5, 10);
                    break;
            }

            return points;
        }

        public static Point[] ExpectedPointsInGetArrowMockTests(int number)
        {
            Point[] points = new Point[4];
            switch (number)
            {
                case 1:
                    points[0] = new Point(3, 24);
                    points[1] = new Point(0, 0);
                    points[2] = new Point(24, 3);
                    points[3] = new Point(14, 14);
                    break;
                case 2:
                    points[0] = new Point(26, 5);
                    points[1] = new Point(30, 30);
                    points[2] = new Point(5, 26);
                    points[3] = new Point(15, 15);
                    break;
                case 3:
                    points[0] = new Point(6, 9);
                    points[1] = new Point(30, 2);
                    points[2] = new Point(30, 26);
                    points[3] = new Point(18, 18);
                    break;
                case 4:
                    points[0] = new Point(25, 32);
                    points[1] = new Point(2, 40);
                    points[2] = new Point(1, 15);
                    points[3] = new Point(13, 23);
                    break;
                case 5:
                    points[0] = new Point(5, 25);
                    points[1] = new Point(20, 5);
                    points[2] = new Point(35, 25);
                    points[3] = new Point(20, 25);
                    break;
                case 6:
                    points[0] = new Point(20, -5);
                    points[1] = new Point(40, 10);
                    points[2] = new Point(20, 25);
                    points[3] = new Point(20, 10);
                    break;
            }

            return points;
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public static void GetRombTest(int mockNumber)
        {
            Point[] inputPoints = InputDataInGetRombMockTests(mockNumber);
            Point endPoint = inputPoints[0];
            Point startPoint = inputPoints[1];

            Point[] expected = ExpectedPointsInGetRombMockTests(mockNumber);
            Point[] actual = Geometry.GetRomb(endPoint, startPoint);

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }


        public static Point[] InputDataInGetRombMockTests(int number)
        {
            Point[] points = new Point[2];
            switch (number)
            {
                case 1:
                    points[0] = new Point(20,20);
                    points[1] = new Point(50, 60);
                    break;
                case 2:
                    points[0] = new Point(30, 30);
                    points[1] = new Point(2, 2);
                    break;
                case 3:
                    points[0] = new Point(30, 2);
                    points[1] = new Point(2, 40);
                    break;
                case 4:
                    points[0] = new Point(2, 40);
                    points[1] = new Point(30, 2);
                    break;
                case 5:
                    points[0] = new Point(20, 5);
                    points[1] = new Point(20, 30);
                    break;
                case 6:
                    points[0] = new Point(40, 20);
                    points[1] = new Point(5, 20);
                    break;
            }

            return points;
        }

        public static Point[] ExpectedPointsInGetRombMockTests(int number)
        {
            Point[] points = new Point[4];
            switch (number)
            {
                case 1:
                    points[0] = new Point(20, 45);
                    points[1] = new Point(20, 20);
                    points[2] = new Point(44, 27);
                    points[3] = new Point(44, 52);
                    break;
                case 2:
                    points[0] = new Point(26, 5);
                    points[1] = new Point(30, 30);
                    points[2] = new Point(5, 26);
                    points[3] = new Point(1, 1);
                    break;
                case 3:
                    points[0] = new Point(6, 9);
                    points[1] = new Point(30, 2);
                    points[2] = new Point(30, 26);
                    points[3] = new Point(6, 34);
                    break;
                case 4:
                    points[0] = new Point(25, 32);
                    points[1] = new Point(2, 40);
                    points[2] = new Point(1, 15);
                    points[3] = new Point(25, 7);
                    break;
                case 5:
                    points[0] = new Point(5, 25);
                    points[1] = new Point(20, 5);
                    points[2] = new Point(35, 25);
                    points[3] = new Point(20, 45);
                    break;
                case 6:
                    points[0] = new Point(20, 5);
                    points[1] = new Point(40, 20);
                    points[2] = new Point(20, 35);
                    points[3] = new Point(0, 20);
                    break;
            }

            return points;
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public static void GetRectangleTest(int mockNumber)
        {
            Point[] inputPoints = InputDataInGetRectangleMockTests(mockNumber);
            Point endPoint = inputPoints[0];
            Point startPoint = inputPoints[1];

            Point[] expected = ExpectedPointsInGetRectangleMockTests(mockNumber);
            Point[] actual = Geometry.GetRectangle(endPoint, startPoint);

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }

        public static Point[] InputDataInGetRectangleMockTests(int number)
        {
            Point[] points = new Point[2];
            switch (number)
            {
                case 1:
                    points[0] = new Point(20, 20);
                    points[1] = new Point(50, 60);
                    break;
                case 2:
                    points[0] = new Point(30, 40);
                    points[1] = new Point(2, 5);
                    break;
                case 3:
                    points[0] = new Point(30, 2);
                    points[1] = new Point(2, 40);
                    break;
                case 4:
                    points[0] = new Point(2, 40);
                    points[1] = new Point(30, 2);
                    break;
                case 5:
                    points[0] = new Point(20, 5);
                    points[1] = new Point(20, 30);
                    break;

            }

            return points;
        }

        public static Point[] ExpectedPointsInGetRectangleMockTests(int number)
        {
            Point[] points = new Point[4];
            switch (number)
            {
                case 1:
                    points[0] = new Point(50, 60);
                    points[1] = new Point(50, 20);
                    points[2] = new Point(20, 20);
                    points[3] = new Point(20, 60);
                    break;
                case 2:
                    points[0] = new Point(2, 5);
                    points[1] = new Point(2, 40);
                    points[2] = new Point(30, 40);
                    points[3] = new Point(30, 5);
                    break;
                case 3:
                    points[0] = new Point(2, 40);
                    points[1] = new Point(2, 2);
                    points[2] = new Point(30, 2);
                    points[3] = new Point(30, 40);
                    break;
                case 4:
                    points[0] = new Point(30, 2);
                    points[1] = new Point(30, 40);
                    points[2] = new Point(2, 40);
                    points[3] = new Point(2, 2);
                    break;
                case 5:
                    points[0] = new Point(20, 30);
                    points[1] = new Point(20, 5);
                    points[2] = new Point(20, 5);
                    points[3] = new Point(20, 30);
                    break;
            }

            return points;
        }

        [TestCase(true, 1)]
        [TestCase(false, 2)]
        [TestCase(false, 3)]
        [TestCase(false, 4)]
        [TestCase(true, 5)]
        public static void FindPointInArrowTest(bool expected, int mockNumber)
        {
            Point[] inputPoints = InputDataInFindPointInArrowMockTests(mockNumber);
            Point leftPosition = inputPoints[0];
            Point rightPosition = inputPoints[1];
            Point checkedPoint = inputPoints[2];

            bool actual = Geometry.FindPointInArrow(leftPosition, rightPosition, checkedPoint);

            Assert.AreEqual(expected, actual);
        }

        public static Point[] InputDataInFindPointInArrowMockTests(int number)
        {
            Point[] points = new Point[3];
            switch (number)
            {
                case 1:
                    points[0] = new Point(20, 20);
                    points[1] = new Point(50, 60);
                    points[2] = new Point(30, 40);
                    break;
                case 2:
                    points[0] = new Point(30, 40);
                    points[1] = new Point(2, 5);
                    points[2] = new Point(60, 40);
                    break;
                case 3:
                    points[0] = new Point(30, 2);
                    points[1] = new Point(2, 40);
                    points[2] = new Point(2, 60);
                    break;
                case 4:
                    points[0] = new Point(2, 40);
                    points[1] = new Point(30, 2);
                    points[2] = new Point(70, 60);
                    break;
                case 5:
                    points[0] = new Point(20, 5);
                    points[1] = new Point(20, 30);
                    points[2] = new Point(20, 25);
                    break;

            }

            return points;
        }

        [TestCase(true, 1)]
        [TestCase(false, 2)]
        [TestCase(false, 3)]
        [TestCase(false, 4)]
        [TestCase(true, 5)]
        public static void FindPointInClassTest(bool expected, int mockNumber)
        {
            Point[] inputPoints = InputDataInFindPointInClassMockTests(mockNumber);
            Point mouseUpPosition = inputPoints[0];
            Point mouseDownPosition = inputPoints[1];
            Point checkedPoint = inputPoints[2];

            bool actual = Geometry.FindPointInArrow(mouseUpPosition, mouseDownPosition, checkedPoint);

            Assert.AreEqual(expected, actual);
        }

        public static Point[] InputDataInFindPointInClassMockTests(int number)
        {
            Point[] points = new Point[3];
            switch (number)
            {
                case 1:
                    points[0] = new Point(20, 20);
                    points[1] = new Point(50, 60);
                    points[2] = new Point(30, 40);
                    break;
                case 2:
                    points[0] = new Point(30, 40);
                    points[1] = new Point(2, 5);
                    points[2] = new Point(2, 40);
                    break;
                case 3:
                    points[0] = new Point(30, 2);
                    points[1] = new Point(2, 40);
                    points[2] = new Point(2, 60);
                    break;
                case 4:
                    points[0] = new Point(2, 40);
                    points[1] = new Point(30, 2);
                    points[2] = new Point(70, 60);
                    break;
                case 5:
                    points[0] = new Point(20, 5);
                    points[1] = new Point(20, 30);
                    points[2] = new Point(20, 25);
                    break;

            }

            return points;
        }

    }
}