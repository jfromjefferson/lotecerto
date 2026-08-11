using LoteCerto.Domain.Enums;
using LoteCerto.Domain.ValueObjects;

namespace LoteCerto.Domain.Entities;

public class Batch
{
    public Guid Id { get; private set; }
    public BatchNumber BatchNumber { get; private set; }
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public DateTime ManufactureDate { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public int Quantity { get; private set; }
    public Money UnitCost { get; private set; }
    public BatchStatus Status { get; private set; }
    public string? Notes { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Batch()
    {
    }
    
    
}