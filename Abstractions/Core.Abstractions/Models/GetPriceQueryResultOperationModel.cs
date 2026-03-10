namespace Core.Abstractions.Models;

public sealed record GetPriceQueryResultOperationModel
{
    public required decimal Price { get; set; }
}