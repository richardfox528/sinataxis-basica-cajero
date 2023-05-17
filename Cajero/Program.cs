using System;
//Ricardo Muñoz Hoyos
//grupo 98

namespace Cajero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cajero STH BanPolombia";
            
            Cajero cajero = new Cajero();
            cajero.Menu();
        }
    }

    class Cuenta
    {
        private decimal saldo;

        public decimal Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }

        public void Retirar(decimal saldoRetiro)
        {
            saldo -= saldoRetiro;
        }

        public void Transferir(Cuenta cuentaDestino, decimal saldoTransferir)
        {
            saldo -= saldoTransferir;
            cuentaDestino.saldo += saldoTransferir;
        }
    }
}

