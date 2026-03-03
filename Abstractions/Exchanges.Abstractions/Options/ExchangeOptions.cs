namespace Exchanges.Abstractions.Options;

public sealed record ExchangeOptions
{
    public required string BinanceUrl { get; init; }
    public required string ByBitUrl { get; init; }
}