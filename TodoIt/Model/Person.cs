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

	public string FirstName 
	{ 
	    get => firstName;
	    set
	    {
		if (value==null)
		{
		    throw new ArgumentNullException("FirstName", "property FirstName cannot be assigned a null value!");
		}

		if (value.Length == 0)
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
		if (value == null)
		{
		    throw new ArgumentNullException("LastName", "property LastName cannot be assigned a null value!");
		}

		if (value.Length == 0)
		{
		    throw new ArgumentException("property LastName cannot be assigned an empty string!", "LastName");
		}

		lastName = value;
	    }
	}
	public Person()
	{
	    personId = 0;
	    firstName = "";
	    lastName = "";
	}
    }
}
