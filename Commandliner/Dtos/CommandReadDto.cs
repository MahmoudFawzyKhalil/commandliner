namespace Commandliner.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        // Identical to the actual Command model, but during testing I removed the Platform to make sure the DTO was sent
        // and not the model
        public string Platform { get; set; }
    }
}
