using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CloudStorage
{
    public class MainDSL
    {
        static string clientId = "495943825042-4p8ge28bab1vhoaddmrbjobthbmbf4a7.apps.googleusercontent.com";
        static string clientSecret = "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";
        static string refreshToken = "1//047RaW5GHWRn8CgYIARAAGAQSNwF-L9IrBD7kBTZ_S4Mgkqmk-qmrWHEEQFmR0OhIub9arYtzH4pV9ddeTzrO-NrhMsAL6RQeQL4";
        static string AccessToken = "ya29.a0ARrdaM9_3MLQcJCsR7JkjMOAu1mAhbiL5tulVFYMyjAYlL6NYZ-FCnMPhaREr8-IYmyHd8MTxQuSm6ejlYG2uyd0KPO3yZpuLxzLjtPI2qZkalUEy7FI71GXyjt1Qjy5nxBLA3pVP333AIqVduSXSFizDkG-";
        static string redirect_uri = "https://developers.google.com/oauthplayground";
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };

        //create Drive API service.    
        public static Google.Apis.Drive.v3.DriveService GetService()
        {
            ////get Credentials from client_secret.json file     
            //UserCredential credential;

            //using (var stream = new FileStream(@"C:\Users\abdelrahman.adel\Downloads\client_secret_495943825042-h4cfb5hbvis71q5coeg6bl8kkaieffph.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            //{
            //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //        GoogleClientSecrets.FromStream(stream).Secrets,
            //        Scopes,
            //        "user",
            //        CancellationToken.None
            //        ).Result;
            //}

            ////create Drive API service.    
            //Google.Apis.Drive.v3.DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    //ApplicationName = "GoogleDriveRestAPI-v3",
            //});
            //return service;//get Credentials from client_secret.json file     
            UserCredential credential;
            // Load client secrets.
            using (var stream =
                   new FileStream(@"C:\Users\abdelrahman.adel\Downloads\client_secret_495943825042-4p8ge28bab1vhoaddmrbjobthbmbf4a7.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            {
                /* The file token.json stores the user's access and refresh tokens, and is created
                 automatically when the authorization flow completes for the first time. */
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
            });
            return service;

        }
        public static void FileUpload()
        {
            UploadFileDTO file = new UploadFileDTO
            {
                FileName = "test1",
                FilePath = @"C:\Users\abdelrahman.adel\Downloads\sample.pdf",
                FileType = "application/pdf"
            };
            var FileMetaData = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file.FileName,
                //Parents= new List<string> {"folder1"}
            };
            FilesResource.CreateMediaUpload request;
            var service = GetService();
            FilesResource.ListRequest listRequest = service.Files.List();
            bool getDeletedFiles = false;
            listRequest.Q += " and trashed = " + getDeletedFiles;

            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                request = service.Files.Create(FileMetaData, stream, file.FileType);
                request.ChunkSize = FilesResource.CreateMediaUpload.MinimumChunkSize;
                //request.Fields = DictionaryClass.Permissions;
                request.Upload();
            }
            var obj = request.ResponseBody;
            FileDTO fileee = new FileDTO()
            {
                Id = obj.Id,
                MimeType = obj.MimeType,
                Name = obj.Name,
                Size = obj.Size.HasValue ? ((float)obj.Size.Value / 1024) : (float?)null,
                DateUTC = obj.ModifiedTime.HasValue ? obj.ModifiedTime.Value :
                (obj.CreatedTime.HasValue ? obj.CreatedTime.Value : (DateTime?)null),
                WebViewLink = obj.WebViewLink
            };
        }
    }
    public class UploadFileDTO
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
    }
    public class FileDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public float? Size { get; set; }
        public DateTime? DateUTC { get; set; }
        public string Base64 { get; set; }
        public string ParentFileId { get; set; }
        public string WebViewLink { get; set; }
        public string ContainerName { get; set; }
        public string AzureFilePath { get; set; }
    }
}
