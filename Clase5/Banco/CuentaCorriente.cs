namespace Banco
{
    class CuentaCorriente : Cuenta
    {
        public decimal Acuerdo { get; set; }

        public CuentaCorriente(int numero, string nombre, decimal saldo, decimal acuerdo) : base(numero, nombre, saldo)
        {
            Acuerdo = acuerdo;
        }

        public override void Extraer(decimal saldo)
        {
            if (Saldo - saldo >= Acuerdo)
            {
                Saldo -= saldo;
            }
        }
    }
}