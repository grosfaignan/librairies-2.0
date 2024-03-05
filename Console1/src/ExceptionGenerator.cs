using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croundave.anus
{
	public class MaClasseGenerique<T>
	{
		private T _valeur;

		public MaClasseGenerique(T valeur)
		{
			_valeur = valeur;
		}

		public T Valeur
		{
			get { return _valeur; }
			set { _valeur = value; }
		}

		public override string ToString()
		{
			return string.Format("La valeur de l'objet est : {0}", _valeur);
		}

		public bool EstEgal<U>(U autreValeur)
		{

			throw new Exception("test Exception");

		}
	}
}
public static class ExceptionGenerator
{
	public static string Field { get; set; }

	public static void ThrowExceptionRecursively(int depth = 0, string s ="")
	{
		if (depth > 0)
		{
			ThrowExceptionRecursively(depth - 1, s);
		}
		else
		{
			throw new Exception("Une exception s'est produite");
		}
	}

	public static void ThrowException()
	{
		ThrowExceptionRecursively(10, "");
	}
}
