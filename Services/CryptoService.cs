using Microsoft.Extensions.Configuration;
using System.Text;

namespace TestDotNetApp.Services
{
    public class CryptoService
    {
        private readonly IConfiguration _configuration;
        public CryptoService(IConfiguration configuration) { _configuration = configuration; }
        public string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += _configuration["JWT:Key"];
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public string Decrypt(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData)) return "";
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            var result = Encoding.UTF8.GetString(base64EncodedBytes);
            result = result.Substring(0, result.Length - _configuration["JWT:Key"].Length);
            return result;
        }
    }
}
