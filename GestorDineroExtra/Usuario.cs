using System;

namespace GestorDineroExtra
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string DNI { get; private set; } // Private para depurar el DNI

        public Usuario()
        {
        }

        public bool SetDNI(string dni)
        {
            dni = dni.Trim().ToUpper();

            if (dni.Length != 9 && dni.Length != 10)
            {
                return false;
            }

            string numPart;
            string letraPart;

            if (dni.Contains("-"))
            {
                string[] partes = dni.Split('-');
                if (partes.Length != 2) return false;
                numPart = partes[0];
                letraPart = partes[1];
            }
            else
            {
                numPart = dni.Substring(0, 8);
                letraPart = dni.Substring(8, 1);
            }

            if (numPart.Length != 8 || !int.TryParse(numPart, out int numero))
            {
                return false;
            }

            if (letraPart.Length != 1 || !char.IsLetter(letraPart[0]))
            {
                return false;
            }

            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            string letraCorrecta = letras[numero % 23].ToString();

            if (letraPart != letraCorrecta)
            {
                Console.WriteLine($"Letra incorrecta. La letra correcta para {numPart} es '{letraCorrecta}'.");
                return false;
            }

            DNI = dni;
            return true;
        }

        public override string ToString()
        {
            return $"Usuario: {Nombre}, Edad: {Edad}, DNI: {DNI}";
        }
    }
}
