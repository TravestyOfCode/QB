using QB.SDK;

namespace QB.Tests.Customers;

public class CustomerAddRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var rq = new CustomerAdd()
        {
            Name = "Customer",
            ParentRef = "Parent",
            AdditionalNotes = [
                new() { Note = "TestNote" }
                ],
            Contacts = [
                new() { FirstName = "ContactFirst", AdditionalContactRef = [ AdditionalContact.Email("bob@bob.com")]}
                ]
        };

        var qbxml = new QBXMLRequest([rq]);

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