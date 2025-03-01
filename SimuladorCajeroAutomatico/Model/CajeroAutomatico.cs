using System.Text;

namespace SimuladorCajeroAutomatico.Model { 

    public class CajeroAutomatico
    {
        CuentaBancaria cb = new CuentaBancaria(1000);
        public bool Menu()
        {
            Console.WriteLine("1. Dep�sito");
            Console.WriteLine("2. Retiro");
            Console.WriteLine("3. Consultar Saldo");
            Console.WriteLine("4. Salir");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
            {
                Console.WriteLine("Por favor ingrese una opci�n v�lida (1-4).");
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese saldo a depositar: ");
                    decimal saldoADepositar = Convert.ToDecimal(Console.ReadLine());
                    cb.Depositar(saldoADepositar);
                    break;
                case 2:
                    Console.WriteLine("Ingrese saldo a retirar: ");
                    decimal saldoARetirar = Convert.ToDecimal(Console.ReadLine());
                    cb.Retirar(saldoARetirar);
                    break;
                case 3:
                    cb.ConsultarSaldo();
                    break;
                case 4:
                    return false;
                default:
                    Console.WriteLine("Opci�n no v�lida.");
                    break;
            }
            return true;
        }
    }
}