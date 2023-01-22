﻿using IdentityServer4.Models;

namespace AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources() // İlgili Client Bu Apilere Erişim Sağlayacak.
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api1"){Scopes={"api1.read","api1.write","api1.update"}}, // Bu API kaç tane izni olduğunu biliyor.
                new ApiResource("resource_api2"){Scopes={"api2.read","api2.write","api2.update"}}
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes() // Clientlerin API den Aldıkları İzinler
        {
            return new List<ApiScope>()
            {
                // API 1 İçin İzinler
                new ApiScope("api1.read","Api 1 için okuma izni"),
                new ApiScope("api1.write","Api 1 için yazma izni"),
                new ApiScope("api1.update","Api 1 için güncelleme izni"),

                // API 2 İçin İzinler
                new ApiScope("api2.read","Api 2 için okuma izni"),
                new ApiScope("api2.write","Api 2 için yazma izni"),
                new ApiScope("api2.update","Api 2 için güncelleme izni")
            };
        }

        public static IEnumerable<Client>GetClients() // Bu APIleri hangi Clientler Kullanacak.
        {
            return new List<Client>()
          {
             new Client()
             {
                 ClientId="Client1", // Client Id Giriyoruz.
                 ClientName="Client 1 Web Uygulaması", // Cliente bir ad veriyoruz.
                 ClientSecrets=new[] {new Secret("password123".Sha256())}, // Cliente bir şifre belirleyip şifrenin hangi hash türünde db de tutulmasını belirtiyoruz.
                 // Kullanıcı bilgilerini uygulamaya girdikten sonra, uygulama bu bilgileri kullanarak servise POST isteği gönderir.
                 // Eğer bilgiler geçerli ise servis uygulamaya access token gönderir.
                 AllowedGrantTypes=GrantTypes.ClientCredentials,
                 AllowedScopes={"api1.read", "api2.write", "api2.update" } // Geçerli Client Hangi API lere izni var bunu belirtiyoruz.
             },
              new Client()
             {
                 ClientId="Client2", // Client Id Giriyoruz.
                 ClientName="Client 2 Web Uygulaması", // Cliente bir ad veriyoruz.
                 ClientSecrets=new[] {new Secret("password123".Sha256())}, // Cliente bir şifre belirleyip şifrenin hangi hash türünde db de tutulmasını belirtiyoruz.
                 // Kullanıcı bilgilerini uygulamaya girdikten sonra, uygulama bu bilgileri kullanarak servise POST isteği gönderir.
                 // Eğer bilgiler geçerli ise servis uygulamaya access token gönderir.
                 AllowedGrantTypes=GrantTypes.ClientCredentials,
                 AllowedScopes={"api1.read", "api2.write", "api2.update" } // Geçerli Client Hangi API lere izni var bunu belirtiyoruz.
             }
          };
        } 
    }
}
