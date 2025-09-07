namespace Domain;

public class Novost
{
    public Guid Id { get; set; }
    public string Naslov { get; set; } = null!;
    public string Sadrzaj { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public string SlikaPutanja { get; set; } = null!;
    public string FajlPutanja { get; set; } = null!;
    public int GrupaId { get; set; }
}
