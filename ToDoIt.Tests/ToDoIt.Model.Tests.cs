using System;
using Xunit;
using TodoIt.Model;

namespace ToDoIt.Tests
{
    public class TodoItModelTests
    {
	[Fact]
	public void ClassPerson_ConstructorTest()
	{
	    Person obj = new Person();

	    Assert.NotNull(obj);
	    Assert.Equal("",obj.FirstName);
	    Assert.Equal("",obj.LastName);
	}

	[Theory]
	[InlineData("Kalle","Kalle",true)]
	[InlineData("", "",false)]              // Test with an empty string
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

    }
}
