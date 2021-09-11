using System;

namespace AreaCalculating
{
    public abstract class Shape
    {
        protected double area;

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        abstract public double GetArea();
    }
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус
        /// </summary>
        public double radius { get; }

        /// <summary>
        /// Круг
        /// </summary>
        /// <param name="rad">Радиус</param>
        /// <exception cref="ArgumentOutOfRangeException">Если радиус имеет отрицательное значение</exception>
        public Circle(double rad)
        {
            if (rad < 0)
                throw new ArgumentOutOfRangeException("Радиус не может быть отрицательным");

            radius = rad;
            area = GetArea();
        }

        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        public override double GetArea()
        {
            //Вычисление площади круга
            double result = radius * radius * Math.PI;
            return result;
        }
    }

    public class Triangle : Shape
    {

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public bool isTriangleRightAngled { get; }

        /// <summary>
        /// Существует ли треугольник
        /// </summary>
        public bool isTriangleExist { get; }

        /// <summary>
        /// Первая сторона
        /// </summary>
        public double side_A { get; }

        /// <summary>
        /// Вторая сторона
        /// </summary>
        public double side_B { get; }

        /// <summary>
        /// Третья сторона
        /// </summary>
        public double side_C { get; }

        /// <summary>
        /// Треугольник
        /// </summary>
        /// <param name="firstSide">Первая сторона треугольника</param>
        /// <param name="secondSide">Вторая сторона треугольника</param>
        /// <param name="thirdSide">Третья сторона треугольника</param>
        /// <exception cref="ArgumentOutOfRangeException">Если сторона треугольника имеет отрицательное значение</exception>
        /// <exception cref="ArgumentException">Если введено некорректное значение стороны, при которой треугольник не существует</exception>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide < 0 || secondSide < 0 || thirdSide < 0)
                throw new ArgumentOutOfRangeException("Сторона не может быть отрицательной");

            if (!IsTriangleExist())
            {
                isTriangleExist = false;
                switch (SearchIncorrectSide(firstSide, secondSide, thirdSide))
                {
                    //Первая сторона треугольника
                    case 1:
                        throw new ArgumentException("Введена некорректная сторона, при которой треугольник не существует", nameof(firstSide));
                    //Вторая сторона треугольника
                    case 2:
                        throw new ArgumentException("Введена некорректная сторона, при которой треугольник не существует", nameof(secondSide));
                    //Третья сторона треугольника
                    case 3:
                        throw new ArgumentException("Введена некорректная сторона, при которой треугольник не существует", nameof(thirdSide));
                }
            }
            else
                isTriangleExist = true;

            if (IsTriangleRightAngled())
                isTriangleRightAngled = true;
            else
                isTriangleRightAngled = false;


            side_A = firstSide;
            side_B = secondSide;
            side_C = thirdSide;
            area = GetArea();
        }
        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        public override double GetArea()
        {
            //Вычисление полупериметра
            double p = (side_A + side_B + side_C) / 2;

            //Вычисление площади треугольника по формуле Герона
            double result = Math.Sqrt(p * (p - side_A) * (p - side_B) * (p - side_C));
            return result;
        }
        /// <summary>
        /// Проверка существования треугольника
        /// </summary>
        private bool IsTriangleExist()
        {
            if (side_A + side_B > side_C &&
                side_A + side_C > side_B &&
                side_B + side_C > side_A)

                return true;
            else
                return false;
        }
        /// <summary>
        /// Поиск некорректной стороны
        /// </summary>
        private int SearchIncorrectSide(double firstSide, double secondSide, double thirdSide)
        {
            if (secondSide + thirdSide < firstSide)
                return 1;
            else if (firstSide + thirdSide < secondSide)
                return 2;
            else if (firstSide + secondSide < thirdSide)
                return 3;
            return 0;
        }
        /// <summary>
        /// Проверка, является ли треугольник прямоугольным
        /// </summary>
        private bool IsTriangleRightAngled()
        {
            //Находим наибольшую сторону
            double maxSide = Math.Max(side_C , Math.Max(side_A, side_B));

            //Возводим наибольшую сторону в квадрат
            double maxSideSqr = maxSide * maxSide;

            //Используем формулу Пифагора для прямоугольного треугольника
            return maxSideSqr + maxSideSqr == side_A * side_A + side_B * side_B + side_C * side_C;
        }
    }
}
