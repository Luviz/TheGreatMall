using MallCore;
using System;

namespace GMeye {
	//update

	class UI {
		private Mall Mall;
		private readonly string[] MMOPTIONS = {
			"Add a new store",
			"Update a store",
			"Show the store",
			"Hire/Fire an emplyee",
			"EXIT"
		};

		
		public UI() {
			Mall = new Mall();
			// /*DEDUG - give us something to work w/
			string[] names = { "ica", "home2Home", "IKEA", "p2p", "SmookWeedEverDay" };
			string[] address = { "101", "324", "112", "201", "202" };
			string[] types = { "Supermarket", "furniture", "Swedish Meat Boll store", "Internet Hard/Software", "Pharmacy" };
			int[] emp = { 24, 3, 12, 2, 9 };

			for (int i = 0; i < names.Length; i++) {
				Mall.AddStore(new Store(names[i], address[i], types[i], emp[i]));
			}
			//*/

			Console.WriteLine("Wellecome to the Great Mall...");
			Console.WriteLine("plz wait til we are done booting!");
			MainMenu();
			Console.WriteLine();
			Console.Write("Press Enter to shutdown...");
		}

		private void MainMenu() {
			bool keepRuning = true;
			while (keepRuning) {
				//display the main Menu
				Console.Clear();
				int count = 0;
				Console.WriteLine("    ~ MAIN MENU ~");
				Console.WriteLine("========================");
				foreach (String option in MMOPTIONS) {
					Console.WriteLine("{0,2}. {1}", ++count, option);
				}
				char userInput = Console.ReadKey().KeyChar;
				//Console.WriteLine("DEBUG:userInput> " + userInput);	//DEBUG
				//Console.ReadLine();									//DEBUG
				keepRuning = SelectOperation(userInput);
			}
		}

		private bool SelectOperation(char userInput) {
			switch (userInput) {
				case '1':       // add
					Add();
					break;
				case '2':       //remove
					Remove();
					break;
				case '3':		//disp
					Disp();
					break;
				case '4':       //hf e
					HR();
					break;
				case '5':       //Exit
					return false;

				case '/':       //consoleMod
					LunchConsoleMode();
					break;
				default:		//retry
					break;
			}
			return true;
		}

		private void Remove() {
			Console.Clear();
			Console.WriteLine("Remove Mode");
			Console.WriteLine("=========");
			Console.WriteLine();
			Console.Write("name: ");
			string storeName = Console.ReadLine();
			try {
				Store selectedStore = Mall.GetStore(storeName);
				Console.WriteLine("you have selected:");
				Console.WriteLine("{0,-16} {1, -8} {2, -25} {3}", "Name", "Address", "Type", "employee");
				Console.WriteLine(selectedStore);
				Console.WriteLine();
				Console.Write("confirm removal (Y/N) ");
				char userInput = Console.ReadKey().KeyChar;
				if (userInput.ToString().ToLower() == "y") {
					Mall.RemStore(storeName);
				}
			}
			catch(Exception e) {
				LogError(e);
			}
		}

		private void Add() {
			string name, address, type;
			int noe = -1;
            Console.Clear();
			Console.WriteLine("         Add");
			Console.WriteLine("=====================");

			
			Console.Write("Name: ");
			name = Console.ReadLine();
			Console.Write("Address: ");
			address = Console.ReadLine();
			Console.Write("Type: ");
			type = Console.ReadLine();

			//just makeing sure that we ge a nr of emplyees
			bool failed = true;
			while (failed) {
				try {
					Console.Write("Nr Of Emplyees:");
					noe = int.Parse(Console.ReadLine());
					failed = false;
				}catch(FormatException fe) {
					LogError(fe);
					Console.WriteLine("count not parse pleas use an integer");
					failed = true;
				}

				
				
			}
			try {
				Mall.AddStore(new Store(name, address, type, noe));

			}
			catch (SystemException se) {
				LogError(se);
			}
			//Console.ReadLine();	//DEBUG

		}

		private void Disp() {
			Console.Clear();
			Console.WriteLine("==============Stores===============");
			Console.WriteLine("{0,-16} {1, -8} {2, -25} {3}", "Name", "Address", "Type", "employee");
			foreach (Store s in Mall.Stores) {
				Console.WriteLine(s);
			}
			Console.WriteLine();
			Console.ReadLine();
		}
		/// <summary>
		/// human resources is here to fire or hire you! be ready u never see the comming
		/// </summary>
		private void HR() {
			Console.Clear();
			Console.WriteLine("========================================");
			Console.WriteLine("       Welcome to human resources       ");
			Console.WriteLine();
			Console.WriteLine("will u be hire in or fire someone today?");
			Console.WriteLine("1- Hire|press and key to leave|2- Fire  ");
			Console.Write(">");
			char userInput = Console.ReadKey().KeyChar;
			try { 
				switch (userInput) {
					case '1':
						HireMode();
						break;
					case '2':
						FireMode();
						break;
					default:
						break;
				}
			}
			catch (Exception e) {
				LogError(e);
				Console.WriteLine("unkown store!");
				Console.WriteLine("press enter to go to main menu");
				Console.ReadLine();
			}
		}

		private void FireMode() {
			Console.Clear();
			Console.WriteLine("!!!FIRE MODE ACTIVETED!!!");
			Console.Write("Store Name: ");
			string storeName = Console.ReadLine();
			Mall.GetStore(storeName).FEmp();
		}

		private void HireMode() {
			Console.Clear();
			Console.WriteLine("hire mode activeted");
			Console.Write("Store Name: ");
			String storeName = Console.ReadLine();
			Mall.GetStore(storeName).HEmp();
		}

		/// <summary>
		/// this will log me errors in error.log
		/// </summary>
		/// <param name="e"></param>
		private void LogError(Exception e) {
			System.IO.StreamWriter sw = new System.IO.StreamWriter("error.log", true);
			sw.WriteLine("GMeye.UI {0:yyyy-MM-dd hh:mm:ss} : {1} - {2} ", DateTime.Now ,e.GetType(), e.Message);
			sw.Close();
		}

		private void LunchConsoleMode() {
			ConsoleMode cm = new ConsoleMode(Mall);
		}
	}
}
