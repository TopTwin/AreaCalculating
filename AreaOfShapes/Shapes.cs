using System;

namespace AreaCalculating
{
    public abstract class Shape
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public readonly double _area;

        //Проверка аргументов на отрицательность и ноль
        static protected void CheckingForNegativity(params double[] arguments)
        {
            for(int i = 0; i < arguments.Length; i++)
            {
                if(arguments[i] < 0)
                    throw new ArgumentOutOfRangeException("Значение не может быть отрицательным");
            }
        }

        static protected void CheckingForZero(params double[] arguments)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] == 0)
                    throw new ArgumentOutOfRangeException("Значение не может быть равно нулю");
            }
        }

        protected Shape(double area)
        {
            this._area = area;
        }
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
        public Circle(double rad): base(GetArea(rad))
        {
            radius = rad;
        }

        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        /// <param name="rad">Радиус</param>
        /// <returns>Площадь круга</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если радиус имеет отрицательное значение</exception>
        public static double GetArea(double rad)
        {
            CheckingForNegativity(rad);

            //Вычисление площади круга
            double result = rad * rad * Math.PI;
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
                        :base(GetArea(firstSide, secondSide, thirdSide))
        {
            if (IsTriangleRightAngled())
                isTriangleRightAngled = true;
            else
                isTriangleRightAngled = false;

            side_A = firstSide;
            side_B = secondSide;
            side_C = thirdSide;
        }
        
        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        /// <param name="firstSide">Первая сторона треугольника</param>
        /// <param name="secondSide">Вторая сторона треугольника</param>
        /// <param name="thirdSide">Третья сторона треугольника</param>
        /// <returns>Площадь треугольника</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если сторона треугольника имеет отрицательное значение</exception>
        /// <exception cref="ArgumentException">Если введено некорректное значение стороны, при которой треугольник не существует</exception>
        public static double GetArea(double firstSide, double secondSide, double thirdSide)
        {
            CheckingForNegativity(firstSide, secondSide, thirdSide);
            CheckingForZero(firstSide, secondSide, thirdSide);

            if (!IsTriangleExist(firstSide, secondSide, thirdSide))
            {
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
            //Вычисление полупериметра
            double p = (firstSide + secondSide + thirdSide) / 2;

            //Вычисление площади треугольника по формуле Герона
            double result = Math.Sqrt(p * (p - firstSide) * (p - secondSide) * (p - thirdSide));
            return result;
        }
        
        // Проверка существования треугольника
        static private bool IsTriangleExist(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide + secondSide > thirdSide &&
                firstSide + thirdSide > secondSide &&
                secondSide + thirdSide > firstSide)

                return true;
            else
                return false;
        }
        
        // Поиск некорректной стороны
        /// <returns>Возвращает номер некорректной стороны</returns>
        static private int SearchIncorrectSide(double firstSide, double secondSide, double thirdSide)
        {
            if (secondSide + thirdSide < firstSide)
                return 1;
            else if (firstSide + thirdSide < secondSide)
                return 2;
            else if (firstSide + secondSide < thirdSide)
                return 3;
            return 0;
        }
        
        // Проверка, является ли треугольник прямоугольным
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
