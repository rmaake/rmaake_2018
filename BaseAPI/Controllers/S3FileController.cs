using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3.Transfer;
using Amazon.S3;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace BaseAPI.Controllers {
    public class S3FileController {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;
        // private static IConfiguration _configuration;
        public static string returnFileName = null;

        // public S3FileController(IConfiguration configuration) {
        //     s3Client = new AmazonS3Client(null, null, bucketRegion);
        //     _configuration = configuration;            
        // }

        public static async Task uploadQuote(IFormFile file, IConfiguration _configuration) {
            s3Client = new AmazonS3Client(null, null, bucketRegion);
            if (file.Length > 1000000) {
                return ;
            }
            string s3Bucket = _configuration.GetSection("AppS3Bucket").Get<string>();
            string urlName = _configuration.GetSection("S3UrlName").Get<string>();
            string shortPath = Path.Combine("upload", DateTime.Now.ToString("yyyy-MM-ddHHmmss"), Path.GetFileName(file.FileName));
            string filename = Path.Combine(urlName, shortPath);

            try {
                var fileTransferUtility = new TransferUtility(s3Client);
                using (var ms = new MemoryStream()) {
                    file.CopyTo(ms);
                    await fileTransferUtility.UploadAsync(ms, s3Bucket, shortPath);
                }
            }
            catch (Exception err) {
                Console.WriteLine("Error found (s3 bucket) :: " + err.Message);
                return ;
            }
            returnFileName = filename;
        }

        // public async Task uploadSnag(IFormFile file, int timeLine) {
        //     string s3Bucket = _configuration.GetSection("AppS3Bucket").Get<string>();
        //     string urlName = _configuration.GetSection("S3UrlName").Get<string>();
        //     string shortPath = Path.Combine("images", timeLine.ToString(), DateTime.Now.ToString("yyyy-MM-ddHHmmss"), Path.GetFileName(file.FileName));
        //     string filename = Path.Combine(urlName, shortPath);

        //     try {
        //         var fileTransferUtility = new TransferUtility(s3Client);
        //         using (var ms = new MemoryStream()) {
        //             file.CopyTo(ms);
        //             await fileTransferUtility.UploadAsync(ms, s3Bucket, shortPath);
        //         }
        //     }
        //     catch (Exception err) {
        //         Console.WriteLine("Error found (s3 bucket) :: " + err.Message);
        //         return ;
        //     }
        //     returnFileName = filename;
        // }
    }
}