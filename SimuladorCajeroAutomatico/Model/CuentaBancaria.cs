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
			_saldo = _saldo + saldoADepositar;
		}

        public void Retirar(decimal saldoARetirar)
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
		public void ConsultarSaldo()
		{
			Console.WriteLine("Saldo Actual: " + _saldo);
        }
    }
}