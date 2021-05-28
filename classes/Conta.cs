using System;

namespace Dio.Bank
{
    public class Conta
    {
        private string Nome {get ; set;}
        private TipoConta TipoConta {get; set;} 
        private double Saldo {get; set;} 
        private double Credito {get; set;} 

                    

         public Conta(TipoConta tipo, double saldo, double credito, string nome)
         {
             this.TipoConta = tipo;
             this.Saldo = saldo;
             this.Credito = credito;
             this.Nome = nome;
         }

         public bool Sacar(double saque)
         {
            if(this.Saldo - saque < (this.Credito * -1)){
                Console.WriteLine("SALDO INSUFICIENTE!");
                return false;
            }

            this.Saldo -= saque;
            Console.WriteLine("SEU SALDO ATUAL É: {0} ", this.Saldo);
            return true;
         }

         public void Depositar(double deposito)
         {
             this.Saldo += deposito;
             Console.WriteLine("SEU SALDO ATUAL É: R$ {0}", this.Saldo);
         }

         public void Transferir(double transferencia, Conta contaDestino)
         {
            if(this.Sacar(transferencia)){
                contaDestino.Depositar(transferencia);
            }
         }

         public override string ToString()
         {
             string retorno = "";
             retorno += "Tipo de Conta: "+ this.TipoConta + " | ";
             retorno += "Nome: "+ this.Nome + " | ";
             retorno += "Saldo: "+ this.Saldo + " | ";
             retorno += "Credito: "+ this.Credito + " | ";
             return retorno;
         }        

    }
}