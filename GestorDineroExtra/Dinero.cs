using System;

namespace GestorDineroExtra
{
    public abstract class Dinero
    {
        public double Cantidad { get; set; }
        public string Descripcion { get; set; }

        public Dinero(double cantidad, string descripcion)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
        }
    }
}
