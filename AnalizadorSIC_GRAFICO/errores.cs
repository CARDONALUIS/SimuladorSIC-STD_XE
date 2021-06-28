using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.IO;

namespace AnalizadorSIC_GRAFICO
{
    class errores : DiagnosticErrorListener
    {
        public string cad = "Errores: \n";
        int r = 0;
        public List<int> lineaErrores = new List<int>();
        public errores()
        {

        }

        public override void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            Console.WriteLine("Error en linea " + line + " " + msg);
            r = 0;

            //lineaErrores.Add(line);
            cad += "linea " + line + " " + msg + "\n";
            base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }

    }
}
