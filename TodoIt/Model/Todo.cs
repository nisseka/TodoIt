using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Todo
    {
	private readonly int todoId;
	private string description;
	private bool done;
	private Person assignee;

	public int TodoId => todoId;
	public string Description
	{
	    get => description;
	    set
	    {
		if (value == null)              // Check for null assignment
		{
		    throw new ArgumentNullException("Description", "property Description cannot be assigned a null value!");
		}

		description = value;
	    }
	}
	public bool Done { get => done; set => done = value; }
	public Person Assignee { get => assignee; set => assignee = value; }

/*
    * Method: constructor 
    *
    * default constructor
    * initializes class elements 
*/
	public Todo()
	{
	    assignee = null;
	    done = false;
	    todoId = 0;
	    description = "";
	}

/*
    * Method: constructor 
    *
    * initializes class elements & sets field todoId to supplied parameter todoId, 
    *					      description to supplied parameter description
*/
	public Todo(int todoId, string description) : this()
	{
	    this.todoId = todoId;
	    this.description = description;
	}
    }

}
