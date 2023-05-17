using System;

namespace Cajero
{
    internal class Cajero
    {
        private Cliente cliente;
        private Cuenta cuenta;

        public Cajero()
        {
            cliente = new Cliente();
            cuenta = new Cuenta();

        deNuevo:
            try
            {
                Console.WriteLine("Numero de cuenta: 12345678");
                Console.WriteLine("Contraseña: 1234");
                Console.WriteLine("\nBienvenido a nuestro Cajero Automatico");
                Console.WriteLine("=====================================");
                Console.WriteLine("Ingrese su numero de cuenta para comenzar");
                long numeroCuenta = long.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese su contraseña");
                int contrasena = int.Parse(Console.ReadLine());
                cliente.ValidarCliente(numeroCuenta, contrasena);
                cuenta = cliente.ValidarCuenta(numeroCuenta);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\a\t¡Ha ocurrido un error!");
                Console.ResetColor();
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                goto deNuevo;
            }

        }

        public void Menu()
        {
            Console.Clear();
            try
            {

                if (cuenta == null)
                {
                    throw new Exception("La cuenta no se encuentra registrada en nuestra base de datos");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Menu de opciones");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("1. Consultar Saldo");
                    Console.WriteLine("2. Retirar Saldo");
                    Console.WriteLine("3. Transferir Saldo");
                    Console.WriteLine("4. Consultar puntos ViveColombia");
                    Console.WriteLine("5. Canjear puntos ViveColombia");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("=====================================");
                    int operacion = int.Parse(Console.ReadLine());

                    switch (operacion)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Su saldo actual es: " + cuenta.Saldo);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ingrese la cantidad que desea retirar");
                            decimal saldoRetiro = decimal.Parse(Console.ReadLine());
                            if (saldoRetiro > cuenta.Saldo)
                            {
                                throw new Exception("El saldo es insuficiente para realizar el retiro");
                            }
                            else if (saldoRetiro > 2000000)
                            {
                                throw new Exception("No se puede retirar mas de 2 millones");
                            }
                            else
                            {
                                cuenta.Retirar(saldoRetiro);
                                Console.WriteLine("Su nuevo saldo es: " + cuenta.Saldo);
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Ingrese la cuenta a la que desea transferir el saldo");
                            long numeroCuentaDestino = long.Parse(Console.ReadLine());
                            Cliente clienteDestino = new Cliente();
                            Cuenta cuentaDestino = clienteDestino.ValidarCuenta(numeroCuentaDestino);
                            if (cuentaDestino == null)
                            {
                                throw new Exception("La cuenta destino no se encuentra registrada en nuestra base de datos");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese la cantidad que desea transferir");
                                decimal saldoTransferir = decimal.Parse(Console.ReadLine());
                                if (saldoTransferir > cuenta.Saldo)
                                {
                                    throw new Exception("El saldo es insuficiente para realizar la transferencia");
                                }
                                else
                                {
                                    cuenta.Transferir(cuentaDestino, saldoTransferir);
                                    Console.WriteLine("Su nuevo saldo es: " + cuenta.Saldo);
                                }
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Ingrese el numero de la tarjeta de crédito con la que se registró");
                            long numeroTarjetaCredito = long.Parse(Console.ReadLine());
                            Console.WriteLine("Su saldo de puntos ViveColombia es: " + cliente.PuntosViveColombia(numeroTarjetaCredito));
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Ingrese el numero de la tarjeta de crédito con la que se registró");
                            long numeroTarjetaCreditoDestino = long.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese la cantidad de puntos que desea canjear");
                            decimal puntosCanjear = decimal.Parse(Console.ReadLine());
                            if (puntosCanjear > cliente.PuntosViveColombia(numeroTarjetaCreditoDestino))
                            {
                                throw new Exception("El saldo de puntos ViveColombia es insuficiente");
                            }
                            else
                            {
                                decimal puntosCanjeados = cliente.CanjearPuntos(puntosCanjear, numeroTarjetaCreditoDestino);
                                Console.WriteLine("Has canjeado " + puntosCanjeados + " puntos ViveColombia");
                                decimal puntosRestantes = cliente.PuntosViveColombia(numeroTarjetaCreditoDestino) - puntosCanjear;
                                Console.WriteLine("Su nuevo saldo de puntos ViveColombia es: " + puntosRestantes);
                            }
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            throw new Exception("La opción ingresada no se encuentra disponible");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\a" + ex.Message);
            }
            finally
            {
                Console.WriteLine("=====================================");
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();

                Menu();
            }
        }
    }
}
