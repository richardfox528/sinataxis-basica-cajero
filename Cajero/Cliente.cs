using System;

namespace Cajero
{
    internal class Cliente
    {
        public long numeroCuenta;
        private int contrasena;
        public string nombre;
        public string apellido;
        private string numeroIdentificacion;
        public string usuario;
        public string tipoIdentificacion;
        private int puntos;

        public Cliente()
        {

            numeroCuenta = 0;
            contrasena = 0;
        }

        public long NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            }

            set
            {
                numeroCuenta = value;
            }
        }

        public int Contrasena
        {
            get
            {
                return contrasena;
            }

            set
            {
                contrasena = value;
            }
        }

        public void ValidarCliente(long numeroCuenta, int contrasena)
        {
            if (numeroCuenta != 12345678 || contrasena != 1234)
            {
                throw new Exception("El identificador de cuenta o contraseña son incorrectos");
            }
        }

        public Cuenta ValidarCuenta(long numeroCuenta)
        {
            Cuenta cuenta = new Cuenta();
            if (numeroCuenta != 12345678)
            {
                throw new Exception("La cuenta no se encuentra registrada en nuestra base de datos");
            }
            else
            {
                cuenta.Saldo = 4000000;
            }
            return cuenta;
        }

        public decimal PuntosViveColombia(long numeroTarjetaCredito)
        {
            decimal puntosViveColombia = 0;
            if (numeroTarjetaCredito != 12345678)
            {
                throw new Exception("La tarjeta de credito no se encuentra registrada en nuestra base de datos");
            }
            else
            {
                puntosViveColombia = 100000;
            }
            return puntosViveColombia;
        }

        public decimal CanjearPuntos(decimal puntosCanjear, long numeroTarjetaCredito)
        {
            decimal puntosCanjeados = 0;
            if (numeroTarjetaCredito != 12345678)
            {
                throw new Exception("La tarjeta de credito no se encuentra registrada en nuestra base de datos");
            }
            else
            {
                puntosCanjeados = puntosCanjear;
            }
            return puntosCanjeados;
        }

        //Instanciamos la clase Cuenta
        public void NuevaCuenta()
        {
            Cuenta cuenta = new Cuenta();

            Console.WriteLine("Ingrese el nombre:");
            nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido:");
            apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la cédula:");
            numeroIdentificacion = Console.ReadLine();

            Console.WriteLine("Ingrese el número de cuenta:");
            numeroCuenta = long.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la contraseña:");

            Console.WriteLine("Ingrese el tipo de cuenta (ahorros o corriente):");
            string tipoCuenta = Console.ReadLine();
            Console.WriteLine("Ingrese el saldo:");
            cuenta.Saldo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Cuenta creada exitosamente!");
        }
    }
}
