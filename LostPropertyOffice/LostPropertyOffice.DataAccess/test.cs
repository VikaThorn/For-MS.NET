using LostPropertyOffice.DataAccess;
using LostPropertyOffice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LostPropertyOffice
{
    public class Test
    {
        public void TestMethod(IDbContextFactory<LostPropertyOfficeDbContext> contextFactory)
        {
            using var context = contextFactory.CreateDbContext();

            // Пример добавления нового пользователя
            context.Users.Add(new UserEntity
            {
                Role = "Visitor",
                Login = "testuser",
                PasswordHash = "hashedpassword",
                PhoneNumber = "1234567890",
                ExternalId = Guid.NewGuid(),
                CreationTime = DateTime.UtcNow,
                ModificationTime = DateTime.UtcNow
            });

            // Пример запроса к пользователям
            var users = context.Users.Where(x => x.Role == "Visitor").ToList();

            context.SaveChanges();
        }
    }
}