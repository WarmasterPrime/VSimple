namespace VSimple
{
	public static class CharExt
	{
		/// <summary>
		/// Repeats the character value a specified number of times.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="copies"></param>
		/// <returns></returns>
		public static string Repeat(this char value,int copies)
		{
			return value!='\0'?value.ToString().Repeat(copies):value.ToString();
		}
	}
}
