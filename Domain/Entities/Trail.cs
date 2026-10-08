namespace TrailHub.Domain.Entities;

public class Trail
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Length { get; set; }
    public int Difficulty { get; set; }

}