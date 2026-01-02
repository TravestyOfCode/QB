namespace QB.SDK;

public class ItemGroupLine : ItemLineBase
{
    public ListRef? ItemGroupRef { get; set; }
    public decimal? TotalAmount { get; set; }
    public List<ItemLine>? ItemLines { get; set; }
}
