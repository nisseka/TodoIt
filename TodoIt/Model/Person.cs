using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Person
    {
	private readonly int personId;
	private string firstName;
	private string lastName;

	public int PersonId => personId;

	public string FirstName
	{
	    get => firstName;
	    set
	    {
		if (value == null)              // Check for null assignment
		{
		    throw new ArgumentNullException("FirstName", "property FirstName cannot be assigned a null value!");
		}

		if (value.Length == 0)          // Check for an emtpy string
		{
		    throw new ArgumentException("property FirstName cannot be assigned an empty string!", "FirstName");
		}

		firstName = value;
	    }
	}

	public string LastName
	{
	    get => lastName;
	    set
	    {
		if (value == null)              // Check for null assignment
		{
		    throw new ArgumentNullException("LastName", "property LastName cannot be assigned a null value!");
		}

		if (value.Length == 0)          // Check for an emtpy string
		{
		    throw new ArgumentException("property LastName cannot be assigned an empty string!", "LastName");
		}

		lastName = value;
	    }
	}
/*
    * Method: constructor 
    *
    * initializes class elements & sets field personId to supplied parameter personId
    * 
 */
	public Person(int personId = 0)
	{
	    this.personId = personId;
	    firstName = "";
	    lastName = "";
	}

    }
}


