using System.ComponentModel.DataAnnotations;

namespace GrpcGreeterService.Services
{
    public class ProductModel
    {
        [Key]
        public string code { get; set; }
        public string name { get; set; }
        public string access_code { get; set; }
        public string merchant_id { get; set; }
        public string hash_code { get; set; }
    }
}