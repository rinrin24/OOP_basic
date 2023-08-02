using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance{
	/*
	class Cat{
        public void SetName(string newName){
            this.Name = newName;
        }
        public void Meow(){
            Console.WriteLine(this.Name+"「ニャー」");
        }
        public string Name { get; set; }
    }
    class Dog{
        public void SetName(string newName){
            this.Name = newName;
        }
        public void Woof(){
            Console.WriteLine(this.Name+"「ワン」");
        }
        public string Name { get; set; }
    }
	*/
	class Animal{
		public void SetName(string newName){
			this.Name = newName;
		}
		public string Name { get; set; }
	}
	class Cat: Animal{
        public void Meow(){
            Console.WriteLine(this.Name+"「ニャー」");
        }
    }
    class Dog: Animal{
        public void Woof(){
            Console.WriteLine(this.Name+"「ワン」");
        }
    }
	class Program{
		static void Main(){
			Cat cat = new Cat();
			cat.SetName("みけ");
			cat.Meow();
			Dog dog = new Dog();
			dog.SetName("しば");
			dog.Woof();
		}
	}
}