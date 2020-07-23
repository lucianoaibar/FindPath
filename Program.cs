using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FindPath {
	class Program {
		static void Main(string[] args) {

			List<string> S = new List<string>() {
				"rampa", "campa", "mamta", "cloro", "razpa", "razoa", "razon"
				//"papa","paca", "caca","cama","mama"
			};

			string p1 = "rampa";
			string p2 = "razon";
			//string p1 = "papa";
			//string p2 = "mama";

			//S.Reverse();

			List<Nodo>		Nodos = new List<Nodo>();
			Nodo			nodo_padre;
			Nodo			nodo;
			string			palabra;

			nodo_padre	= null;
			palabra		= p1;
			nodo		= null;
			
			for(;;){
				if(palabra!=null) {
					S.Remove(palabra);
					nodo = new Nodo(palabra, S, nodo_padre);
					Console.WriteLine(palabra);
					if(nodo.Relacionadas.Contains(p2)) break;
				}
			
				palabra = nodo.DameRelacionada();
				if(palabra==null) {
					nodo = nodo.Padre;
					if(nodo==null) break;
					S.Add(nodo.Palabra);
					Console.WriteLine("<-");
				}

				nodo_padre = nodo;
			}

			Console.WriteLine(p2);
		}

	}
}
