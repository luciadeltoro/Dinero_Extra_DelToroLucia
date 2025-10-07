using System;

namespace GestorDineroExtra
{
    public class GastoException : Exception
    {
        public GastoException(string mensaje) : base(mensaje)
        {
        }
    }
}
