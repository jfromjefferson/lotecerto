namespace LoteCerto.Domain.ValueObjects;

public record Money
{
    private decimal Amount { get; }
    private string Currency { get; }

    public Money(decimal amount, string currency = "BRL")
    {
        if (amount < 0)
        {
            throw new ArgumentException("O valor não pode pode ser menor que 0", nameof(amount));
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Moeda é obrigatória", nameof(currency));
        }

        Amount = Math.Round(amount, 2);
        Currency = currency.ToUpperInvariant();
    }

    public static Money Zero => new(0);

    public Money Add(Money money)
    {
        if (Currency != money.Currency)
        {
            throw new InvalidOperationException("Não é possível somar moedas diferentes");
        }

        return new Money(Amount + money.Amount, Currency);
    }

    public Money Subtract(Money money)
    {
        
        if (Currency != money.Currency){
            throw new InvalidOperationException("Não é possível subitrair moedas diferentes");
        }

        return new Money(Amount - money.Amount, Currency);
    }

    public override string ToString()
    {
        return $"{Currency} {Amount:F2}";
    }
}