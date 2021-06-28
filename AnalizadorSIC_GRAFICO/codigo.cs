using System;
using System.Collections.Generic;
using System.Text;

namespace AnalizadorSIC_GRAFICO
{
    public class codigo
    {
        public string linea = "";
        public string CP = "";
        public string etiqueta = "\t";
        public string instruccion = "";
        public string operando = "";
        public string codObj = "\t\t";
        public bool esInsError = false;
        public string cadErrorLinea = "";
        public bool esRelocalisable = false; 
        public int tipoError= 0; //1= Error Simbolo Duplicado 2:Simbolo No Encontrado

        public codigo()
        {

        }

    }
}
