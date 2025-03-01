namespace SimuladorCajeroAutomatico.Model { 

	public class CuentaBancaria
	{
		private decimal _saldo;

		public CuentaBancaria(decimal saldoInicial)
		{
			_saldo = saldoInicial;
		}

		public decimal GetSaldo()
		{
			return _saldo;
		}

		public void Depositar(decimal saldoADepositar)
		{
            if (saldoADepositar > -1)
            {
                _saldo = _saldo + saldoADepositar;
            }
            else
            {
                Console.WriteLine("Error en el dep�sito: Ingrese un saldo positivo");
            }
        }

        public void Retirar(decimal saldoARetirar)
        {
            if (saldoARetirar > -1)
            {
                if (saldoARetirar <= _saldo)
                {
                    _saldo = _saldo - saldoARetirar;
                }
                else
                {
                    Console.WriteLine("Saldo Insuficiente");
                }
            }
            else
            {
                Console.WriteLine("Error en el retiro: Ingrese un saldo positivo");
            }
        }
		public void ConsultarSaldo()
		{
			Console.WriteLine("Saldo Actual: " + _saldo);
        }
    }
}