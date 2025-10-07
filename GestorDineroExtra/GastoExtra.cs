using System;

namespace GestorDineroExtra
{
    public class GastoExtra : Gasto
    {
        public DateTime Fecha { get; set; }
        public bool Prescindible { get; set; }

        public GastoExtra(double cantidad, string descripcion, bool prescindible) : base(cantidad, descripcion)
        {
            Fecha = DateTime.Now;
            Prescindible = prescindible;
        }

        public override string ToString()
        {
            string tipo;
            if (Prescindible)
            {
                tipo = "Prescindible";
            }
            else
            {
                tipo = "No prescindible";
            }

            return $"Gasto Extra: {Descripcion} | Cantidad: {Cantidad}€ | {tipo} | Fecha: {Fecha.ToShortDateString()}";
        }
    }
}
