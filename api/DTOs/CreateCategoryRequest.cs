using System.ComponentModel.DataAnnotations;

namespace api.DTOs;


public class CreateCategoryRequest
{
   
  
    public required string Name { get; init; }
}
