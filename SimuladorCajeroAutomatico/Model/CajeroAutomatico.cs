using System.Text;

namespace SimuladorCajeroAutomatico.Model { 

    public class CajeroAutomatico
    {
        CuentaBancaria cb = new CuentaBancaria(1000);
        public bool Menu()
        {
            Console.WriteLine("1. Depósito");
            Console.WriteLine("2. Retiro");
            Console.WriteLine("3. Consultar Saldo");
            Console.WriteLine("4. Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());

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
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            return true;
        }
    }
}