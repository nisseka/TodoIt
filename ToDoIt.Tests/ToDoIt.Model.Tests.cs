using System;
using Xunit;
using TodoIt.Model;
using TodoIt.Data;

namespace TodoIt.Tests
{
    public class TodoItModelTests
    {

	// Class Person Tests:
	[Fact]
	public void ClassPerson_ConstructorTest()
	{
	    Person obj = new Person();

	    Assert.NotNull(obj);
	    Assert.Equal("", obj.FirstName);
	    Assert.Equal("", obj.LastName);
	    Assert.Equal(0, obj.PersonId);
	}

	[Theory]
	[InlineData("Kalle", "Kalle", true)]
	[InlineData("", "", false)]              // Test with an empty string
	[InlineData(null, null, false)]         // Test with null assignment
	public void ClassPerson_PropertyFirstNameTest(string name, string nameExpected, bool expectedSuccess)
	{
	    // Arrange
	    Person obj = new Person();
	    bool success;

	    Assert.NotNull(obj);

	    // Act
	    try
	    {
		obj.FirstName = name;
		success = true;
	    }
	    catch (ArgumentNullException e) when (e.ParamName == "FirstName" && e.Message == "property FirstName cannot be assigned a null value! (Parameter 'FirstName')")
	    {
		success = false;
	    }
	    catch (ArgumentException e) when (e.ParamName == "FirstName" && e.Message == "property FirstName cannot be assigned an empty string! (Parameter 'FirstName')")
	    {
		success = false;
	    }

	    // Assert
	    Assert.Equal(expectedSuccess, success);
	    if (success)
		Assert.Equal(nameExpected, obj.FirstName);
	}

	[Theory]
	[InlineData("Karlsson", "Karlsson", true)]
	[InlineData("", "", false)]              // Test with an empty string
	[InlineData(null, null, false)]         // Test with null assignment
	public void ClassPerson_PropertyLastNameTest(string name, string nameExpected, bool expectedSuccess)
	{
	    // Arrange
	    Person obj = new Person();
	    bool success;

	    Assert.NotNull(obj);

	    // Act
	    try
	    {
		obj.LastName = name;
		success = true;
	    }
	    catch (ArgumentNullException e) when (e.ParamName == "LastName" && e.Message == "property LastName cannot be assigned a null value! (Parameter 'LastName')")
	    {
		success = false;
	    }
	    catch (ArgumentException e) when (e.ParamName == "LastName" && e.Message == "property LastName cannot be assigned an empty string! (Parameter 'LastName')")
	    {
		success = false;
	    }

	    // Assert
	    Assert.Equal(expectedSuccess, success);
	    if (success)
		Assert.Equal(nameExpected, obj.LastName);
	}

	// Class Todo Tests:
	[Fact]
	public void ClassTodo_ConstructorTest()
	{
	    // Arrange
	    Todo obj1 = new Todo();
	    Todo obj2 = new Todo(3, "test");

	    // Assert
	    Assert.NotNull(obj1);
	    Assert.NotNull(obj2);

	    // Test object 1
	    Assert.Equal("", obj1.Description);
	    Assert.Equal(0, obj1.TodoId);
	    Assert.False(obj1.Done);
	    Assert.Null(obj1.Assignee);

	    // Test object 2
	    Assert.Equal("test", obj2.Description);
	    Assert.Equal(3, obj2.TodoId);
	    Assert.False(obj2.Done);
	    Assert.Null(obj2.Assignee);

	}

	[Fact]
	public void ClassTodo_PropertiesTest()
	{
	    // Arrange
	    Person person = new Person();
	    Todo obj = new Todo();

	    Assert.NotNull(obj);

	    obj.Done = true;
	    obj.Assignee = person; 

	    // Assert
	    Assert.True(obj.Done);
	    Assert.Equal(person, obj.Assignee);
	}

	[Theory]
	[InlineData("test", "test", true)]
	[InlineData(null, null, false)]         // Test with null assignment
	public void ClassTodo_PropertyDescriptionTest(string description, string descriptionExpected, bool expectedSuccess)
	{
	    // Arrange
	    Todo obj = new Todo();
	    bool success;

	    Assert.NotNull(obj);

	    // Act
	    try
	    {
		obj.Description = description;
		success = true;
	    }
	    catch (ArgumentNullException e) when (e.ParamName == "Description" && e.Message == "property Description cannot be assigned a null value! (Parameter 'Description')")
	    {
		success = false;
	    }

	    // Assert
	    Assert.Equal(expectedSuccess, success);
	    if (success)
		Assert.Equal(descriptionExpected, obj.Description);
	}

    }

    public class TodoItDataTests
    {
	// Class PersonSequencer Tests:
	[Fact]
	public void ClassPersonSequencer_Tests()
	{
	    // Arrange
	    // Act
	    PersonSequencer.reset();				    // Set PersonId to 0

	    int personId = PersonSequencer.nextPersonId();          // Increment PersonId

	    // Assert
	    Assert.Equal(1, personId);
        }

    }
}
