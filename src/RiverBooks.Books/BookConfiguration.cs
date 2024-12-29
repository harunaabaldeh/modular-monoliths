using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiverBooks.Books.Data;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title)
            .HasMaxLength(DataSchemaConstants.DefaultLengthName)
            .IsRequired();

        builder.Property(b => b.Author)
            .HasMaxLength(DataSchemaConstants.DefaultLengthName)
            .IsRequired();

        builder.HasData(GetSampleData());
    }

    private IEnumerable<Book> GetSampleData()
    {
        var tolkien = "J.R.R Tolkien";
        
        yield return new Book(Guid.NewGuid(), "The Fellowship of the Ring", tolkien, 10.99m);
        yield return new Book(Guid.NewGuid(), "The Two Towers", tolkien, 11.99m);
        yield return new Book(Guid.NewGuid(), "The Return of the King", tolkien, 12.99m);
    }
}