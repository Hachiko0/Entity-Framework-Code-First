namespace ConfigureMappings.Database
{
    public class PlayerPhoto
    {
        public int PlayerId { get; set; }
        public byte[] Photo { get; set; }

        public string FileName { get; set; }
    }
}
