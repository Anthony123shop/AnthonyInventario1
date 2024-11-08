using System;

namespace AnthonyInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nSistema de Gestión de Inventario");
                Console.WriteLine("1. Añadir nuevo producto");
                Console.WriteLine("2. Actualizar precio de un producto");
                Console.WriteLine("3. Eliminar un producto");
                Console.WriteLine("4. Clasificar productos por rango de precio");
                Console.WriteLine("5. Mostrar resumen del inventario");
                Console.WriteLine("6. Filtrar productos por precio mínimo");
                Console.WriteLine("7. Salir");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Añadir nuevo producto
                        Console.Write("Introduce el nombre del producto: ");
                        string nombreProducto = Console.ReadLine();

                        Console.Write("Introduce el precio del producto: ");
                        if (double.TryParse(Console.ReadLine(), out double precioProducto))
                        {
                            Producto nuevoProducto = new Producto(nombreProducto, precioProducto);
                            inventario.AñadirProducto(nuevoProducto);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Por favor, introduce un número.");
                        }
                        break;

                    case "2":
                        // Actualizar precio de un producto
                        Console.Write("Introduce el nombre del producto a actualizar: ");
                        string nombreActualizar = Console.ReadLine();

                        Console.Write("Introduce el nuevo precio: ");
                        if (double.TryParse(Console.ReadLine(), out double nuevoPrecio))
                        {
                            inventario.ModificarPrecio(nombreActualizar, nuevoPrecio);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número positivo.");
                        }
                        break;

                    case "3":
                        // Eliminar un producto
                        Console.Write("Introduce el nombre del producto a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        inventario.RemoverProducto(nombreEliminar);
                        break;

                    case "4":
                        // Clasificar productos por rango de precio
                        inventario.ClasificarProductosPorPrecio();
                        break;

                    case "5":
                        // Mostrar resumen del inventario
                        inventario.CrearResumenInventario();
                        break;

                    case "6":
                        // Filtrar productos por precio mínimo
                        Console.Write("Introduce el precio mínimo para el filtro: ");
                        if (double.TryParse(Console.ReadLine(), out double precioMinimo))
                        {
                            var productosFiltrados = inventario.ObtenerProductosPorPrecioMinimo(precioMinimo);

                            Console.WriteLine($"Productos con precio mayor a {precioMinimo}:");
                            foreach (var producto in productosFiltrados)
                            {
                                Console.WriteLine($"- {producto.Nombre}: {producto.Precio}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Introduce un valor numérico.");
                        }
                        break;

                    case "7":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intenta nuevamente.");
                        break;
                }
            }
        }
    }
}
