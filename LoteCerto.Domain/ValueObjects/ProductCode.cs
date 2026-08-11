namespace LoteCerto.Domain.ValueObjects;

public record ProductCode
{
    private string Value { get; }

    public ProductCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("O código do produto é obrigatório", nameof(value));
        }

        if (value.Length > 20)
        {
            throw new ArgumentException("O código do produto não pode ter mais de 20 caracteres", nameof(value));
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[A-Z0-9-]+$"))
        {
            throw new ArgumentException("Código deve conter apenas letras maiúsculas, números e hífen", nameof(value));
        }

        Value = value.ToUpperInvariant();
    }

    public static implicit operator string(ProductCode code) => code.Value;
    public override string ToString() => Value;
}