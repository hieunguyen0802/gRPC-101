using Grpc.Core;

namespace GrpcGreeterService.Services;

    public class ProductService : Product.ProductBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IAppDbContext _appDbContext;
        public ProductService(ILogger<ProductService> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        // public override Task<ProductModel> GetProductsInformation(GetProductDetail request, ServerCallContext context)
        // {
        //     ProductModel productDetail = new ProductModel();
        //     if (request.ProductId == 1)
        //     {
        //         productDetail.ProductName = "Samsung TV";
        //         productDetail.ProductDescription = "Smart TV";
        //         productDetail.ProductPrice = 35000;
        //         productDetail.ProductStock = 10;
        //     }
        //     else if (request.ProductId == 2)
        //     {
        //         productDetail.ProductName = "HP Laptop";
        //         productDetail.ProductDescription = "HP Pavilion";
        //         productDetail.ProductPrice = 55000;
        //         productDetail.ProductStock = 20;
        //     }
        //     else if (request.ProductId == 3)
        //     {
        //         productDetail.ProductName = "IPhone";
        //         productDetail.ProductDescription = "IPhone 12";
        //         productDetail.ProductPrice = 65000;
        //         productDetail.ProductStock = 30;
        //     }

        //     return Task.FromResult(productDetail);
        // }

        // public override async Task GetProducts (GetProductsRequest request, IServerStreamWriter<ProductModel> responseStream, ServerCallContext context) {
        //     var allProducts = _appDbContext.Campus.ToList()
        //     foreach (var product in allProducts)
        //     {
        //         await responseStream.WriteAsync(product);
        //     }
        // }

        public override async Task<ProductModel> GetProductList (GetProductsRequest request, ServerCallContext context){
            var productList = _appDbContext.Campus.AsEnumerable().ToList();
            ProductListModel productListModel = new ProductListModel();
            productListModel.Product.AddRange(productList);
            return productListModel;
        }
    }

