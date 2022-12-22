using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tryitter.Context;
using tryitter.Models;

namespace tryitter.Test
{
    public static class Helpers
    {
        public static TryitterTestContext GetContextInstanceForTests(string InMemoryDbName)
        {
            var contextOptions = new DbContextOptionsBuilder<TryitterContext>()
                .UseInMemoryDatabase(InMemoryDbName)
                .Options;

            var context = new TryitterContext(contextOptions);
            
            context.Students.AddRange(
                GetStudentListForTests()
            );
            context.Posts.AddRange(
                GetPostListForTests()
            );

            context.SaveChanges();
            
            return context;
        }

        private static List<Post> GetPostListForTests() => 
            new() {
                new Post{
                    PostId = 1,
                    Content = "content1",
                    Url = "ulrPost1",
                    StudentId = 3,
                },
                new Post{
                    PostId = 2,
                    Content = "content2",
                    Url = "ulrPost2",
                    StudentId = 1,
                },
                new Post{
                    PostId = 3,
                    Content = "content3",
                    Url = "ulrPost3",
                    StudentId = 2,
                },
            };

        private static List<Student> GetStudentListForTests() => 
            new() {
                new Student{
                    StudentId = 1,
                    Name = "teste1",
                    Email = "teste1@trybe.com",
                    Password = "123456",
                    CurrentModule = "Fundamentos",
                    Status = "ativo",
                },
                new Student{
                    StudentId = 2,
                    Name = "teste2",
                    Email = "teste2@trybe.com",
                    Password = "123456",
                    CurrentModule = "FrontEnd",
                    Status = "ativo",
                },
                new Student{
                    StudentId = 3,
                    Name = "teste3",
                    Email = "teste3@trybe.com",
                    Password = "123456",
                    CurrentModule = "backend",
                    Status = "finalizado",
                },
            };

    }
}