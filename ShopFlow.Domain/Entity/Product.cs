namespace ShopFlow.Domain.Entity;
// Rich Domain Entity
// Not : get; okuma, set; Yazma
// Birisi Product.Price yazınca çalışır fakat dışardan değer atanmasını engellemek istiyorsak private olmalı.
public class Product
{
   public Guid Id { get; private set; }
   public Guid CategoryId { get; private set; }
   public string Name { get; private set; }
   public decimal Price { get; private set; }
   public string Description { get; private set; }
   public string? ImagePath { get; private set; }
   public int Stock { get; private set; }
   public bool IsActive { get; private set; }
   public DateTime CreatedAt { get; private set; }
   public DateTime? UpdatedAt { get; private set; }
   public DateTime? DeletedAt { get; private set; }

   
   // Nesne doğarken (Eklenirken) 'ki kurallar dizisi:
   public Product(Guid categoryId, string name, decimal price,int stock, string description)
   {
      if (categoryId == Guid.Empty)
      {
         throw new ArgumentException("CategoryId cannot be empty.");
      } 
      if (string.IsNullOrWhiteSpace(name))
      {
         throw new ArgumentException("Name cannot be empty.");
      }
      if (price < 0)
      {
         throw new ArgumentException("Price cannot be negative.");
      }

      if (stock < 0)
      {
         throw new ArgumentException("Stock cannot be negative.");
      }

      if (string.IsNullOrEmpty(description))
      {
         throw new ArgumentException("Description cannot be null.");
      }
      Id = Guid.NewGuid();
      CategoryId = categoryId;
      Name = name;
      Price = price;
      Stock = stock;
      Description = description;
      CreatedAt = DateTime.UtcNow;
      IsActive = true;
      DeletedAt = null;
   }
   // Davranış Methodu : Sonradan değişikliklere uygulanacak olan kural.
   public void DecreaseStock(int amount)
   {
      if (amount <= 0)
      {
         throw new ArgumentException("Amount cannot be negative.");
      }
      if (amount > Stock)
      {
         throw new InvalidOperationException("Insufficient stock.");
      }
      Stock -= amount;
      UpdatedAt = DateTime.UtcNow;
   }

   public void UpdatePrice(decimal newPrice)
   {
      if (newPrice <= 0)
      {
         throw new ArgumentException("Price cannot be negative.");
      }
      Price = newPrice;
      UpdatedAt = DateTime.UtcNow;
   }
   
   public void IncreaseStock(int amount)
   {
      if (amount <= 0)
      {
         throw new ArgumentException("Amount cannot be negative.");
      }
      Stock += amount;
      UpdatedAt = DateTime.UtcNow;
   }
   
}

