public async Task<bool> FileExistsS3(string bucketName, string fileKey)
{
    BasicAWSCredentials basicCredentials = new BasicAWSCredentials("your-access-key", "your-secret-key");
    AmazonS3Config configurationClient = new AmazonS3Config();
    configurationClient.RegionEndpoint = RegionEndpoint.SAEast1;

    try
    {
        using (AmazonS3Client clientConnection = new AmazonS3Client(basicCredentials, configurationClient))
        {
            var getResponse = await clientConnection.GetObjectMetadataAsync(new GetObjectMetadataRequest
            {
                BucketName = bucketName,
                Key = fileKey
            });

            return getResponse.ContentLength > 0;
        }
    }
    catch (Exception ex)
    {
        return false;
    }
}