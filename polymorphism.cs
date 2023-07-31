using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test{
    class Rectangle : Shape{
        public Rectangle(int newWidth, int newHeight){
            this.width = newWidth;
            this.height = newHeight;
        }
        public override int GetArea(){
            return this.width * this.height;
        }
        public int width { get; set; }
        public int height { get; set; }
    }

    class Triangle : Shape{
        public Triangle(int newWidth, int newHeight){
            this.width = newWidth;
            this.height = newHeight;
        }
        public override int GetArea(){
            return this.width * this.height / 2;
        }
        public int width { get; set; }
        public int height { get; set; }
    }

    abstract class Shape{
        public abstract int GetArea();
    }
    class Program{
        static void Main(){
            Shape shape1 = new Rectangle(10, 20);
            int shape1Area = shape1.GetArea();
            Console.WriteLine(shape1Area);

            Shape shape2 = new Triangle(10, 20);
            int shape2Area = shape2.GetArea();
            Console.WriteLine(shape2Area);
        }
    }
}