using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace Marathon.Server.Azure
{
    public class KeyVaultManager
    {
        readonly string tenantId;
        readonly string clientId;
        readonly string clientSecret;

        public KeyVaultManager()
        {
            tenantId = "84c31ca0-ac3b-4eae-ad11-519d80233e6f";
            clientId = "f19a493e-6a62-425f-b5a8-24935c17af75";
            clientSecret = ".sk8Q~UTxIcS1Fpk.txtVhf8n4l5_DGKpFFC_bOS";
        }

        public string GetSecret(string SecretName) 
        {
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new SecretClient(vaultUri: new Uri("https://testglup.vault.azure.net/"), credential);

            return client.GetSecret(SecretName).Value.Value;
        }

        public async Task<string> GetSecretAsync(string SecretName)
        {
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new SecretClient(vaultUri: new Uri("https://testglup.vault.azure.net/"), credential);

            var secret = await client.GetSecretAsync(SecretName);
            return secret.Value.Value;
        }


    }
}
