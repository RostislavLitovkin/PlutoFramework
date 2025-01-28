using Amazon.S3.Model;
using Amazon.S3;
using Amazon;

namespace PlutoFramework.Model.XCavate
{
    public class S3Model
    {
        /// <summary>
        /// Source: https://docs.aws.amazon.com/code-library/latest/ug/s3_example_s3_Scenario_PresignedUrl_section.html
        /// Generate a presigned URL that can be used to access the file named
        /// in the objectKey parameter for the amount of time specified in the
        /// duration parameter.
        /// </summary>
        /// <param name="client">An initialized S3 client object used to call
        /// the GetPresignedUrl method.</param>
        /// <param name="bucketName">The name of the S3 bucket containing the
        /// object for which to create the presigned URL.</param>
        /// <param name="objectKey">The name of the object to access with the
        /// presigned URL.</param>
        /// <param name="duration">The length of time for which the presigned
        /// URL will be valid.</param>
        /// <returns>A string representing the generated presigned URL.</returns>
        public static Task<string> GeneratePresignedURLAsync(IAmazonS3 client, string bucketName, string objectKey, double expiresInSeconds = 604800)
        {
            try
            {
                var request = new GetPreSignedUrlRequest()
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    Expires = DateTime.UtcNow.AddSeconds(expiresInSeconds),
                };
                return client.GetPreSignedURLAsync(request);
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error: '{ex.Message}'");
            }

            return Task.FromResult<string>(string.Empty);
        }
    }
}
