using System;
using NixHW_Student.Model;
using NixHW_Student.View;

namespace NixHW_Student
{
	class Program
	{
		static void Main()
		{
			while (ConsoleUI.Continue)
			{
				ConsoleUI.PrintMenu();
				ConsoleUI.PrintUserChoose();
			}
			
		}
	}
}
