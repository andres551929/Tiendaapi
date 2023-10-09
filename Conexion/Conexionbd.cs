namespace Tiendaapi.Conexion
{
    public class Conexionbd
    {
        private string connectionString = string.Empty;

        public Conexionbd()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = builder.GetSection("ConnectionStrings:conexionmaestra").Value;
        }

        public string CadenaSQL()
        {
            return connectionString;
        }    
    }
}
