﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
namespace testconnectionfirestore
{
    class Program
    {
        private static FirestoreDb db;
        private static string data = "";
        static void Main(string[] args)
        {
            try
            {
                /*
                string path = AppDomain.CurrentDomain.BaseDirectory + @"secureconnection.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                var value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
                Console.WriteLine(value);
                FirestoreDb db = FirestoreDb.Create("secureconnection");
                Console.WriteLine("Created Cloud Firestore client with project ID: {0}", "secureconnection");
                */

                /*
                string _keyFilepath = AppDomain.CurrentDomain.BaseDirectory + @"secureconnection.json";
                var jsonString = File.ReadAllText(_keyFilepath);
                Console.WriteLine(jsonString);
                var builder = new FirestoreClientBuilder { JsonCredentials = jsonString };
                FirestoreDb db = FirestoreDb.Create("secureconnection", builder.Build());
                Console.WriteLine("Created Cloud Firestore client with project ID: {0}", "secureconnection");
                */

                var jsonString = @"{
                      ""type"": ""service_account"",
                      ""project_id"": ""secureconnection"",
                      ""private_key_id"": ""2f59900649889bb033e0eb9e8f3859b55a89d66e"",
                      ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDnofkZR7QXSv0Y\ncSKeEFlNlgzrjOFwpJJhdG1DYNOz72WeVFov8yE/R59OWLPcCq2u3Alz4LezXMvO\n3cnIqILIlhdrGqwLo+SWjAVVqad5OISVJMFqVyn58OO06YtGEiVgGShq5DQts8L7\nfV5gaxkkJhsdS5ccxgU5aZxH1RMMfkdHejn9CggJ9B3E1ahMqGNw19YBmsuJWWmD\nkwRVJmDJ0lOKs4bRN6NSkkdHEVseelITfPNVP4MXE68OSvRMYtUTHxxf3mzHVjso\nBk1YBJyUyc7lRCcXmcbsznd9Cl3Q9lHY99zW1njiiU8Sv41UafVEXMBODaP9DOu8\ncSpVxw8hAgMBAAECggEAJI2bgpadqrqt6SWwFFM5JzTBh4nSaRUXd+NIe4RetDut\nr3LZTqLRbCvbIyEoClacZQaamUZCRxRNogYUWfg5t090P6B/EPvapA/8UYc12Lvc\ntFqPXpQwbsh0brAXnJsFeej5HLE0M211nNFXy43AcxjDrkz8+lCc3Ma39QqreGIc\n9dzpQ+inEzRYwf08FEY7o3wSp0QZSfUchHA6LESwttRkRO3gdqS5za1TmX0WkfHY\nnfi5jhvK7bYmyuVsCGCX5jy4mpf8AlDMT6fIdBkzn7WyTvFCr6pbS0R7e7hur2ai\nxEQeAqQu6AtpiYrexV895lPkx74pQNZp2QbQDO4ALwKBgQDziBiPT5fpemzcX474\n3NOCb0qybhXnvhMOdK131MS9PzzbFhu4IGMP4t7dxgnoxtmN9fSQehpkAKdzkKt8\nDwuKm4XL+wI+7GdIfpUjd4Lnfpv+RMJvvNffR5469zDT7EdXKoadvZw7YDQCwVym\nGKDV2YY3SOnQgWNjHpH5nDMBBwKBgQDzfevRhxnqnabh7E/2PRFXInBRoytNmGn3\nuicZsWInqx1vviBjl5Trshfvg2WIDuKQ/QT5y8CcXu9P3Ys7UbFvQR9q43DW1BgN\nIdz8L5Fx3irT39s0GWmZc5SkEWngPGq0yh5/nXQTFcRJ59Zq+9tCjXO23hj9Dklt\n9plnzonslwKBgQDhvVzustvg+6+fEyEHREL3HEyEWxEJEKK/ep41fs+jkNPLTZIC\nOls5JZZqwqD62iBdvAioR9bgrc6KjCa5R4TuRb1fWFw7kY0noNaD2stH5I+awYfu\nZYFBIjTk+a+UMefrP6sq2tDQJRvxFeXYvOmRcSI9auP5d4Z2Iac0VnrczwKBgC/4\n7y0o4QJIbUi1tktdXL0+G8L50t5G2Rnloy58tEn8fKA3ZUo54y1MuUqHKMnVpO3L\n698LNbeZPK0PiQ722W6B9h6pEOJChzqPIWrONGmqy+VShW2OVC/XhcGNbL6xKJTV\n/YxHCUd5UmL9OlF5rYk/NT0iJOo2lmED5NV+682hAoGBANwoQpKbcNFSIxrUXKfN\n1f69DBXYLnPzPzQN1GRm/izpOAfBhMuQkseuABc5oReMSfN1qSEgtxiAIdpUt+we\niuT8xlTwz4Jh8E/ZgO8Dt2DPJoNuZDt4AakG9UIn6uNWDWPvUAp7GpMbjfchLzYD\nmpXuM4Pex1k6+5E1FKeaqeSR\n-----END PRIVATE KEY-----\n"",
                      ""client_email"": ""secureconnection@secureconnection.iam.gserviceaccount.com"",
                      ""client_id"": ""102930494484487968938"",
                      ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
                      ""token_uri"": ""https://oauth2.googleapis.com/token"",
                      ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
                      ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/secureconnection%40secureconnection.iam.gserviceaccount.com""
                    }";
                Console.WriteLine(jsonString);
                var builder = new FirestoreClientBuilder { JsonCredentials = jsonString };
                db = FirestoreDb.Create("secureconnection", builder.Build());
                Console.WriteLine("Created Cloud Firestore client with project ID: {0}", "secureconnection");

                DocumentReference docRef = db.Collection("users").Document("alovelace");
                Dictionary<string, object> user = new Dictionary<string, object>
                    {
                        { "First", "Ada" },
                        { "Last", "Lovelace" },
                        { "Born", 1815 }
                    };
                docRef.SetAsync(user);

                docRef = db.Collection("users").Document("aturing");
                user = new Dictionary<string, object>
                    {
                        { "First", "Alan" },
                        { "Middle", "Mathison" },
                        { "Last", "Turing" },
                        { "Born", 1912 }
                    };
                docRef.SetAsync(user);

                Task.Run(() => getData()).Wait();
            }
            catch (Exception e)
            {
                e.ToString();
            }

            Console.ReadLine();
        }
        private static async void getData()
        {
            try
            {
                CollectionReference usersRef = db.Collection("users");
                QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    Console.WriteLine("User: {0}", document.Id);
                    Dictionary<string, object> documentDictionary = document.ToDictionary();
                    Console.WriteLine("First: {0}", documentDictionary["First"]);
                    if (documentDictionary.ContainsKey("Middle"))
                    {
                        Console.WriteLine("Middle: {0}", documentDictionary["Middle"]);
                    }
                    data = "Last: " + documentDictionary["Last"];
                    data += "\n\rBorn: " + documentDictionary["Born"];
                    Console.WriteLine(data);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}
