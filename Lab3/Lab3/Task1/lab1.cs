/*
 * Задание№1
Создайте структуру Vector с тремя полями X, Y и Z. 
Для созданной структуры переопределите операторы сложения векторов,
умножения векторов, умножения вектора на число, а также логические операторы.
Для логических операторов используйте сравнение по длине от начала координат.
*/



using System.Data;

namespace Lab3.Task1
{

    struct Vector
    {
        private double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }





        public static Vector operator +(Vector first, Vector second) => new Vector(first.x + second.x, first.y + second.y, first.z + second.z);

        public static Vector operator *(Vector vec, double multiplier) => new Vector(vec.x * multiplier, vec.y * multiplier, vec.z * multiplier);


        public static double operator *(Vector first, Vector second) => first.x * second.x + first.y * second.y + first.z * second.z;

        public static bool operator ==(Vector first, Vector second) => Vector.Abs(first) == Vector.Abs(second);

        public static bool operator !=(Vector first, Vector second)  => !(first == second);


        public static bool operator >(Vector first, Vector second) => Vector.Abs(first) > Vector.Abs(second);

        public static bool operator <(Vector first, Vector second) => Vector.Abs(first) < Vector.Abs(second);


        public static bool operator >=(Vector first, Vector second) => Vector.Abs(first) >= Vector.Abs(second);
        
            
        public static bool operator <=(Vector first, Vector second) => Vector.Abs(first) <= Vector.Abs(second);

        public static void Print(Vector vec)
        {

            Console.WriteLine(vec.x + " " + vec.y + " " + vec.z);
        }


        public static double Abs(Vector vec)
        {
            return Math.Sqrt(vec.x*vec.x + vec.y*vec.y + vec.z*vec.z);
        }

    }





    public class Program
    {
        public static void Main(string[] args)
        {
            Vector first = new Vector(1, 2, 3);

            Vector second = new Vector(3, 2, 1);


            Console.WriteLine("Vectors : ");
            Console.WriteLine("First : \n");
            Vector.Print(first);
            Console.WriteLine("Second : \n");
            Vector.Print(second);


            Console.WriteLine($"Vector sum ");
            Vector.Print(first + second);

            Console.WriteLine("Multiply first by 3\n");
            Vector.Print(first * 3);

            Console.WriteLine("Multiply first by second\n");
            Console.WriteLine(first * second);

            Console.WriteLine($"First > Second : {first > second}\n" +
                $"Fisrt < Second : {first < second}\n" +
                $"First >= Second : {first >= second}\n" +
                $"First <= Second : {first <= second}\n" +
                $"First >= Second : {first >= second}\n" +
                $" First == Second : {first == second}\n" +
                $"First != Second : {first != second}\n");





        }
    }

}