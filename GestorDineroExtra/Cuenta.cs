using System;
using System.Collections.Generic;

namespace GestorDineroExtra
{
    public class Cuenta
    {
        public double Saldo { get; private set; }
        public Usuario Usuario { get; set; }
        public List<Gasto> Gastos { get; set; }
        public List<Ingreso> Ingresos { get; set; }

        public Cuenta(Usuario usuario)
        {
            Usuario = usuario;
            Saldo = 0.0;
            Gastos = new List<Gasto>();
            Ingresos = new List<Ingreso>();
        }

        public double AddIngreso(string descripcion, double cantidad)
        {
            Ingreso ingreso = new Ingreso(cantidad, descripcion);
            Ingresos.Add(ingreso);
            Saldo += cantidad;
            return Saldo;
        }

        public double AddGastoBasico(string descripcion, double cantidad)
        {
            GastoBasico gasto = new GastoBasico(cantidad, descripcion);
            Gastos.Add(gasto);
            Saldo -= cantidad;
            return Saldo;
        }

        public double AddGastoExtra(string descripcion, double cantidad, bool prescindible)
        {
            GastoExtra gasto = new GastoExtra(cantidad, descripcion, prescindible);
            Gastos.Add(gasto);
            Saldo -= cantidad;
            return Saldo;
        }

        public override string ToString()
        {
            return $"Cuenta de {Usuario.Nombre} - Saldo actual: {Saldo}€";
        }
    }
}
