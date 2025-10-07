using System;

namespace GestorDineroExtra
{
    public class Ingreso : Dinero
    {
        public DateTime Fecha { get; set; }

        public Ingreso(double cantidad, string descripcion) : base(cantidad, descripcion)
        {
            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Ingreso: {Descripcion} | Cantidad: {Cantidad}€ | Fecha: {Fecha.ToShortDateString()}";
        }
    }
}
