namespace Banco
{
    class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(int numero, string nombre, decimal saldo) : base(numero, nombre, saldo)
        {
        }

        public override void Extraer(decimal saldo)
        {
            if (Saldo - saldo >= 0)
            {
                Saldo -= saldo;
            }
        }


    }
}