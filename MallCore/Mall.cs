using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MallCore {
	public class Mall {
		public List<Store> Stores { get; set; }

		public Mall() {
			Stores = new List<Store>();
		}

		/// <summary>
		/// adding a store in to the list 
		/// throw SystemException if the new Store is not unique
		/// </summary>
		/// <param name="store"></param>
		public void AddStore(Store store) {
			if (!Stores.Contains(store)){
				Stores.Add(store);
			}
			else {
				throw new SystemException("added item is not unique");
			}
		}
		/// <summary>
		/// looks for a store using the store.name
		/// </summary>
		/// <param name="storeName"></param>
		/// <returns>true if successful</returns>
		public bool RemStore(string storeName) {
			return Stores.Remove(new Store(storeName));
		}
		/// <summary>
		/// looks for a store using the store.name
		/// </summary>
		/// <param name="storeName"></param>
		/// <returns>store with maching name</returns>
		public Store GetStore(string storeName) {
			return Stores[Stores.IndexOf(new Store(storeName))];
		}
	}
}