using MallCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMeye {
	public class ConsoleMode {
		private readonly string[] Commands = { "quit", "ls", "add", "sort", "hire", "fire", "help" };
		private Mall Mall;
		public ConsoleMode(Mall mall) {
			Console.WriteLine("welcome to Great Mall eye");
			Console.WriteLine("press help to get commnds");
			Console.WriteLine("warning key sensteive!");
			this.Mall = mall;
			init();
		}

		private void init() {
			bool keepruning = true;
			while (keepruning) {
				Console.Write("> ");
				string[] userInput = Console.ReadLine().Split(' ');
				switch (userInput[0]) {
					case "quit":
						keepruning = false;
						break;
					case "ls":
						Console.WriteLine("{0,-16} {1, -8} {2, -25} {3}", "Name", "Address", "Type", "employee");
						Mall.Stores.ForEach(Console.WriteLine);
						break;
					case "add":
						Add(userInput);
						break;
					case "rem":
						if (userInput.Count() > 1)
							Mall.RemStore(userInput[1]); // thorws systemException
						break;
					case "sort":
						Mall.Stores.Sort();
						break;
					case "help":
						foreach (string s in Commands)
							Console.WriteLine(s);
						break;
					case "hire":
						if (userInput.Count() > 1)
							Mall.GetStore(userInput[1]).HEmp();// thorws systemException
						break;
					case "fire":
						if (userInput.Count() > 1)
							Mall.GetStore(userInput[1]).FEmp();// thorws systemException
						break;

				}
			}
		}

		private void Add(string[] userInput) {
			try {
				if (userInput.Count() > 4) {
					Mall.AddStore(new Store(userInput[1], userInput[2], userInput[3], int.Parse(userInput[4])));
				}
				else {
					//disp help
					Console.WriteLine("add [Name] [Address] [Type] [(int) Nr of Employee]");
				}
			}
			catch (System.FormatException fe) {
				LogError(fe);
				//disp help
				Console.WriteLine("add [Name] [Address] [Type] [(int) Nr of Employee]");
			}
		}

		/// <summary>
		/// this will log me errors in error.log
		/// </summary>
		/// <param name="e"></param>
		private void LogError(Exception e) {
			System.IO.StreamWriter sw = new System.IO.StreamWriter("error.log", true);
			sw.WriteLine("GMeye.ConsoleMode {0:yyyy-MM-dd hh:mm:ss} : {1} - {2} ", DateTime.Now, e.GetType(), e.Message);
			sw.Close();
		}
	}
}
