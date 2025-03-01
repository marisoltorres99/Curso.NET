using SimuladorCajeroAutomatico.Model;

public class Program
{
    static void Main()
    {
        CajeroAutomatico cajero = new CajeroAutomatico();
        bool bandera = true;
        while (bandera)
        {
            bandera = cajero.Menu();
        }
        Console.WriteLine("Gracias por usar nuestros servicios.");
    }
}

