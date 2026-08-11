using LoteCerto.Domain.Enums;
using LoteCerto.Domain.ValueObjects;

namespace LoteCerto.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ProductCode Code { get; private set; }
    public ProductCategory Category { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    // navigation properties
    //private readonly List<Batch> _batches = new();
    //public IReadOnlyCollection<Batch> Batches = _batches.AsReadOnly();
    
    private Product() {}

    public Product(string name, string code, ProductCategory category, string? description = null)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Code = new ProductCode(code);
        Category = category;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Nome é obrigatório", nameof(newName));
        }

        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateCategory(ProductCategory newCategory)
    {
        Category = newCategory;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDescription(string? newDescription)
    {
        Description = newDescription;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ManageStatus(bool isActive)
    {
        IsActive = !isActive;
        UpdatedAt = DateTime.UtcNow;
    }
    
    
}