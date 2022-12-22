// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using tryitter.Context;

// namespace tryitter.Test
// {
//     public class TryitterTest : IClassFixture<WebApplicationFactory<Program>>
//     {
//         public HttpClient client;
//         public TryitterTest(WebApplicationFactory<Program> factory)
//         {
//             client = factory.WithWebHostBuilder(builder =>
//             {
//                 builder.ConfigureServices(services =>
//                 {
//                     var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TryitterContext>));
//                     if (descriptor != null)
//                     {
//                         services.Remove(descriptor);
//                     }
//                     services.AddDbContext<TryitterTestContext>(options =>
//                     {
//                         options.UseInMemoryDatabase("InMemoryTest");
//                     });
//                 });
//             }).CreateClient();
//         }

//         [Theory]
//     }
// }