namespace Common.Models
{
    public class DecodeResult
    {
        public DecodeResult()
        {
            ItemFound = false;
            ExceptionOccured = false;
        }

        public bool ItemFound { get; set; }

        public string BarcodeValue { get; set; }

        public string BarcodeType { get; set; }

        public bool ExceptionOccured { get; set; }

        public string ExceptionMessage { get; set; }
    }
}
