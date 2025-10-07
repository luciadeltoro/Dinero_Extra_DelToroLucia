using System;
using System.Collections.Generic;

namespace GestorDineroExtra
{
    public class Wishlist
    {
        public string Nombre { get; set; }
        public Usuario Usuario { get; set; }
        public List<Producto> Productos { get; private set; }
        // Set privado porque solo la clase Wishlist puede reemplazar la lista completa

        public Wishlist(string nombre, Usuario usuario)
        {
            Nombre = nombre;
            Usuario = usuario;
            Productos = new List<Producto>();
        }

        public void AddProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public List<Producto> GetProductosParaComprar(Cuenta cuenta)
        {
            List<Producto> disponibles = new List<Producto>();
            foreach (Producto p in Productos)
            {
                if (p.Precio <= cuenta.Saldo)
                {
                    disponibles.Add(p);
                }
            }
            return disponibles;
        }

        public override string ToString()
        {
            string resultado = "Wishlist: " + Nombre + "\n";
            foreach (Producto p in Productos)
            {
                resultado += "- " + p.ToString() + "\n";
            }
            return resultado;
        }
    }
}
