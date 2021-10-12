using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    public class TodoSequencer
    {
	private static int todoId;

/*
    * Method: constructor 
    *
    * static constructor
    * sets global variable todoId to 0
*/
	static TodoSequencer()
	{
	    todoId = 0;
	}

/*
    * Method: nextTodoId 
    *
    * increments todoId with 1
    * 
    * returns: todoId
*/
	public static int nextTodoId()
	{
	    todoId++;

	    return todoId;
	}

/*
    * Method: reset 
    *
    * sets todoId to 0
    * 
*/
	public static void reset()
	{
	    todoId = 0;
	}
    }
}
