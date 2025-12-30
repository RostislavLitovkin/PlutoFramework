using SkiaSharp;

namespace PlutoFramework.Model
{
    public class ImageModel
    {
        public static MemoryStream CompressImageToJpeg(Stream input, int maxWidth, int maxHeight, int targetBytes, int minQuality = 60, int initialQuality = 85)
        {
            if (input == null) return new MemoryStream();
            if (maxWidth <= 0 || maxHeight <= 0) return new MemoryStream();

            // Decode with SKCodec so we can read EXIF orientation (codec.Origin)
            input.Position = 0;
            using var skStream = new SKManagedStream(input);
            using var codec = SKCodec.Create(skStream);
            if (codec == null) return new MemoryStream();

            using var decoded = SKBitmap.Decode(codec);
            if (decoded == null || decoded.Width == 0 || decoded.Height == 0) return new MemoryStream();

            // Honor EXIF orientation (rotate/flip the pixels); no reliance on aspect ratio
            using var oriented = ApplyOrigin(decoded, codec.EncodedOrigin);

            int srcW = oriented.Width;
            int srcH = oriented.Height;

            // Fit within bounds while maintaining aspect ratio (no upscaling)
            double scale = Math.Min(1.0, Math.Min((double)maxWidth / srcW, (double)maxHeight / srcH));
            int w = Math.Max(1, (int)Math.Round(srcW * scale));
            int h = Math.Max(1, (int)Math.Round(srcH * scale));

            using var resized = new SKBitmap(w, h, oriented.ColorType, oriented.AlphaType);
            using (var canvas = new SKCanvas(resized))
            using (var paint = new SKPaint { FilterQuality = SKFilterQuality.Medium, IsAntialias = true })
            {
                // JPEG has no alpha; use white background to avoid dark/transparent edges after transforms
                canvas.Clear(SKColors.White);
                canvas.DrawBitmap(oriented, new SKRect(0, 0, srcW, srcH), new SKRect(0, 0, w, h), paint);
            }

            using var image = SKImage.FromBitmap(resized);

            // Encode to target size by adjusting quality
            int quality = initialQuality;
            using var initial = image.Encode(SKEncodedImageFormat.Jpeg, quality);
            SKData? encoded = initial;

            while (encoded != null && encoded.Size > targetBytes && quality > minQuality)
            {
                quality = Math.Max(minQuality, quality - 10);
                encoded.Dispose();
                encoded = image.Encode(SKEncodedImageFormat.Jpeg, quality);
            }

            var output = new MemoryStream();
            if (encoded != null)
            {
                encoded.SaveTo(output);
                encoded.Dispose();
                output.Position = 0;
            }
            return output;
        }
        private static SKBitmap ApplyOrigin(SKBitmap src, SKEncodedOrigin origin)
        {
            int w = src.Width;
            int h = src.Height;
            bool swapsWH =
                origin is SKEncodedOrigin.LeftTop or SKEncodedOrigin.RightTop
                       or SKEncodedOrigin.RightBottom or SKEncodedOrigin.LeftBottom;

            var dstInfo = new SKImageInfo(
                swapsWH ? h : w,
                swapsWH ? w : h,
                src.ColorType,
                src.AlphaType);

            var dst = new SKBitmap(dstInfo);
            using var canvas = new SKCanvas(dst);
            using var paint = new SKPaint { FilterQuality = SKFilterQuality.High, IsAntialias = true };

            // IMPORTANT: Do transforms in this order (Translate → Rotate/Scale)
            switch (origin)
            {
                case SKEncodedOrigin.TopLeft: // 1: identity
                                              // no-op
                    break;

                case SKEncodedOrigin.TopRight: // 2: mirror horizontally
                    canvas.Translate(w, 0);
                    canvas.Scale(-1, 1);
                    break;

                case SKEncodedOrigin.BottomRight: // 3: rotate 180
                    canvas.Translate(w, h);
                    canvas.RotateDegrees(180);
                    break;

                case SKEncodedOrigin.BottomLeft: // 4: mirror vertically
                    canvas.Translate(0, h);
                    canvas.Scale(1, -1);
                    break;

                case SKEncodedOrigin.LeftTop: // 5: transpose (mirror across main diagonal)
                    canvas.Translate(0, w);
                    canvas.RotateDegrees(270);   // 90 CCW
                    canvas.Scale(1, -1);         // vertical flip after rotation
                    break;

                case SKEncodedOrigin.RightTop: // 6: rotate 90 CW
                    canvas.Translate(h, 0);
                    canvas.RotateDegrees(90);
                    break;

                case SKEncodedOrigin.RightBottom: // 7: transverse (mirror across anti-diagonal)
                    canvas.RotateDegrees(90);
                    canvas.Scale(1, -1);
                    break;

                case SKEncodedOrigin.LeftBottom: // 8: rotate 270 CW
                    canvas.Translate(0, w);
                    canvas.RotateDegrees(270);
                    break;

                default:
                    break;
            }

            canvas.Clear(SKColors.White);
            canvas.DrawBitmap(src, 0, 0, paint);
            canvas.Flush();

            return dst;
        }
    }
}
