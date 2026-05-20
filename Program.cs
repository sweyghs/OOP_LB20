using System;

namespace Lab20
{
    struct Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString()
        {
            if (Imaginary >= 0)
                return $"{Real} + {Imaginary}i";
            else
                return $"{Real} - {Math.Abs(Imaginary)}i";
        }
    }

    class Program
    {
        static Complex DivideComplex(Complex a, Complex b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;

            if (denominator == 0)
                throw new DivideByZeroException("Дільник (комплексне число) не може бути нульовим (0 + 0i).");

            double realPart = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
            double imagPart = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;

            return new Complex(realPart, imagPart);
        }

        static Complex InputComplex(string name)
        {
            double real, imag;
            Console.WriteLine($"\nВведення комплексного числа {name}:");

            while (true)
            {
                try
                {
                    Console.Write("  Дійсна частина: ");
                    real = double.Parse(Console.ReadLine());

                    Console.Write("  Уявна частина: ");
                    imag = double.Parse(Console.ReadLine());

                    return new Complex(real, imag);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: введіть коректне число.");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Complex A = InputComplex("A");
            Complex B = InputComplex("B");

            Console.WriteLine($"  Число A: {A}");
            Console.WriteLine($"  Число B: {B}");

            try
            {
                Complex result = DivideComplex(A, B);
                Console.WriteLine($"\nРезультат ділення A / B: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"\nМатематична помилка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nНепередбачена помилка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nБлок finally виконано (завершення операції ділення).");
            }

            Console.WriteLine("Кінець програми. Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}