namespace TaskParser
{
    using System;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using TaskParser.adminReplicControlServiceReference;

    /// <summary>
    /// 
    /// </summary>
    internal class EleedServiceFactory
    {
        private static bool isCertificateValidationConfigured;

        private readonly string login;
        private readonly string password;

        public EleedServiceFactory(string login, string password)
        {
            this.login = login;
            this.password = password;

            if (string.IsNullOrWhiteSpace(this.login))
            {
                throw new ArgumentException("login");
            }
        }

        public AdminReplicServiceClient Create()
        {
            this.EnsureNotTrustedCertificatesAllowed();

            var client = new AdminReplicServiceClient();
            if (client.ClientCredentials != null)
            {
                client.ClientCredentials.UserName.UserName = this.login;
                client.ClientCredentials.UserName.Password = this.CalculateMd5Hash(this.password);
            }

            return client;
        }

        private void EnsureNotTrustedCertificatesAllowed()
        {
            if (!isCertificateValidationConfigured)
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    (sender, certificate, chain, sslpolicyerrors) => true;

                isCertificateValidationConfigured = true;
            }
        }

        private string CalculateMd5Hash(string text)
        {
            using (var md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hash = md5.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}