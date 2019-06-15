/*
===========================================================================
This code is part of the HevLib source code content in
HevLib by Hevedy <https://github.com/Hevedy/HevLib>
Mozilla Public License Version 2.0 (MPL-2.0)

Copyright (c) 2018-2019 Hevedy <https://github.com/Hevedy>

This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at http://mozilla.org/MPL/2.0/.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
===========================================================================
*/

/*
================================================
HEVMath.cs
================================================
*/

using System;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
#endif

namespace HEVLib {
	public static class HEVMath {

		public static bool Validate( sbyte _Min, sbyte _Max, params sbyte[] _SByteList ) {
			foreach ( sbyte num in _SByteList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static bool Validate( short _Min, short _Max, params short[] _ShortList ) {
			foreach ( short num in _ShortList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static bool Validate( int _Min, int _Max, params int[] _IntList ) {
			foreach ( int num in _IntList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static bool Validate( long _Min, long _Max, params long[] _LongList ) {
			foreach ( long num in _LongList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static bool Validate( float _Min, float _Max, params float[] _FloatList ) {
			foreach ( float num in _FloatList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static bool Validate( double _Min, double _Max, params double[] _DoubleList ) {
			foreach ( double num in _DoubleList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static bool Validate( decimal _Min, decimal _Max, params decimal[] _DecimalList ) {
			foreach ( decimal num in _DecimalList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static float Floor( float _Value ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Floor( _Value );
#else
			return Math.Floor( _Value );
#endif
		}

		public static double Floor( double _Value ) {
			return Math.Floor( _Value );
		}

		public static int Min( int _A, int _B ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Min( _A, _B );
#else
			return Math.Min( _A, _B );
#endif
		}

		public static float Min( float _A, float _B ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Min( _A, _B );
#else
			return Math.Min( _A, _B );
#endif
		}

		public static double Min( double _A, double _B ) {
			return Math.Min( _A, _B );
		}

		public static int Max( int _A, int _B ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Max( _A, _B );
#else
			return Math.Max( _A, _B );
#endif
		}

		public static float Max( float _A, float _B ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Max( _A, _B );
#else
			return Math.Max( _A, _B );
#endif
		}

		public static double Max( double _A, double _B ) {
			return Math.Max( _A, _B );
		}

		public static int Clamp( int _Value, int _Min, int _Max ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Clamp( _Value, _Min, _Max );
#else
			return Math.Clamp( _Value, _Min, _Max );
#endif
		}

		public static float Clamp( float _Value, float _Min, float _Max ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Clamp( _Value, _Min, _Max );
#else
			return Math.Clamp( _Value, _Min, _Max );
#endif
		}

		public static int FloorToInt( float _Value ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.FloorToInt( _Value );
#else
			return (int)Math.Floor( _Value );
#endif
		}

		public static int FloorToInt( double _Value ) {
			return (int)Math.Floor( _Value );

		}

		public static int FloorToInt( decimal _Value ) {
			return (int)Math.Floor( _Value );
		}

		public static int TruncateToInt( float _Value ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.RoundToInt( _Value );
#else
			return (int)Math.Truncate( _Value );
#endif
		}

		public static int TruncateToInt( double _Value ) {
			return (int)Math.Truncate( _Value );
		}

		public static int TruncateToInt( decimal _Value ) {
			return (int)Math.Truncate( _Value );
		}

		// Integral.Fractional
		// Returns signed fractional part of a float.
		public static float Fractional( float _Value ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return ( _Value - Mathf.Round( _Value ) );
#else
			return ( _Value - (float)Math.Truncate( _Value ) );
#endif
		}

		// Returns signed fractional part of a double.
		public static double Fractional( double _Value ) {
			return ( _Value - (double)Math.Truncate( _Value ) );
		}

		// Returns signed fractional part of a double.
		public static decimal Fractional( decimal _Value ) {
			return ( _Value - (decimal)Math.Truncate( _Value ) );
		}

		public static int FractionalToInt( float _Value ) {
			return (int)Fractional( _Value );
		}

		public static int FractionalToInt( double _Value ) {
			return (int)Fractional( _Value );
		}

		public static int FractionalToInt( decimal _Value ) {
			return (int)Fractional( _Value );
		}

		// Returns the fractional part of a float.
		public static float Frac( float _Value ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return ( _Value - Mathf.Round( _Value ) );
#else
			return ( _Value - (float)Math.Floor( _Value ) );
#endif
		}

		// Returns the fractional part of a double.
		public static double Frac( double _Value ) {
			return ( _Value - (double)Math.Floor( _Value ) );
		}

		// Returns the fractional part of a decimal.
		public static decimal Frac( decimal _Value ) {
			return ( _Value - (decimal)Math.Floor( _Value ) );
		}

		public static int FracToInt( float _Value ) {
			return (int)Frac( _Value );
		}

		public static int FracToInt( double _Value ) {
			return (int)Frac( _Value );
		}

		public static int FracToInt( decimal _Value ) {
			return (int)Frac( _Value );
		}

		public static int Count( sbyte _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) ) + 1;
		}

		public static int Count( short _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) ) + 1;
		}

		public static int Count( int _Value ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return _Value == 0 ? 1 : FloorToInt( Mathf.Log10( Mathf.Abs( _Value ) ) ) + 1;
#else
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) ) + 1;
#endif
		}

		public static int Count( long _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) ) + 1;
		}

		public static int Count( float _Value ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return _Value == 0 ? 1 : FloorToInt( Mathf.Log10( Mathf.Abs( _Value ) ) );
#else
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) );
#endif
		}

		public static int Count( double _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) );
		}

		public static int Count( decimal _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( (double)_Value ) ) ); // Data lost
		}

