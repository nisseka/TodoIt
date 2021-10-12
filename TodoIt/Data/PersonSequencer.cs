using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    public class PersonSequencer
    {
	private static int personId;

/*
    * Method: constructor 
    *
    * static constructor
    * sets personId to 0
*/
	static PersonSequencer()
	{
	    personId = 0;
	}

/*
    * Method: nextPersonId 
    *
    * increments personId with 1
    * 
    * returns: personId
*/
	public static int nextPersonId()
	{
	    personId++;

	    return personId;
	}

/*
    * Method: reset 
    *
    * sets personId to 0
    * 
*/
	public static void reset()
	{
	    personId = 0;
	}
    }
}
