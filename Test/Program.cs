using MallCore;
using System;

namespace Test {
	/// <summary>
	/// quick way to test the functionality 
	/// </summary>
	class Program {
		static void Main(string[] args) {
			string[] names = { "ica", "home2Home", "IKEA", "p2p", "SmookWeedEverDay" };
			string[] address = { "101", "324", "112", "201", "202" };
			string[] types = { "Supermarket", "furniture", "Swedish Meat Boll store", "Internet Hard/Software", "Pharmacy" };
			int[] emp = { 24, 3, 12, 2, 9 };

			Mall m = new Mall();
			for (int i = 0; i < names.Length; i++) {
				m.AddStore(new Store(names[i], address[i], types[i], emp[i]));
			}
			Console.WriteLine("{0,-16} {1, -8} {2, -25} {3}", "Name" , "Address", "Type", "employee");
			foreach (Store s in m.Stores) {
				Console.WriteLine(s);
			}

			m.AddStore(new Store("test", "201", "med", 12));
			Console.ReadLine();
		}
	}
}
