namespace GoodBurguer.GoodBurguer.Domain.ValueObjects
{
    public class Dinheiro
    {
        public decimal Valor { get; }

        public Dinheiro(decimal valor)
        {
            Valor = Math.Round(valor, 2, MidpointRounding.AwayFromZero);
        }

        public static Dinheiro Zero => new Dinheiro(0);

        public static Dinheiro operator +(Dinheiro a, Dinheiro b)
            => new Dinheiro(a.Valor + b.Valor);

        public static Dinheiro operator -(Dinheiro a, Dinheiro b)
            => new Dinheiro(a.Valor - b.Valor);

        public static Dinheiro operator *(Dinheiro a, decimal fator)
            => new Dinheiro(a.Valor * fator);

        public static bool operator ==(Dinheiro a, Dinheiro b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Valor == b.Valor;
        }

        public static bool operator !=(Dinheiro a, Dinheiro b)
            => !(a == b);

        public override bool Equals(object obj)
        {
            if (obj is not Dinheiro other)
                return false;

            return Valor == other.Valor;
        }

        public override int GetHashCode()
            => Valor.GetHashCode();

        public override string ToString()
            => Valor.ToString("F2");
    }
}