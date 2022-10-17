namespace VSimple.Classes.Caster
{
	public class Caster
	{
		private dynamic _Object;
		private Type _Type;
		public dynamic Value
		{
			get
			{
				return _Object;
			}
			set
			{
				_Object=value;
				_Type=value.GetType();
			}
		}
		public Type Type
		{
			get
			{
				return _Type;
			}
		}
		public Caster(dynamic value)
		{
			Value=value;
		}
	}
}
