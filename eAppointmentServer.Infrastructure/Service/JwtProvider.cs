using eAppointmentServer.Application.Service;
using eAppointmentServer.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eAppointmentServer.Infrastructure.Service
{
    // JWT (JSON Web Token) üretimi için bir sağlayıcı sınıfı
    public class JwtProvider : IJwtProvider
    {
        // Kullanıcı bilgilerine dayanarak JWT token oluşturur
        public string CreateToken(AppUser user)
        {
            // Kullanıcı bilgilerini JWT token'a eklemek için claim listesi oluşturulur
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Kullanıcı ID'si
                new Claim(ClaimTypes.Name, user.FullName), // Kullanıcının tam adı
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty), // Kullanıcı email adresi
                new Claim("UserName", user.UserName ??  string.Empty), // Kullanıcı adı
            };

            // Simetrik güvenlik anahtarı oluşturulur. Bu anahtar token'ı imzalamak için kullanılır
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(string.Join("-", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid())));

            // Güvenlik kimlik bilgileri oluşturulur. HMAC SHA512 algoritması kullanılarak imzalama yapılır
            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            // JWT token oluşturulur. Token'ın hangi uygulama için olduğu, kim tarafından verildiği ve süresi belirlenir
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "Berkay Kaplan", // Token'ı veren taraf (issuer)
                audience: "eAppointment", // Token'ın hedef kitlesi (audience)
                claims: claims, // Token'a eklenen kullanıcı bilgileri (claims)
                notBefore: DateTime.Now, // Token'ın geçerli olmaya başlayacağı zaman
                expires: DateTime.Now.AddDays(1), // Token'ın geçerlilik süresi
                signingCredentials: signingCredentials); // Token'ı imzalama için kullanılan güvenlik bilgileri

            // Token'ı işlemek için bir JWT işleyicisi oluşturulur
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            // Token string formatında üretilir
            string jwtToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            // Oluşturulan token geri döndürülür
            return jwtToken;
        }
    }
}
