#region Description

// Option.cs
// 09-07-2021
// James LaFritz
//
// From Bit Cake Studio's BitStrap
// https://assetstore.unity.com/publishers/4147

#endregion

using System;

namespace CoreFramework.Functional
{
	/// <summary>
	/// From Bit Cake Studio's BitStrap
	/// https://assetstore.unity.com/publishers/4147
	/// Used with LINQ.
	/// </summary>
	public readonly struct Option<TA>
	{
		/// <summary>
		/// The is value
		/// </summary>
		// ReSharper disable once StaticMemberInGenericType
		private static readonly bool IsValue;

		/// <summary>
		/// The value
		/// </summary>
		private readonly TA _value;

		/// <summary>
		/// The is some
		/// </summary>
		private readonly bool _isSome;

		/// <summary>
		/// Gets the value of the is some
		/// </summary>
		private bool IsSome => _isSome && (IsValue || !ReferenceEquals(_value, null)) && !_value.Equals(null);

		/// <summary>
		/// Initializes a new instance of the "Option"
		/// </summary>
		static Option()
		{
			IsValue = typeof(TA).IsValueType;
		}

		/// <summary>
		/// Initializes a new instance of the "Option"
		/// </summary>
		/// <param name="value">The value</param>
		public Option(TA value)
		{
			_value = value;
			_isSome = true;
			_isSome = IsSome;
		}

		/// <summary>
		/// Initializes a new instance of the"Option" class
		/// </summary>
		public static implicit operator Option<TA>(TA value)
		{
			return new Option<TA>(value);
		}

		/// <summary>
		/// Matches the some
		/// </summary>
		/// <typeparam name="TB">The tb</typeparam>
		/// <param name="some">The some</param>
		/// <param name="none">The none</param>
		/// <returns>The tb</returns>
		public TB Match<TB>(Func<TA, TB> some, Func<TB> none)
		{
			return IsSome ? some(_value) : none();
		}

		/// <summary>
		/// Selects the select
		/// </summary>
		/// <typeparam name="TB">The tb</typeparam>
		/// <param name="select">The select</param>
		/// <returns>An option of tb</returns>
		public Option<TB> Select<TB>(Func<TA, TB> select)
		{
			return IsSome ? select(_value) : default(Option<TB>);
		}
	}
}
