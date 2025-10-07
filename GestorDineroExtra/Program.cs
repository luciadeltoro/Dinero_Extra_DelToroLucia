using System;
using System.Collections.Generic;

namespace GestorDineroExtra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bienvenido a la aplicación de gestión de gastos personales ===");

            // Crear usuario
            Usuario usuario = new Usuario();

            string nombre;
            do
            {
                Console.Write("Introduce tu nombre: ");
                nombre = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                }
            } while (string.IsNullOrEmpty(nombre));
            usuario.Nombre = nombre;

            while (true)
            {
                Console.Write("Introduce tu edad: ");
                string edadStr = Console.ReadLine();
                if (int.TryParse(edadStr, out int edad) && edad > 0)
                {
                    usuario.Edad = edad;
                    break;
                }
                Console.WriteLine("Edad inválida. Debe ser un número entero positivo.");
            }

            bool dniValido = false;
            while (!dniValido)
            {
                Console.Write("Introduce tu DNI (formato: 12345678A o 12345678-A): ");
                string dni = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(dni))
                {
                    dniValido = usuario.SetDNI(dni);
                    if (!dniValido)
                        Console.WriteLine("DNI inválido, inténtalo de nuevo.");
                }
                else
                {
                    Console.WriteLine("El DNI no puede estar vacío.");
                }
            }

            // Crear cuenta
            Cuenta cuenta = new Cuenta(usuario);
            Console.WriteLine($"\n✅ Cuenta creada correctamente:\n{cuenta.ToString()}");

            // Crear wishlist
            Wishlist wishlist = new Wishlist("Lista de deseos", usuario);

            // Menú principal
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n==================================================");
                Console.WriteLine("                   MENÚ PRINCIPAL");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Introduce un nuevo gasto básico");
                Console.WriteLine("2. Introduce un nuevo gasto extra");
                Console.WriteLine("3. Introduce un nuevo ingreso");
                Console.WriteLine("4. Mostrar gastos");
                Console.WriteLine("5. Mostrar ingresos");
                Console.WriteLine("6. Mostrar saldo");
                Console.WriteLine("7. Mostrar ahorro de un período");
                Console.WriteLine("8. Mostrar gastos imprescindibles");
                Console.WriteLine("9. Mostrar posibles ahorros del mes pasado");
                Console.WriteLine("10. Mostrar lista de deseos");
                Console.WriteLine("11. Mostrar productos que podemos comprar");
                Console.WriteLine("12. Añadir producto a la wishlist");
                Console.WriteLine("0. Salir");
                Console.WriteLine("==================================================");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Descripción del gasto básico: ");
                        string descBasico = Console.ReadLine();
                        Console.Write("Cantidad del gasto básico: ");
                        if (double.TryParse(Console.ReadLine(), out double cantBasico) && cantBasico > 0)
                        {
                            cuenta.AddGastoBasico(descBasico, cantBasico);
                            Console.WriteLine("Gasto básico añadido correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida.");
                        }
                        break;

                    case "2":
                        Console.Write("Descripción del gasto extra: ");
                        string descExtra = Console.ReadLine();
                        Console.Write("Cantidad del gasto extra: ");
                        if (double.TryParse(Console.ReadLine(), out double cantExtra) && cantExtra > 0)
                        {
                            Console.Write("¿Es prescindible? (s/n): ");
                            string prescindibleStr = Console.ReadLine()?.Trim().ToLower();
                            bool prescindible = prescindibleStr == "s";
                            cuenta.AddGastoExtra(descExtra, cantExtra, prescindible);
                            Console.WriteLine("Gasto extra añadido correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida.");
                        }
                        break;

                    case "3":
                        Console.Write("Descripción del ingreso: ");
                        string descIngreso = Console.ReadLine();
                        Console.Write("Cantidad del ingreso: ");
                        if (double.TryParse(Console.ReadLine(), out double cantIngreso) && cantIngreso > 0)
                        {
                            cuenta.AddIngreso(descIngreso, cantIngreso);
                            Console.WriteLine("Ingreso añadido correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("¿Qué gastos quieres ver?");
                        Console.WriteLine("1. Todos");
                        Console.WriteLine("2. Básicos");
                        Console.WriteLine("3. Extras");
                        string tipoGasto = Console.ReadLine();
                        switch (tipoGasto)
                        {
                            case "1":
                                Console.WriteLine("Todos los gastos:");
                                foreach (var g in cuenta.Gastos)
                                {
                                    Console.WriteLine(g.ToString());
                                }
                                break;
                            case "2":
                                Console.WriteLine("Gastos básicos:");
                                foreach (var g in cuenta.Gastos)
                                {
                                    if (g is GastoBasico gb)
                                        Console.WriteLine(gb.ToString());
                                }
                                break;
                            case "3":
                                Console.WriteLine("Gastos extras:");
                                foreach (var g in cuenta.Gastos)
                                {
                                    if (g is GastoExtra ge)
                                        Console.WriteLine(ge.ToString());
                                }
                                break;
                            default:
                                Console.WriteLine("Opción inválida.");
                                break;
                        }
                        break;

                    case "5":
                        Console.WriteLine("Ingresos:");
                        foreach (var i in cuenta.Ingresos)
                        {
                            Console.WriteLine(i.ToString());
                        }
                        break;

                    case "6":
                        Console.WriteLine($"Saldo actual: {cuenta.Saldo}€");
                        break;

                    case "7":
                        Console.WriteLine("Funcionalidad de ahorro pendiente de implementar.");
                        break;

                    case "8":
                        Console.WriteLine("Funcionalidad de gastos imprescindibles pendiente de implementar.");
                        break;

                    case "9":
                        Console.WriteLine("Funcionalidad de posibles ahorros del mes pasado pendiente de implementar.");
                        break;

                    case "10":
                        Console.WriteLine(wishlist.ToString());
                        break;

                    case "11":
                        List<Producto> comprables = wishlist.GetProductosParaComprar(cuenta);
                        if (comprables.Count == 0)
                            Console.WriteLine("No hay productos que puedas comprar actualmente.");
                        else
                        {
                            Console.WriteLine("Productos que puedes comprar:");
                            foreach (var p in comprables)
                                Console.WriteLine(p.ToString());
                        }
                        break;

                    case "12":
                        Console.Write("Nombre del producto: ");
                        string nombreProd = Console.ReadLine();
                        Console.Write("Precio del producto: ");
                        if (!double.TryParse(Console.ReadLine(), out double precioProd))
                        {
                            Console.WriteLine("Precio inválido.");
                            break;
                        }
                        Console.Write("Enlace del producto: ");
                        string enlaceProd = Console.ReadLine();
                        Producto nuevoProducto = new Producto(nombreProd, precioProd, enlaceProd);
                        wishlist.AddProducto(nuevoProducto);
                        Console.WriteLine("Producto añadido a la wishlist correctamente.");
                        break;

                    case "0":
                        salir = true;
                        Console.WriteLine("Gracias por usar la aplicación. ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
