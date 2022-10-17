using System.Text.RegularExpressions;

namespace VSimple
{
	public static class StringExt
	{
		/// <summary>
		/// Checks if the string value can be used.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool CheckValue(this string value)
		{
			bool res=false;
			if(!string.IsNullOrEmpty(value))
				res=value.Trim().Length>0;
			return res;
		}
		/// <summary>
		/// Checks if the string value references an existing and valid filesystem path.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool CheckPath(this string value)
		{
			bool res=false;
			if(value.CheckValue())
				res=File.Exists(value)||Directory.Exists(value);
			return res;
		}
		/// <summary>
		/// Repeats a string a set number of times.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="copies"></param>
		/// <returns></returns>
		public static string Repeat(this string value,int copies)
		{
			string res="";
			if(value.CheckValue()&&copies>0)
				for(int i=1;i<copies;i++)
					res+=value;
			else
				res=value;
			return res;
		}
		/// <summary>
		/// Capitalizes the first letter of every word.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Capitalize(this string value)
		{
			if(value.CheckValue())
				if(value.Contains(' '))
				{
					string tmp="";
					bool was_space=true;
					foreach(char c in value)
					{
						string s=c.ToString();
						if(!was_space&&Regex.IsMatch(s,"[\\s]"))
						{
							tmp+=s;
							was_space=true;
						}
						else if(was_space&&Regex.IsMatch(s,"[^\\s]"))
						{
							tmp+=s.ToUpper();
							was_space=false;
						}
						else
							tmp+=s;
					}
					value=tmp;
				}
			return value;
		}
		/// <summary>
		/// Formats the string to accomidate textual listing formats.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="spc_char"></param>
		/// <param name="delimiter"></param>
		/// <param name="line_char"></param>
		/// <returns></returns>
		public static string Formatting(this string value,string spc_char=" ",string delimiter=":",string line_char="\n")
		{
			if(value.CheckValue()&&spc_char!=null&&delimiter!=null&&line_char!=null)
				if(value.Contains(line_char)&&value.Contains(delimiter))
				{
					value=Regex.IsMatch(value,"\\"+delimiter+"[ ]{2,}")?Regex.Replace(value,"\\"+delimiter+"[ ]{2,}",""):value;
					string[] l=value.Split(line_char);
					List<string> li=new();
					int len=0;
					foreach(string s in l)
						if(s.Contains(delimiter))
						{
							string key=s.Split(delimiter)[0];
							len=key.Length>len?key.Length:len;
							li.Add(s);
						}
					len+=5;
					string tmp="";
					foreach(string s in li)
					{
						string[] kvp = s.Split(delimiter);
						tmp+=tmp.Length>0 ? line_char+kvp[0]+delimiter+spc_char.Repeat(len-kvp[0].Length)+kvp[1] : kvp[0]+delimiter+spc_char.Repeat(len-kvp[0].Length)+kvp[1];
					}
					value=tmp;
				}
			return value;
		}
	}
}
