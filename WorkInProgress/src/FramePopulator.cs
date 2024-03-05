using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkInProgress.src
{
	public class FramePopulator
	{
		static void InvokeMethodWithParams(FrameElement instance, String instanceObjectName)
		{
			// Appel de la méthode de l'autre fichier avec les paramètres
			instance.SetColor();
			instance.Right.Decoration.SetColor();
			instance.Right.Decoration.SetDelimiter();
			instance.Right.Decoration.SetPad();
			instance.Left.Decoration.SetColor();
			instance.Left.Decoration.SetDelimiter();
			instance.Left.Decoration.SetPad();
		}

	}
}
