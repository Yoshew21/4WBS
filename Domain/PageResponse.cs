namespace Domain
{
    public class PageResponse<T>
    {
        public int Index { get; set; }

        public int Offset { get; set; }

        public int TotalElement { get; set; }

        public IEnumerable<T> Content { get; set; }
    }
}