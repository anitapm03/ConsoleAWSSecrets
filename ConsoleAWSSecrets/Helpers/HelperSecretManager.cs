﻿using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAWSSecrets.Helpers
{
    internal class HelperSecretManager
    {
        public static async Task<string> GetSecretAsync()
        {
            string secretName = "datasecrets";
            string region = "us-east-1";

            IAmazonSecretsManager client =
                new AmazonSecretsManagerClient
                (RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT"
            };

            GetSecretValueResponse response;
            response = await client.GetSecretValueAsync(request);
            string secret = response.SecretString;
            return secret;
        }

    }
}
