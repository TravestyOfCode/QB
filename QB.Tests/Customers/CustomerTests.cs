using QB.SDK;

namespace QB.Tests.Customers;

public class CustomerTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void ToModThrowsArgumentExceptionOnNullListID()
    {
        var so = new Customer();

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModThrowsArgumentExceptionOnEmptyListID()
    {
        var so = new Customer() { ListID = string.Empty };

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModThrowsArgumentExceptionOnNullEditSequence()
    {
        var so = new Customer();

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModThrowsArgumentExceptionOnEmptyEditSequence()
    {
        var so = new Customer() { EditSequence = string.Empty };

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModGeneratesCorrectRequestString()
    {
        // Arrange
        var so = new Customer()
        {
            ListID = "ABC123",
            EditSequence = "AAAA-BBBBB",
            Name = "Customer",
            AdditionalNotesRet = [
                new AdditionalNote(){ Note = "Note", NoteID = 123 },
                new AdditionalNote(){ Note = "Note", NoteID = 234 }
                ]
        };

        var qbxml = new QBXMLRequest([so.ToMod()]);

        // Act
        string validationErrors = string.Empty;
        qbxml.ToXDocument().Validate(fixture.QBXMLSchema, (o, e) =>
        {
            validationErrors += e.Message + Environment.NewLine;
        });

        // Assert
        Assert.Equal<object>(string.Empty, validationErrors);
    }
}