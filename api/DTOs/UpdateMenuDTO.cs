
namespace api.DTOs
{
    public class UpdateMenuDTO
    {
        public string Name {get;set;} = string.Empty;
        public string Category {get;set;} = string.Empty;
        public int Price {get;set;}
        public string Description {get;set;} = string.Empty;
        public string Tag {get;set;} = string.Empty;
    }
}