using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace FindPath {
	public class Nodo {

		//_____________________________________________________________________
		public string		Palabra;
		public List<string>	Relacionadas;
		public Nodo			Padre;
		public int			indice_actual;

		//_____________________________________________________________________
		public Nodo(string palabra, List<string> diccionario, Nodo padre) {

			char[]	palabra_chars;
			char[]	chars;
			int		dif;
			int		len, n;

			this.Palabra		= palabra;
			this.Relacionadas	= new List<string>();
			this.Padre			= padre;
			this.indice_actual	= -1;

			palabra_chars = palabra.ToCharArray();
			len = palabra.Length;

			foreach(string s in diccionario) {
				chars = s.ToCharArray();
				dif = 0;
				for(n=0; n<len; n++) {
					if(chars[n]!=palabra_chars[n]) dif++;
				}
				if(dif==1) {
					this.Relacionadas.Add(s);
				}
			}
		}

		//_____________________________________________________________________
		public string DameRelacionada() {
			if(this.indice_actual==this.Relacionadas.Count()-1) {
				this.indice_actual = -1;
				return null;
			}
			this.indice_actual++;
			return this.Relacionadas[this.indice_actual];
		}

	}
}
