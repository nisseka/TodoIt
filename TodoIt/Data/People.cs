using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;


namespace TodoIt.Data
{
    public class People
    {
	private static Person[] personsArray;

/*
    * Method: constructor 
    * 
    * initializes class elements
    *
*/
	public People()
	{
	    Clear();		// Call Clear() to create an empty array
	}

/*
    * Method: Size 
    * 
    * returns: The number of elements in the persons Array
    *
*/
	public int Size()
	{
	    return personsArray.Length; 
	}

/*
    * Method: FindAll 
    * 
    * returns: The persons Array
    *
*/
	public Person[] FindAll()
	{
	    return personsArray;
	}

/*
    * Method: FindById 
    * 
    * Searches the persons Array for an object with a specific person ID
    * 
    * returns: The found person Object, null if no object is found
    *
*/
	public Person FindById(int personId)
	{
	    Person personObj = null;

	    foreach (var item in personsArray)
	    {
		if (item.PersonId == personId)
		{
		    personObj = item;
		}
	    }
	    return personObj;
	}

/*
    * Method: Add 
    * 
    * Adds a new person object to the array
    * 
    * returns: The newly created person object
    *
*/
	public Person Add(string firstName, string lastName)
	{
	    Person[] newPersonsArray;
	    Person personObj;

	    int index = Size();					    // The new Person object position is at the end of the array
	    int newcount = index + 1;
	    int personId = PersonSequencer.nextPersonId();          // Create a new person ID

	    personObj = new Person(personId);                       // Create a new Person object with the new ID
	    personObj.FirstName = firstName;
	    personObj.LastName = lastName;

	    newPersonsArray = new Person[newcount];		    // Create a new array

	    personsArray.CopyTo(newPersonsArray, 0);		    // Copy the old arrays content to the new array
	    newPersonsArray[index] = personObj;			    // Insert the new object in the new array

	    personsArray = newPersonsArray;			    // Use the new array

	    return personObj;
	}

/*
    * Method: Clear 
    * 
    * Clears the persons Array
    *
*/
	public void Clear()
	{
	    personsArray = new Person[0];
	}
    }
}