		public static int IntegralCount( float _Value ) {
			return FloorToInt( _Value );
		}

		public static int IntegralCount( double _Value ) {
			return FloorToInt( _Value );
		}

		public static int IntegralCount( decimal _Value ) {
			return FloorToInt( _Value );
		}

		public static int FractionalCount( float _Value ) {
			return Count( FracToInt( _Value ) );
		}

		public static int FractionalCount( double _Value ) {
			return Count( FracToInt( _Value ) );
		}

		public static int FractionalCount( decimal _Value ) {
			return Count( FracToInt( _Value ) );
		}

		public static float IntegersToFloat( int _A, int _B ) {
			float value = _A;
			int m = 1;
			for ( int i = 0; i <= Count( _B ); ++i ) { m *= 10; }
			return value + ( _B / m );
		}

		public static double IntegersToDouble( int _A, int _B ) {
			double value = _A;
			int m = 1;
			for ( int i = 0; i <= Count( _B ); ++i ) { m *= 10; }
			return value + ( _B / m );
		}

		public static decimal IntegersToDecimal( int _A, int _B ) {
			decimal value = _A;
			int m = 1;
			for ( int i = 0; i <= Count( _B ); ++i ) { m *= 10; }
			return value + ( _B / m );
		}

		public static (int, int) FloatToIntegers( float _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			return (a, b);
		}

		public static (int, int) DoubleToIntegers( double _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			return (a, b);
		}

		public static (int, int) DecimalToIntegers( decimal _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			return (a, b);
		}

		public static sbyte Invert( sbyte _Value ) {
			return (sbyte)(_Value * -1);
		}

		public static short Invert( short _Value ) {
			return (short)(_Value * -1);
		}

		public static int Invert( int _Value ) {
			return _Value * -1;
		}

		public static long Invert( long _Value ) {
			return _Value * -1;
		}

		public static float Invert( float _Value ) {
			return _Value * -1.0f;
		}

		public static double Invert( double _Value ) {
			return _Value * -1.0;
		}

		public static decimal Invert( decimal _Value ) {
			return _Value * -1.0m;
		}

		public static sbyte Reverse( sbyte _Value ) {
			sbyte value = 0;
			for ( sbyte i = _Value; i != 0; i /= 10 ) {
				value = (sbyte)( value * 10 + i % 10 );
			}
			return value;
		}

		public static short Reverse( short _Value ) {
			short value = 0;
			for ( short i = _Value; i != 0; i /= 10 ) {
				value = (short)( value * 10 + i % 10 );
			}
			return value;
		}

		public static int Reverse( int _Value ) {
			int value = 0;
			for ( int i = _Value; i != 0; i /= 10 ) {
				value = value * 10 + i % 10;
			}
			return value;
		}

		public static long Reverse( long _Value ) {
			long value = 0;
			for ( long i = _Value; i != 0; i /= 10 ) {
				value = value * 10 + i % 10;
			}
			return value;
		}

		public static float Reverse( float _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			int m = 1;
			for ( int i = 0; i <= Count( _Value ); ++i ) { m *= 10; }
			return b + ( a / m );
		}

		public static double Reverse( double _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			int m = 1;
			for ( int i = 0; i <= Count( _Value ); ++i ) { m *= 10; }
			return b + ( a / m );
		}

		public static decimal Reverse( decimal _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			int m = 1;
			for ( int i = 0; i <= Count( _Value ); ++i ) { m *= 10; }
			return b + ( a / m );
		}

		public static sbyte Closer( sbyte _Value, sbyte _A, sbyte _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) <= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static short Closer( short _Value, short _A, short _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) <= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static int Closer( int _Value, int _A, int _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) <= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static long Closer( long _Value, long _A, long _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) <= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static float Closer( float _Value, float _A, float _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) <= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static double Closer( double _Value, double _A, double _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) <= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static decimal Closer( decimal _Value, decimal _A, decimal _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) <= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static sbyte Further( sbyte _Value, sbyte _A, sbyte _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) >= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static short Further( short _Value, short _A, short _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) >= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static int Further( int _Value, int _A, int _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) >= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static long Further( long _Value, long _A, long _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) >= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static float Further( float _Value, float _A, float _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) >= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static double Further( double _Value, double _A, double _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) >= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}

		public static decimal Further( decimal _Value, decimal _A, decimal _B ) {
			return ( ( ( _Value - _A ) >= 0 ) ? ( _Value - _A ) : -( _Value - _A ) ) >= ( ( ( _Value - _B ) >= 0 ) ? 
				( _Value - _B ) : -( _Value - _B ) ) ? _A : _B;
		}
	}


}
