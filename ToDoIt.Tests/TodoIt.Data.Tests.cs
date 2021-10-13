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

// Class Todo Tests:
	[Fact]
	public void ClassTodo_ConstructorTest()
	{
	    // Arrange
	    TodoItems obj = new TodoItems();

	    Assert.NotNull(obj);

	    // Assert
	    Assert.Equal(0, obj.Size());
	}

	[Fact]
	public void ClassTodo_AddTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();
	    Person personObj1 = new Person();

	    Assert.NotNull(todoitemsObj);

	    // Act
	    Todo todoObj = todoitemsObj.Add("Test",true,personObj1);

	    // Assert
	    Assert.Equal("Test", todoObj.Description);
	    Assert.True(todoObj.Done);
	    Assert.Equal(personObj1, todoObj.Assignee);
	    Assert.Equal(1, todoitemsObj.Size());
	}

	[Fact]
	public void ClassTodo_ClearTest()
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
	public void ClassTodo_SizeTest()
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
	public void ClassTodo_FindByIdTest()
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
	public void ClassTodo_FindAllTest()
	{
	    // Arrange
	    TodoItems todoitemsObj = new TodoItems();

	    Assert.NotNull(todoitemsObj);

	    Todo todoObj = todoitemsObj.Add("Test");

	    // Act
	    Todo[] todoitemssArray = todoitemsObj.FindAll();

	    // Assert
	    Assert.NotNull(todoitemssArray);
	    Assert.Equal(todoObj, todoitemssArray[0]);
	}

    }
}