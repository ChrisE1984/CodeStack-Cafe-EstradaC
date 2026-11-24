namespace api.DTOs;


public class CreateRestaurantRequest
{
    public required string Name { get; init; }
    public required string Tagline { get; init; }
    public required string Address { get; init; }
    public required string Hours { get; init; }
    public required string Phone { get; init; }
}
