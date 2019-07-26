using System;
using System.Collections.Generic;
using Common;
using Common.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.Common;
using ZXing.ImageSharp;

namespace ReaderNuget
{
    public static class Reader
    {
        public static string DecodeMultiple(int count)
        {
            var foundCount = 0;
            var notFoundCount = 0;
            var errorsCount = 0;
            DecodeResult currentResult;

            for (int i = 0; i < count; i++)
            {
                currentResult = Decode();

                if (currentResult.ItemFound)
                {
                    foundCount++;
                }
                else if (currentResult.ExceptionOccured)
                {
                    errorsCount++;
                }
                else
                {
                    notFoundCount++;
                }
            }

            return $"Multiple results - {count} items: {foundCount} found, {notFoundCount} not found, {errorsCount} erros.";
        }

        public static DecodeResult Decode()
        {
            try
            {
                var img = Image.Load(ImageHelper.GetImage());
                return ProcessDecode(img);
            }
            catch (Exception ex)
            {
                return new DecodeResult
                {
                    ExceptionOccured = true,
                    ExceptionMessage = ex.Message
                };
            }
        }

        public static string DecodeMultipleWithUsing(int count)
        {
            var foundCount = 0;
            var notFoundCount = 0;
            var errorsCount = 0;
            DecodeResult currentResult;

            for (int i = 0; i < count; i++)
            {
                currentResult = DecodeWithUsing();

                if (currentResult.ItemFound)
                {
                    foundCount++;
                }
                else if (currentResult.ExceptionOccured)
                {
                    errorsCount++;
                }
                else
                {
                    notFoundCount++;
                }
            }

            return $"Multiple results - {count} items: {foundCount} found, {notFoundCount} not found, {errorsCount} erros.";
        }

        public static DecodeResult DecodeWithUsing()
        {
            try
            {
                using (var img = Image.Load(ImageHelper.GetImage()))
                {
                    return ProcessDecode(img);
                }
            }
            catch (Exception ex)
            {
                return new DecodeResult
                {
                    ExceptionOccured = true,
                    ExceptionMessage = ex.Message
                };
            }
        }

        private static DecodeResult ProcessDecode(Image<Rgba32> image)
        {
            var decodeResult = new DecodeResult();
            var source = new ImageSharpLuminanceSource<Rgba32>(image);
            var reader = new BarcodeReader(null, null, ls => new GlobalHistogramBinarizer(ls))
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new DecodingOptions
                {
                    TryHarder = true,
                    PossibleFormats = new List<BarcodeFormat>
                        {
                            BarcodeFormat.ITF
                            //BarcodeFormat.EAN_8,
                            //BarcodeFormat.CODE_39,
                            //BarcodeFormat.UPC_A
                        }
                }
            };
            var result = reader.Decode(source);

            if (result != null)
            {
                decodeResult.ItemFound = true;
                decodeResult.BarcodeType = result.BarcodeFormat.ToString();
                decodeResult.BarcodeValue = result.Text;
            }

            return decodeResult;
        }
    }
}
