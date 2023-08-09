using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance{
	class Program{
		static void Main(){
			string lowerString = "abc";
			string upperString = lowerString.ToUpper();
			Console.WriteLine(upperString);
			Console.WriteLine("xyz".ToUpper());
		}
	}
}