# **VSimple**

## **Package Contents**
- Classes
	- Caster
		- A class used to hold the dynamic data-type and its type information.
- Extensions
	- CharExt
		- Repeat
			- Returns a string consisting of the character repeated a specified number of times.
	- StringExt
		- CheckValue()
			- Checks if the string usable (Not null nor empty).
		- CheckPath()
			- Checks if the string references a valid path on the filesystem.
		- Repeat(int count)
			- Repeats the string value a specified number of times.
		- Capitalize()
			- Capitalizes the first letter of each word in the string value.
		- Formatting(string space_char=" ", string delimiter=":", string line_char="\n")
			- Formats the string to output the key-value list neatly.

## **Examples**
###### CheckValue
```cs
using System;
namespace Example
{
	public class Example
	{
		public static Main(string[] args)
		{
			string value="apples";
			if(value.CheckValue())
				Console.WriteLine(value); // Outputs "Apples"
			value=null;
			if(!value.CheckValue())
				Console.WriteLine("The value is invalid");
			value="       ";
			if(value.CheckValue())
				Console.WriteLine("The value is valid!");
			else
				Console.WriteLine("The valid is invalid!"); // This will be output to the console.
		}
	}
}
```
###### CheckPath
```cs
using System;
namespace Example
{
	public class Example
	{
		public static Main(string[] args)
		{
			string path="C:\\Users\\Public\\Desktop\\";
			if(path.CheckPath())
				Console.WriteLine("Path is valid");
			else
				Console.WriteLine("Path is invalid");
		}
	}
}
```
###### Repeat
```cs
using System;
namespace Example
{
	public class Example
	{
		public static Main(string[] args)
		{
			string value="Apples ";
			Console.WriteLine(value.Repeat(3)); // Outputs "Apples Apples Apples"
		}
	}
}
```
###### Capitalize
```cs
using System;
namespace Example
{
	public class Example
	{
		public static Main(string[] args)
		{
			string value="hello world! How are you today?";
			Console.WriteLine(value.Capitalize()); // Outputs "Hello World! How Are You Today?"
		}
	}
}
```
###### Formatting
```cs
using System;
namespace Example
{
	public class Example
	{
		public static Main(string[] args)
		{
			string value="Key:Value\nFoo:Bar\nDesktopUser:John Doe\nAuthorized:\ntrue";
			Console.WriteLine(value.Formatting("\t",":","\n")); // Outputs the following...
			/*
			Key:		Value
			Foo:		Bar
			DesktopUser:John Doe
			Authorized:	true
			*/
		}
	}
}
```
###### Caster
```cs
using System;
using System.Collections.Generic
namespace Example
{
	public class Example
	{
		public static Main(string[] args)
		{
			string value="Hello World";
			Caster ins = new Caster(value);
			Output(ins);
			List<string> l=new List<string>
			{
				"Apples",
				"Oranges",
				"cake",
				"pears"
			};
			Output(ins);
		}
		
		public static Output(Caster ins)
		{
			if(ins.Type.Name=="string")
				Console.Write(ins.Value);
			else if(ins.Type.Name=="List`1")
				foreach(string sel in ins.Value)
					Console.WriteLine(sel);
		}
		
	}
}
```

## **Plans**
- [x] Implement string validation methods.
- [ ] Caster class complete
- [ ] Array extensions
- [ ] Network class
- [ ] Async file scanning
- [ ] Async file system classes

