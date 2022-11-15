namespace UserManager.Models
{
    public class PropertyInputModel
    {
        public PropertyInputModel(string? name, double size, string? localization)
        {
            Name = name;
            Size = size;
            Localization = localization;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double Size { get; set; }
        public string? Localization { get; set; }
    }
}
