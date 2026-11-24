namespace api.DTOs;

/// <summary>Request data for updating a restaurant.</summary>
public class UpdateRestaurantRequest
{
    public  string Name { get; init; }
    public  string Tagline { get; init; }
    public  string Address { get; init; }
    public  string Hours { get; init; }
    public  string Phone { get; init; }
}
