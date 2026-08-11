namespace LoteCerto.Domain.ValueObjects;

public record BatchNumber
{
    private string Value { get; }

    public BatchNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("O lote é obrigatório", nameof(value));
        }

        if (value.Length > 20)
        {
            throw new ArgumentException("Número do lote não pode ser maior que 20 caracteres", nameof(value));
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^LOTE-\d{4}-\d{2}-[A-Z0-9]{3,}$"))
        {
            throw new ArgumentException("Formato inválido. Use LOTE-YYYY-MM-XXX", nameof(value));
        }

        Value = value.ToUpperInvariant();
    }

    public static BatchNumber Create(DateTime date, string sequence)
    {
        var formatted = $"LOTE-{date:yyyy-MM}-{sequence.ToUpperInvariant()}";

        return new BatchNumber(formatted);
    }

    public override string ToString() => Value;
}