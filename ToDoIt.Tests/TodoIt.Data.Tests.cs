using System;
using TodoIt.Model;
using Xunit;

namespace TodoIt.Data.Tests
{
// TodoIt.Data Tests:
    public class TodoItDataTests
    {
// Class PersonSequencer Tests:
	[Fact]
	public void ClassPersonSequencer_Tests()
	{
	    // Arrange
	    // Act
	    PersonSequencer.reset();                                // Set PersonId to 0

	    int personId = PersonSequencer.nextPersonId();          // Increment PersonId

	    // Assert
	    Assert.Equal(1, personId);
	}

// Class TodoSequencer Tests:
	[Fact]
	public void ClassTodoSequencer_Tests()
	{
	    // Arrange
	    // Act
	    TodoSequencer.reset();                                  // Set todoId to 0

	    int personId = TodoSequencer.nextTodoId();              // Increment todoId

	    // Assert
	    Assert.Equal(1, personId);
	}

// Class People Tests:
	[Fact]
	public void ClassPeople_ConstructorTest()
	{
	    // Arrange
	    People obj = new People();

	    Assert.NotNull(obj);


	    // Assert
	    Assert.Equal(0, obj.Size());
	}

	[Fact]
	public void ClassPeople_AddTest()
	{
	    // Arrange
	    People peopleObj = new People();

	    Assert.NotNull(peopleObj);

	    // Act
	    Person personObj = peopleObj.Add("Kalle", "Karlsson");

	    // Assert
	    Assert.Equal("Kalle", personObj.FirstName);
	    Assert.Equal("Karlsson", personObj.LastName);
	    Assert.Equal(1, peopleObj.Size());
	}

	[Fact]
	public void ClassPeople_ClearTest()
	{
	    // Arrange
	    People obj = new People();

	    Assert.NotNull(obj);

	    // Act
	    obj.Clear();

	    // Assert
	    Assert.Equal(0, obj.Size());
	}
	[Fact]
	public void ClassPeople_SizeTest()
	{
	    // Arrange
	    People obj = new People();

	    Assert.NotNull(obj);

	    obj.Add("Kalle", "Karlsson");

	    // Act
	    int size = obj.Size();

	    // Assert
	    Assert.Equal(1, size);
	}
	[Fact]
	public void ClassPeople_FindByIdTest()
	{
	    // Arrange
	    People peopleObj = new People();

	    Assert.NotNull(peopleObj);

	    peopleObj.Add("Kalle", "Karlsson");
	    Person personObj1 = peopleObj.Add("Olle", "Nilsson");

	    // Act
	    Person foundObj = peopleObj.FindById(personObj1.PersonId);

	    // Assert
	    Assert.NotNull(foundObj);
	    Assert.Equal(personObj1.PersonId, foundObj.PersonId);
	}
	[Fact]
	public void ClassPeople_FindAllTest()
	{
	    // Arrange
	    People peopleObj = new People();

	    Assert.NotNull(peopleObj);

	    Person personObj = peopleObj.Add("Olle", "Nilsson");

	    // Act
	    Person[] personsArray = peopleObj.FindAll();

	    // Assert
	    Assert.NotNull(personsArray);
	    Assert.Equal(personObj, personsArray[0]);
	}

	[Fact]
	public void ClassPeople_RemoveTest()
	{
	    // Arrange
	    People peopleObj = new People();
	    Person[] personsArray;
	    Person personObj;

	    Assert.NotNull(peopleObj);

	    peopleObj.Add("Olle", "Nilsson");                        // Add test objects
	    peopleObj.Add("Kalle", "Karlsson");
	    personObj = peopleObj.Add("Nisse", "Persson");
	    peopleObj.Add("Olle", "Fast");

	    // Act
	    bool removed = peopleObj.Remove(personObj);

	    personsArray = peopleObj.FindAll();

	    // Assert
	    Assert.True(removed);

	    Assert.False(peopleObj.Remove(null));		// Test with removing a non-existing object

	    // Make surce that the object is really removed from the array of objects
	    bool found = false;
	    foreach (var item in personsArray)			// Search for todoObj in the array of objects
	    {
		if (item == personObj)
		{
		    found = true;
		}
	    }

	    Assert.False(found);
	}

