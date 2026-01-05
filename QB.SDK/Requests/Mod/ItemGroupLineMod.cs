namespace QB.SDK;

public class ItemGroupLineMod : ItemLineModBase
{
    public ListRef? ItemGroupRef { get; set; }
    public List<ItemLineMod>? ItemLineMod { get; set; }

    public override XElement ToQBXML()
    {
        return new XElement(nameof(ItemGroupLineMod))
            .Append(TxnLineID)
            .Append(ItemGroupRef)
            .Append(Quantity)
            .Append(UnitOfMeasure)
            .Append(OverrideUOMSetRef)
            .Append(ItemLineMod);
    }
}
