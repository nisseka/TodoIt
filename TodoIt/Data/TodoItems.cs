using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class TodoItems
    {
	private static Todo[] todoitemsArray;

/*
    * Method: constructor 
    * 
    * initializes class elements
    *
*/
	public TodoItems()
	{
	    Clear();            // Call Clear() to create an empty array
	}

/*
    * Method: Size 
    * 
    * returns: The number of elements in the todoitems Array
    *
*/
	public int Size()
	{
	    return todoitemsArray.Length;
	}

/*
    * Method: FindAll 
    * 
    * returns: The todoitems Array
    *
*/
	public Todo[] FindAll()
	{
	    return todoitemsArray;
	}

/*
    * Method: FindById 
    * 
    * Searches the todoitems Array for an object with a specific Todo ID
    * 
    * returns: The found Todo Object, null if no object is found
    *
*/
	public Todo FindById(int todoID)
	{
	    Todo todoObj = null;

	    foreach (var item in todoitemsArray)
	    {
		if (item.TodoId == todoID)
		{
		    todoObj = item;
		}
	    }
	    return todoObj;
	}

/*
    * Method: Add 
    * 
    * Adds a new Todo object to the array
    * 
    * returns: The newly created Todo object
    *
*/
	public Todo Add(string description,bool done = false, Person assignee = null)
	{
	    Todo[] newTodoitemsArray;
	    Todo todoObj;

	    int index = Size();                                     // The new Todo object position is at the end of the array
	    int newcount = index + 1;
	    int todoID = TodoSequencer.nextTodoId();		    // Create a new Todo ID

	    todoObj = new Todo(todoID,description);                 // Create a new Todo object with the new ID
	    todoObj.Done = done;
	    todoObj.Assignee = assignee;

	    newTodoitemsArray = new Todo[newcount];		    // Create a new array

	    todoitemsArray.CopyTo(newTodoitemsArray, 0);	    // Copy the old arrays content to the new array
	    newTodoitemsArray[index] = todoObj;			    // Insert the new object in the new array

	    todoitemsArray = newTodoitemsArray;			    // Use the new array

	    return todoObj;
	}

/*
    * Method: Clear 
    * 
    * Clears the todoitems Array
    *
*/
	public void Clear()
	{
	    todoitemsArray = new Todo[0];
	}
    }
}
