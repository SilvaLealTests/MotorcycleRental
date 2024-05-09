using Amazon.S3.Model;
using Amazon.S3;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace MotorcycleRental.Application.Bikers.Commands
{
    public class SendCNHImageCommandHandler(IAmazonS3 s3Client) : IRequestHandler<SendCNHImageCommand, bool>
    {
        private const string bucketName = "motorcycle-rent-temp";
        public async Task<bool> Handle(SendCNHImageCommand request, CancellationToken cancellationToken)
        {

            if (request.CNHImage == null || (request.CNHImage.ContentType != "image/png" && request.CNHImage.ContentType != "image/bmp"))
            {
                throw new Exception("Invalid file format. Only PNG and BMP files are allowed.");
            }
            var key = $"{Path.GetFileNameWithoutExtension(request.CNHImage.FileName)}-{Guid.NewGuid()}{Path.GetExtension(request.CNHImage.FileName)}";

            using (var stream = new MemoryStream())
            {
                await request.CNHImage.CopyToAsync(stream);
                stream.Position = 0;
                var requestAWS = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    InputStream = stream,
                    ContentType = request.CNHImage.ContentType
                };
                await s3Client.PutObjectAsync(requestAWS);
            }

            return true;

        }
    }
}
