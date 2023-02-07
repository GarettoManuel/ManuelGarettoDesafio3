namespace ManuelGarettoDesafio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manejadores.ManejadorUsuario.devolverUsuario(1);
            Manejadores.ManejadorProducto.obtenerProducto(1);
            Manejadores.ManejadorProductosVendidos.obtenerProductosVendidos(1);
            Manejadores.ManejadorVentas.obtenerVentas(1);
            Manejadores.ManejadorLogin.InicioSesion("mgaretto@gmail.com", "1234");
            
        }
    }
}