	[Theory]
	[InlineData(0, true)]                                     // Test delete the first object
	[InlineData(1, true)]                                     // Test delete the 2nd object
	[InlineData(3, true)]                                     // Test delete the last object
	[InlineData(-1, false)]                                   // Test delete with index out of bounds
	[InlineData(56, false)]                                   // Test delete with index out of bounds
	public void ClassPeople_DeleteTest(int itemIndex, bool expectedSuccess)
	{
	    bool success;
	    // Arrange
	    People peopleObj = new People();

	    Assert.NotNull(peopleObj);

	    peopleObj.Add("Olle", "Nilsson");                        // Add test objects
	    peopleObj.Add("Kalle", "Karlsson");
	    peopleObj.Add("Nisse", "Persson");
	    peopleObj.Add("Olle", "Fast");

	    // Act
	    try
	    {
		peopleObj.Delete(itemIndex);
		success = true;
	    }
	    catch (IndexOutOfRangeException e) when (e.Message.IndexOf("out of range") >= 0)
	    {
		success = false;
	    }
	    // Assert

	    Assert.Equal(expectedSuccess, success);
	    if (success)
		Assert.Equal(3, peopleObj.Size());           // Size of the array should be 3
	}


// Class TodoItems Tests:
	[Fact]
	public void ClassTodoItems_ConstructorTest()
	{
	    // Arrange
	    TodoItems obj = new TodoItems();

	    Assert.NotNull(obj);

	    // Assert
	    Assert.Equal(0, obj.Size());
	}

	[Fact]
	public void ClassTodoItems_AddTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();
	    Person personObj1 = new Person();

	    Assert.NotNull(todoitemsObj);
	    Assert.NotNull(personObj1);

	    // Act
	    Todo todoObj = todoitemsObj.Add("Test", true, personObj1);

	    // Assert
	    Assert.Equal("Test", todoObj.Description);
	    Assert.True(todoObj.Done);
	    Assert.Equal(personObj1, todoObj.Assignee);
	    Assert.Equal(1, todoitemsObj.Size());
	}

	[Fact]
	public void ClassTodoItems_ClearTest()
	{
	    // Arrange
	    TodoItems obj = new TodoItems();

	    Assert.NotNull(obj);

	    // Act
	    obj.Clear();

	    // Assert
	    Assert.Equal(0, obj.Size());
	}
	[Fact]
	public void ClassTodoItems_SizeTest()
	{
	    // Arrange
	    TodoItems obj = new TodoItems();

	    Assert.NotNull(obj);

	    obj.Add("Test");

	    // Act
	    int size = obj.Size();

	    // Assert
	    Assert.Equal(1, size);
	}
	[Fact]
	public void ClassTodoItems_FindByIdTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();

	    Assert.NotNull(todoitemsObj);

	    todoitemsObj.Add("Test");
	    Todo todoObj1 = todoitemsObj.Add("Olle");

	    // Act
	    Todo foundObj = todoitemsObj.FindById(todoObj1.TodoId);

