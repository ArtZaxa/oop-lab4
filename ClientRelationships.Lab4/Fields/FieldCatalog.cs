namespace ClientRelationships.Fields;

public static class FieldCatalog
{
    public static List<Field> Create(FirmFactory factory)
    {
        var fields = new List<Field>
        {
            new NameField(), new CountryField(), new RegionField(), new TownField(),
            new StreetField(), new PostInxField(), new DateInField(), new EmailField(),
            new WebField(), new CountContField(), new DateBegField(), new DateEndField(),
            new ContTypeField(), new ContDescrField(), new ContDataInfoField()
        };
        if (factory != null)
            fields.AddRange(factory.flds.Take(5).Select(name => (Field)new UsrField(name)));
        return fields;
    }
}
