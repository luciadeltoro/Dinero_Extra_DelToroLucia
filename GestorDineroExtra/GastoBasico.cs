using System;

namespace GestorDineroExtra
{
    public class GastoBasico : Gasto
    {
        public DateTime Fecha { get; set; }

        public GastoBasico(double cantidad, string descripcion) : base(cantidad, descripcion)
        {
            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Gasto Básico: {Descripcion} | Cantidad: {Cantidad}€ | Fecha: {Fecha.ToShortDateString()}";
        }
    }
}