	    // Assert
	    Assert.NotNull(foundObj);
	    Assert.Equal(todoObj1.TodoId, foundObj.TodoId);
	}
	[Fact]
	public void ClassTodoItems_FindAllTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();

	    Assert.NotNull(todoitemsObj);

	    Todo todoObj = todoitemsObj.Add("Test");

	    // Act
	    Todo[] todoitemsArray = todoitemsObj.FindAll();

	    // Assert
	    Assert.NotNull(todoitemsArray);
	    Assert.Equal(todoObj, todoitemsArray[0]);
	}

	[Fact]
	public void ClassTodoItems_FindByDoneStatusTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();

	    Assert.NotNull(todoitemsObj);

	    todoitemsObj.Add("Test");           // Add test objects
	    todoitemsObj.Add("Test2", true);
	    todoitemsObj.Add("Test3", false);
	    todoitemsObj.Add("Test4", true);
	    todoitemsObj.Add("Test5", true);

	    // Act
	    Todo[] todoitemsArray = todoitemsObj.FindByDoneStatus(true);

	    // Assert
	    Assert.NotNull(todoitemsArray);

	    foreach (var item in todoitemsArray)
	    {
		Assert.True(item.Done);
	    }
	}

	[Fact]
	public void ClassTodoItems_FindUnassignedTodoItemsTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();
	    Person personObj1 = new Person();

	    Assert.NotNull(todoitemsObj);
	    Assert.NotNull(personObj1);

	    todoitemsObj.Add("Test");           // Add test objects
	    todoitemsObj.Add("Test2", true, personObj1);
	    todoitemsObj.Add("Test3", false);
	    todoitemsObj.Add("Test4", true);

	    // Act
	    Todo[] todoitemsArray = todoitemsObj.FindUnassignedTodoItems();

	    // Assert
	    Assert.NotNull(todoitemsArray);

	    foreach (var item in todoitemsArray)
	    {
		Assert.Null(item.Assignee);
	    }
	}

	[Fact]
	public void ClassTodoItems_FindByAssigneeTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();
	    Person personObj1 = new Person();

	    Assert.NotNull(todoitemsObj);
	    Assert.NotNull(personObj1);

	    todoitemsObj.Add("Test");           // Add test objects
	    todoitemsObj.Add("Test2", true, personObj1);
	    todoitemsObj.Add("Test3", false);
	    todoitemsObj.Add("Test4", true);

	    // Act
	    Todo[] todoitemsArray = todoitemsObj.FindByAssignee(personObj1);

	    // Assert
	    Assert.NotNull(todoitemsArray);

	    foreach (var item in todoitemsArray)
	    {
		Assert.Equal(personObj1, item.Assignee);
	    }
	}

	[Fact]
	public void ClassTodoItems_FindByAssigneePersonIdTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();
	    People peopleObj = new People();
	    Person personObj1;

	    Assert.NotNull(todoitemsObj);
	    Assert.NotNull(peopleObj);

	    personObj1 = peopleObj.Add("Olle", "Nilsson");
	    Assert.NotNull(peopleObj);

	    todoitemsObj.Add("Test");                        // Add test objects
	    todoitemsObj.Add("Test2", true, personObj1);
	    todoitemsObj.Add("Test3", false);
	    todoitemsObj.Add("Test4", true);

	    // Act
	    Todo[] todoitemsArray = todoitemsObj.FindByAssignee(personObj1.PersonId);

	    // Assert
	    Assert.NotNull(todoitemsArray);

	    foreach (var item in todoitemsArray)
	    {
		Assert.NotNull(item.Assignee);
		Assert.Equal(personObj1.PersonId, item.Assignee.PersonId);
	    }
	}

	[Fact]
	public void ClassTodoItems_RemoveTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();
	    Todo[] todoitemsArray;
	    Todo todoObj;

	    Assert.NotNull(todoitemsObj);

	    todoitemsObj.Add("Test");                        // Add test objects
	    todoitemsObj.Add("Test2", true);
	    todoObj = todoitemsObj.Add("Test3", false);
	    todoitemsObj.Add("Test4", true);

	    // Act
	    bool removed = todoitemsObj.Remove(todoObj);

	    todoitemsArray = todoitemsObj.FindAll();

	    // Assert
	    Assert.True(removed);

	    Assert.False(todoitemsObj.Remove(null));        // Test with removing a non-existing object

	    // Make surce that the object is really removed from the array of objects
	    bool found = false;
	    foreach (var item in todoitemsArray)            // Search for todoObj in the array of objects
	    {
		if (item == todoObj)
		{
		    found = true;
		}
	    }

	    Assert.False(found);
	}

	[Theory]
	[InlineData(0, true)]                                     // Test delete the first object
	[InlineData(1, true)]                                     // Test delete the 2nd object
	[InlineData(3, true)]                                     // Test delete the last object
	[InlineData(-1, false)]					  // Test delete with index out of bounds
	[InlineData(56, false)]                                   // Test delete with index out of bounds
	public void ClassTodoItems_DeleteTest(int itemIndex, bool expectedSuccess)
	{
	    bool success;
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();

	    Assert.NotNull(todoitemsObj);

	    todoitemsObj.Add("Test1");                        // Add test objects
	    todoitemsObj.Add("Test2", true);
	    todoitemsObj.Add("Test3", false);
	    todoitemsObj.Add("Test4", true);

	    // Act
	    try
	    {
		todoitemsObj.Delete(itemIndex);
		success = true;
	    }
	    catch (IndexOutOfRangeException e) when (e.Message.IndexOf("out of range") >= 0)
	    {
		success = false;
	    }
	    // Assert

	    Assert.Equal(expectedSuccess, success);
	    if (success)
		Assert.Equal(3, todoitemsObj.Size());           // Size of the array should be 3
	}
    }
}