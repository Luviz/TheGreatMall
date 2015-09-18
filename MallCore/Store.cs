using System;

namespace MallCore {
	public class Store : IComparable<Store>{

		public string Name { get; set; }
		public string Address { get; set; }
		public string Type { get; set; }
		public int Employee { get; set; }

		public Store(string name) {
			this.Name = name;
			Address = "";
		}
		public Store(string name, string address, string typ, int employees) {
			this.Name = name;			//Primary Key	// yes yes I kown u should just have one pk but this is not a database
			this.Address = address;		//Primary Key
			this.Type = typ;
			this.Employee = employees;
		}
		public void HEmp() {
				Employee++;
		}

		public void FEmp() {
			if(Employee > 0 )
				Employee--;
		}
		public override string ToString() {
			return string.Format("{0,-20} {1,-4} {2,-25} {3,2}", Name, Address, Type, Employee);
		}

		public int CompareTo(Store other) {
			return Name.CompareTo(other.Name);
		}
		public override bool Equals(object obj ) {
			Store store = obj as Store;
			//Console.WriteLine("DEBUG_Equals:>");
			if (store == null)
				return false;
			return Name.ToLower() == store.Name.ToLower()|| Address.ToLower()== store.Address.ToLower();
		}
		public override int GetHashCode() {
			return Name.GetHashCode() + Address.GetHashCode() 
				+ Type.GetHashCode() + Employee.GetHashCode();
			
		}
	}
}
