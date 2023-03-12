using System.Drawing;
using System.Net;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Lookups;
using ZaylandShop.ProductCatalog.Utils.Extensions;

namespace ZaylandShop.ProductCatalog.Storage;

public static class AppInitializer
{
    public static async Task Initialize()
    {
        try
        {
            var unitOfWork = ServiceLocator.GetService<IUnitOfWork>();
            
            var products = await unitOfWork.Products.GetAllAsync();
            if (products.Any())
                return;

            var demoCategories = new Category[]
            {
                new()
                {
                    Name = "Футболки",
                    Group = Group.Boys
                },
                new()
                {
                    Name = "Рубашки",
                    Group = Group.Boys
                },
                new()
                {
                    Name = "Штаны",
                    Group = Group.Boys
                },
                new()
                {
                    Name = "Аксессуары",
                    Group = Group.Boys
                },
                new()
                {
                    Name = "Футболки",
                    Group = Group.Girls
                },
                new()
                {
                    Name = "Штаны",
                    Group = Group.Girls
                },
                new()
                {
                    Name = "Рубашки",
                    Group = Group.Girls
                },
                new()
                {
                    Name = "Аксессуары",
                    Group = Group.Girls
                },
                new()
                {
                    Name = "Все",
                    Group = Group.General
                }
            };

            var demoColors = new ProductColor[]
            {
                new()
                {
                    Name = Color.Black.Name,
                    Hex = Color.Black.ConvertToHex()
                },
                new()
                {
                    Name = Color.White.Name,
                    Hex = Color.White.ConvertToHex()
                },
                new()
                {
                    Name = Color.Red.Name,
                    Hex = Color.Red.ConvertToHex()
                },
                new()
                {
                    Name = Color.Blue.Name,
                    Hex = Color.Blue.ConvertToHex()
                },
                new()
                {
                    Name = Color.Green.Name,
                    Hex = Color.Green.ConvertToHex()
                }
            };

            var demoBrands = new[]
            {
                new Brand()
                {
                    Name = "Armani"
                },
                new Brand()
                {
                    Name = "Versace"
                },
                new Brand()
                {
                    Name = "Carlo Bruni"
                },
                new Brand()
                {
                    Name = "Jack Honey"
                },
                new Brand()
                {
                    Name = "Guess"
                }
            };

            var g = new Dictionary<int, Group>();
            g.Add(0, Group.Boys);
            g.Add(1, Group.Girls);
            g.Add(2, Group.General);

            var n = new Dictionary<int, string>();
            n.Add(0, "Футболки");
            n.Add(1, "Рубашки");
            n.Add(2, "Штаны");
            n.Add(3, "Аксессуары");

            var b = new Dictionary<int, string>();
            b.Add(0, "Armani");
            b.Add(1, "Versace");
            b.Add(2, "Carlo Bruni");
            b.Add(3, "Jack Honey");
            b.Add(4, "Guess");

            var c = new Dictionary<int, string>();
            c.Add(0, "Black");
            c.Add(1, "White");
            c.Add(2, "Red");
            c.Add(3, "Blue");
            c.Add(4, "Green");

            var demoProducts = new List<Product>();
            var random = new Random();
            for (var i = 1; i <= 300; i++)
            {
                var gs = g[random.Next(0, 3)];
                var ns = n[random.Next(0, 4)];
                var bs = b[random.Next(0, 5)];
                var cs = c[random.Next(0, 5)];

                var newProd = new Product()
                {
                    Name = "Продукт " + i,
                    Brand = demoBrands.First(s => s.Name == bs),
                    ProductColor = demoColors.First(u => u.Name == cs),
                    Files = new List<ProductFile>(),
                    Categories = new List<Category>(),
                    Price = 2500 + i + 100
                };
                var newCat = demoCategories.First(s =>
                    s.Group == gs && s.Name == (gs == Group.General ? "Все" : ns));
                newCat.Products = new List<Product>();
                
                newProd.Categories.Add(newCat);
                newCat.Products.Add(newProd);
                
                demoProducts.Add(newProd);
            }

            using (WebClient client = new WebClient())
            {
                foreach (Product newProduct in demoProducts)
                {
                    byte[] imgFile = null;
                    try
                    {
                        imgFile = client.DownloadData(new Uri("https://fastly.picsum.photos/id/1004/600/600.jpg?hmac=okkphWAP4rOTU7TUbPyZaXElIKTmHiptABIAoscjQkU"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    if (imgFile != null)
                    {
                        var newFile = new ProductFile()
                        {
                            FileName = "Demo Image",
                            ContentType = "image/jpeg",
                            Content = imgFile,
                            FileType = FileType.ProductImage,
                            Product = newProduct
                        };
                        
                        newProduct.Files.Add(newFile);
                    }
                    
                    await unitOfWork.Products.AddAsync(newProduct);
                }
            }
            
            await unitOfWork.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}