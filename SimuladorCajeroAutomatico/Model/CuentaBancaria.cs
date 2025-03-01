public class CuentaBancaria
{
	public decimal saldo { get; set; }

	public CuentaBancaria(decimal saldoInicial)
	{
		saldo = saldoInicial;
	}

	public void Depositar(decimal saldoADepositar)
	{
		saldo = saldo + saldoADepositar;
	}