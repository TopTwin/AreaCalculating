using AreaCalculating;
using System;
using Xunit;


namespace AreaCalculatingTest
{
    public class CircleTest
    {
        /// <summary>
        /// Тестирование отрицательного радиуса круга
        /// </summary>
        [Fact]
        public void NegativeRadiusTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-5));
        }

        /// <summary>
        /// Тестирование вычисления площади круга
        /// </summary>
        [Fact]
        public void AreaCalculatingTest()
        {
            //Arrange
            Circle circle = new Circle(5);

            //Act
            double area = circle.GetArea();

            //Assert
            Assert.Equal(78.53981633974483, area);
        }
    }

    public class TriangleTest
    {
        /// <summary>
        /// Тестирование отрицательных сторон треугольника
        /// </summary>
        [Fact]
        public void NegativeSidesTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-5, 4, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle( 5,-4, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle( 5, 4,-3));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-5,-4, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-5, 4,-3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle( 5,-4,-3));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-5,-4,-3));
        }

        /// <summary>
        /// Тестирование ввода нуля в качестве значения стороны треугольника
        /// </summary>
        [Fact]
        public void ZeroSidesTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 4, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(5, 0, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(5, 4, 0));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 4, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(5, 0, 0));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, 0));
        }

        /// <summary>
        /// Тестирование некорректного ввода одной из сторон, при которой треугольник не существует
        /// </summary>
        [Fact]
        public void IsTriangleExistTest()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(15, 4, 3));
            Assert.Throws<ArgumentException>(() => new Triangle(4, 15, 3));
            Assert.Throws<ArgumentException>(() => new Triangle(4, 3, 15));
        }

        /// <summary>
        /// Тестирование является ли треугольник прямоугольным
        /// </summary>
        [Fact]
        public void IsTriangleRightAngledTest()
        {
            //Arrange
            Triangle triangle = new Triangle(3, 4, 5);

            //Act
            var isTriangleRightAngled = triangle.isTriangleRightAngled;

            //Assert
            Assert.True(isTriangleRightAngled);
        }

        /// <summary>
        /// Тестирование вычисления площади треугольника
        /// </summary>
        [Fact]
        public void AreaCalculatingTest()
        {
            //Arrange
            Triangle triangle = new Triangle(2, 2, 2);

            //Act
            var area = triangle.GetArea();

            //Assert
            Assert.Equal(1.7320508075688772, area);
        }
    }
}
