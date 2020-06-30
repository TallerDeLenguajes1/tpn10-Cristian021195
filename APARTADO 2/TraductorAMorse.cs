using System;
using System.Collections.Generic;
using System.Text;

namespace MorseSound
{
    public static class TraductorAMorse
    {
        private static string entrada;
        private static readonly IDictionary<string, string> dict = new Dictionary<string, string> {
            {"a" , ".- "},
            {"b" , "-... "},
            {"c" , "-.-. "},
            {"d" , "-.. "},
            {"e" , ". "},
            {"f" , "..-. "},
            {"g" , "--. "},
            {"h" , ".... "},
            {"i" , ".. "},
            {"j" , ".--- "},
            {"k" , "-.- "},
            {"l" , ".-.. "},
            {"m" , "-- "},
            {"n" , "-. "},
            {"o" , "--- "},
            {"p" , ".--. "},
            {"q" , "--.- "},
            {"r" , ".-. "},
            {"s" , "... "},
            {"t" , "- "},
            {"u" , "..- "},
            {"v" , "...- "},
            {"w" , ".-- "},
            {"x" , "-..- "},
            {"y" , "-.-- "},
            {"z" , "--.. "},
            {"1" , ".---- "},
            {"2" , "..--- "},
            {"3" , "...-- "},
            {"4" , "....- "},
            {"5" , "..... "},
            {"6" , "-.... "},
            {"7" , "--... "},
            {"8" , "---.. "},
            {"9" , "----. "},
            {"0" , "----- "},
            {" " , "/"}
        };
        public static string Entrada { get => entrada; set => entrada = value; }
        public static IDictionary<string, string> Dict => dict;

        public static string traduccion(string Entrada) {
            string resp = "";
            string entradaMin = Entrada.ToLower();
            int cont = Entrada.Length;
            char[] letra = entradaMin.ToCharArray();
            for (int i = 0; i < cont; i++)
            {
                resp += Dict[letra[i].ToString()];
            }
            return resp;
        }
    }
}
