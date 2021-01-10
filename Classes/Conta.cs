using System;

namespace DIO_Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Levantar(double valorLevantamento)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorLevantamento < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

			this.Saldo -= valorLevantamento;
			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
			return true;
        }

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;
			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Levantar(valorTransferencia))
			{
				contaDestino.Depositar(valorTransferencia);
			}
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "TipoConta " + this.TipoConta + " | ";
			retorno += "Nome " + this.Nome + " | ";
			retorno += "Saldo " + this.Saldo + " | ";
			retorno += "Crédito " + this.Credito + " | ";
			return retorno;
		}
    }
}