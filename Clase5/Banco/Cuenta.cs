namespace Banco
{
    class Cuenta
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }


        public Cuenta(int numero, string nombre, decimal saldo)
        {
            Numero = numero;
            Nombre = nombre;
            Saldo = saldo;
        }


        public void Depositar(decimal saldo)
        {
            Saldo += saldo;
        }
        public virtual void Extraer(decimal saldo)
        {
            throw new NotImplementedException();
        }

    }
}