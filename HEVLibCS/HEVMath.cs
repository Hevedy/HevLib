/*
===========================================================================
This code is part of the HevLib source code content in
HevLib by Hevedy <https://github.com/Hevedy/HevLib>
Mozilla Public License Version 2.0 (MPL-2.0)

Copyright (c) 2018-2020 Hevedy <https://github.com/Hevedy>

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
using System.Collections.Generic;
using System.Numerics;
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
			return (float)Math.Floor( _Value );
#endif
		}

		public static double Floor( double _Value ) {
			return (double)Math.Floor( _Value );
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

		public static int Lerp( int _Min, int _Max, float _Time ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return FloorToInt( Mathf.Lerp( _Min, _Max, _Time ) );
#else
			return FloorToInt(_Min * ( 1 - _Time ) + _Max * _Time);
#endif
		}

		public static float Lerp( float _Min, float _Max, float _Time ) {
#if UNITY_EDITOR || UNITY_STANDALONE
			return Mathf.Lerp( _Min, _Max, _Time );
#else
			return _Min * ( 1 - _Time ) + _Max * _Time;
#endif
		}

		public static double Lerp( double _Min, double _Max, float _Time ) {
			return _Min * ( 1 - _Time ) + _Max * _Time;
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

		public static sbyte OneMinus( sbyte _Value ) {
			return (sbyte)( 1 - _Value );
		}

		public static short OneMinus( short _Value ) {
			return (short)( 1 - _Value );
		}

		public static int OneMinus( int _Value ) {
			return 1 - _Value;
		}

		public static long OneMinus( long _Value ) {
			return 1 - _Value;
		}

		public static float OneMinus( float _Value ) {
			return 1.0f - _Value;
		}

		public static double OneMinus( double _Value ) {
			return 1.0 - _Value;
		}

		public static decimal OneMinus( decimal _Value ) {
			return 1.0m - _Value;
		}

		public static sbyte Negate( sbyte _Value ) {
			return (sbyte)(_Value * -1);
		}

		public static short Negate( short _Value ) {
			return (short)(_Value * -1);
		}

		public static int Negate( int _Value ) {
			return _Value * -1;
		}

		public static long Negate( long _Value ) {
			return _Value * -1;
		}

		public static float Negate( float _Value ) {
			return _Value * -1.0f;
		}

		public static double Negate( double _Value ) {
			return _Value * -1.0;
		}

		public static decimal Negate( decimal _Value ) {
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

		public static int LerpList( float _Time, List<int> _Array, out float _TimeMax ) {
			int count = _Array.Count;
			if ( count < 1 ) { _TimeMax = 0.0f; return 0; }
			float calTime = (count - 1) * 1.0f;
			_TimeMax = calTime;
			float curTime = Min( Max( _Time, 0.0f ), calTime );
			float curTimeFrac = Fractional( curTime );
			int curIndex = FloorToInt( curTime );
			int curIndexVal = _Array[curIndex];
			int nextIndex = Clamp(curIndex + 1, 0, count - 1);
			int nextIndexVal = _Array[nextIndex];
			return Lerp( curIndexVal, nextIndexVal, curTimeFrac );
		}

		public static float LerpList( float _Time, List<float> _Array, out float _TimeMax ) {
			int count = _Array.Count;
			if ( count < 1 ) { _TimeMax = 0.0f; return 0; }
			float calTime = ( count - 1 ) * 1.0f;
			_TimeMax = calTime;
			float curTime = Min( Max( _Time, 0.0f ), calTime );
			float curTimeFrac = Fractional( curTime );
			int curIndex = FloorToInt( curTime );
			float curIndexVal = _Array[curIndex];
			int nextIndex = Clamp( curIndex + 1, 0, count - 1 );
			float nextIndexVal = _Array[nextIndex];
			return Lerp( curIndexVal, nextIndexVal, curTimeFrac );
		}

		public static double LerpList( float _Time, List<double> _Array, out double _TimeMax ) {
			int count = _Array.Count;
			if ( count < 1 ) { _TimeMax = 0.0f; return 0; }
			float calTime = ( count - 1 ) * 1.0f;
			_TimeMax = calTime;
			float curTime = Min( Max( _Time, 0.0f ), calTime );
			float curTimeFrac = Fractional( curTime );
			int curIndex = FloorToInt( curTime );
			double curIndexVal = _Array[curIndex];
			int nextIndex = Clamp( curIndex + 1, 0, count - 1 );
			double nextIndexVal = _Array[nextIndex];
			return Lerp( curIndexVal, nextIndexVal, curTimeFrac );
		}

		public static float BoxPerimeter( float _XSize, float _YSize ) {
			return _XSize * 2 + _YSize * 2;
		}

		public static float BoxDiagonal( float _XSize, float _YSize ) {
			return (float)Math.Sqrt( ( _XSize * _XSize ) + ( _YSize * _YSize ) );
		}

		public static float BoxSide( float _Diagonal ) {
			return (float)Math.Sqrt( ( _Diagonal * _Diagonal ) / 2 );
		}

		public static float Distance( float _AX, float _AY, float _BX, float _BY ) {
			return (float)Math.Sqrt( Math.Pow( ( _BX - _AX ), 2 ) + Math.Pow( ( _BY - _AY ), 2 ) );
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


		/**
		* Closer number to given of Array
		* @param	Array of templated type
		* @param	Reference value templated type to compare
		* @param	Optional boolean to search only the closer values and no the equals
		* @param	Optional pointer for returning the index of the closer element, if multiple closer elements the first index is returned
		* @return	The closer value found in the array or default value if the array was empty or can't find a correct value
		*/
		public static int Closer( int _Reference, List<int> _Values, bool _NotEqual, out int _CloserIndex ) {
			if ( _Values.Count == 0 ) {
				_CloserIndex = 0;
				return 0;
			}

			int curCloser = ( ( _Reference - _Values[0] ) >= 0 ) ? ( _Reference - _Values[0] ) : -( _Reference - _Values[0] );
			int curCloserIndex = 0;
			if ( curCloser == 0 && _NotEqual ) {
				curCloserIndex = -1;
			}

			for ( int v = 1; v < _Values.Count; ++v ) {
				int value = ( ( _Reference - _Values[v] ) >= 0 ) ? ( _Reference - _Values[v] ) : -( _Reference - _Values[v] );
				if ( value < curCloser ) {
					if ( !_NotEqual || ( _NotEqual && value != 0f ) ) {
						curCloser = value;
						curCloserIndex = v;
					}
				}
			}

			_CloserIndex = curCloserIndex == -1 ? 0 : curCloserIndex;
			return _Values.Count == 0 ? 0 : _Values[curCloserIndex == -1 ? 0 : curCloserIndex];
		}

		public static float Closer( float _Reference, List<float> _Values, bool _NotEqual, out int _CloserIndex ) {
			if ( _Values.Count == 0 ) {
				_CloserIndex = 0;
				return 0f;
			}

			float curCloser = ( ( _Reference - _Values[0] ) >= 0 ) ? ( _Reference - _Values[0] ) : -( _Reference - _Values[0] );
			int curCloserIndex = 0;
			if ( curCloser == 0 && _NotEqual ) {
				curCloserIndex = -1;
			}

			for ( int v = 1; v < _Values.Count; ++v ) {
				float value = ( ( _Reference - _Values[v] ) >= 0 ) ? ( _Reference - _Values[v] ) : -( _Reference - _Values[v] );
				if ( value < curCloser ) {
					if ( !_NotEqual || ( _NotEqual && value != 0f ) ) {
						curCloser = value;
						curCloserIndex = v;
					}
				}
			}

			_CloserIndex = curCloserIndex == -1 ? 0 : curCloserIndex;
			return _Values.Count == 0 ? 0 : _Values[curCloserIndex == -1 ? 0 : curCloserIndex];
		}

		public static double Closer( float _Reference, List<double> _Values, bool _NotEqual, out int _CloserIndex ) {
			if ( _Values.Count == 0 ) {
				_CloserIndex = 0;
				return 0;
			}

			double curCloser = ( ( _Reference - _Values[0] ) >= 0 ) ? ( _Reference - _Values[0] ) : -( _Reference - _Values[0] );
			int curCloserIndex = 0;
			if ( curCloser == 0 && _NotEqual ) {
				curCloserIndex = -1;
			}

			for ( int v = 1; v < _Values.Count; ++v ) {
				double value = ( ( _Reference - _Values[v] ) >= 0 ) ? ( _Reference - _Values[v] ) : -( _Reference - _Values[v] );
				if ( value < curCloser ) {
					if ( !_NotEqual || ( _NotEqual && value != 0f ) ) {
						curCloser = value;
						curCloserIndex = v;
					}
				}
			}

			_CloserIndex = curCloserIndex == -1 ? 0 : curCloserIndex;
			return _Values.Count == 0 ? 0 : _Values[curCloserIndex == -1 ? 0 : curCloserIndex];
		}

		/**
		* Further number to given of Array
		* @param	Array of templated type
		* @param	Reference value templated type to compare
		* @param	Optional pointer for returning the index of the further element, if multiple further elements the first index is returned
		* @return	The further value found in the array or default value if the array was empty
		*/
		public static int Further( int _Reference, List<int> _Values, out int _FurtherIndex ) {
			if ( _Values.Count == 0 ) {
				_FurtherIndex = 0;
				return 0;
			}

			int curFurther = ( ( _Reference - _Values[0] ) >= 0 ) ? ( _Reference - _Values[0] ) : -( _Reference - _Values[0] );
			int curFurtherIndex = 0;
			for ( int v = 1; v < _Values.Count; ++v ) {
				int value = ( ( _Reference - _Values[v] ) >= 0 ) ? ( _Reference - _Values[v] ) : -( _Reference - _Values[v] );
				if ( curFurther < value ) {
					curFurther = value;
					curFurtherIndex = v;
				}
			}

			_FurtherIndex = curFurtherIndex == -1 ? 0 : curFurtherIndex;
			return _Values.Count == 0 ? 0 : _Values[curFurtherIndex == -1 ? 0 : curFurtherIndex];
		}

		public static float Further( float _Reference, List<float> _Values, out int _FurtherIndex ) {
			if ( _Values.Count == 0 ) {
				_FurtherIndex = 0;
				return 0.0f;
			}

			float curFurther = ( ( _Reference - _Values[0] ) >= 0 ) ? ( _Reference - _Values[0] ) : -( _Reference - _Values[0] );
			int curFurtherIndex = 0;
			for ( int v = 1; v < _Values.Count; ++v ) {
				float value = ( ( _Reference - _Values[v] ) >= 0 ) ? ( _Reference - _Values[v] ) : -( _Reference - _Values[v] );
				if ( curFurther < value ) {
					curFurther = value;
					curFurtherIndex = v;
				}
			}

			_FurtherIndex = curFurtherIndex == -1 ? 0 : curFurtherIndex;
			return _Values.Count == 0 ? 0 : _Values[curFurtherIndex == -1 ? 0 : curFurtherIndex];
		}

		public static double Further( double _Reference, List<double> _Values, out int _FurtherIndex ) {
			if ( _Values.Count == 0 ) {
				_FurtherIndex = 0;
				return 0.0f;
			}

			double curFurther = ( ( _Reference - _Values[0] ) >= 0 ) ? ( _Reference - _Values[0] ) : -( _Reference - _Values[0] );
			int curFurtherIndex = 0;
			for ( int v = 1; v < _Values.Count; ++v ) {
				double value = ( ( _Reference - _Values[v] ) >= 0 ) ? ( _Reference - _Values[v] ) : -( _Reference - _Values[v] );
				if ( curFurther < value ) {
					curFurther = value;
					curFurtherIndex = v;
				}
			}

			_FurtherIndex = curFurtherIndex == -1 ? 0 : curFurtherIndex;
			return _Values.Count == 0 ? 0 : _Values[curFurtherIndex == -1 ? 0 : curFurtherIndex];
		}

		// Calculate grids on hex(circles)
		public static int CalculateHexGrid( float _XSize, float _YSize, float _XLocation, float _YLocation, bool _Center, float _Radius, bool _Hex,
			out int _HexRows, out int _HexColums, out float _HexXSize, out float _HexYSize, out float _HexDistance, out float _HexOverlap,
			out List<float> _HexLocationX, out List<float> _HexLocationY ) {
			float xM = _XSize / 2;
			float yM = _YSize / 2;
			float hexSize = _Radius * 2;
			float hexDistance = BoxSide( hexSize );
			float hexOverlap = hexSize - hexDistance;
			int hexXNum = FloorToInt( ( ( _XSize / hexDistance ) + ( _XSize % hexDistance ) ) );
			int hexYNum = FloorToInt( ( ( _YSize / hexDistance ) + ( _YSize % hexDistance ) ) );
			float hexXSize = hexXNum * hexDistance;
			float hexYSize = hexYNum * hexDistance;
			float fXLocation = _XLocation;
			float fYLocation = _YLocation;
			if ( !_Center ) {
				fXLocation = ( fXLocation - xM );
				fYLocation = ( fYLocation - yM );
			} else {
				fXLocation = fXLocation - ( hexXSize / 2 );
				fYLocation = fYLocation - ( hexYSize / 2 );
			}

			float lXDefault = 0;
			float lYDefault = 0;
			float lX = lXDefault;
			float lY = lYDefault;

			List<float> hexLocationX = new List<float>( hexXNum );
			List<float> hexLocationY = new List<float>( hexYNum );

			bool sw = false;
			for ( int y = 0; y < hexXNum; y++ ) {
				if ( sw ) {
					lX = lXDefault;
				} else {
					lX = hexDistance / 2;
				}
				for ( int x = 0; x < hexYNum; x++ ) {
					hexLocationX[x] = lX - ( hexDistance / 2 );
					hexLocationY[y] = lY - ( hexDistance / 2 );
					lX = lX + hexDistance;
				}
				if ( _Hex ) sw = !sw;
				lY = lY + hexDistance;
			}

			_HexRows = hexXNum;
			_HexColums = hexYNum;
			_HexXSize = hexXSize;
			_HexYSize = hexYSize;
			_HexDistance = hexDistance;
			_HexOverlap = hexOverlap;

			_HexLocationX = hexLocationX;
			_HexLocationY = hexLocationY;

			return (int)( hexXNum * hexYNum );
		}

		public static int SimulateHexGrid( float _GridXSize, float _GridYSize, float _GridXLocation, float _GridYLocation, bool _GridCenter, float _HexRadius,
			float _CurXLocation, float _CurYLocation, out float _HexXLocation, out float _HexYLocation, out float _Distance, bool _Hex = true ) {

			int hexRows = 0;
			int hexColums = 0;
			float hexXSize = 0;
			float hexYSize = 0;
			float hexDistance = 0;
			float hexOverlap = 0;
			List<float> hexLocationX;
			List<float> hexLocationY;

			int hexNum = CalculateHexGrid( _GridXSize, _GridYSize, _GridXLocation, _GridYLocation, _GridCenter, _HexRadius, _Hex,
			out hexRows, out hexColums, out hexXSize, out hexYSize, out hexDistance, out hexOverlap, out hexLocationX, out hexLocationY );

			float distance = Distance( hexLocationX[0], hexLocationY[0], _CurXLocation, _CurYLocation );
			int index = 0;
			float distCalc;
			for ( int i = 0; i < hexLocationX.Count; i++ ) {
				distCalc = Distance( hexLocationX[i], hexLocationY[i], _CurXLocation, _CurYLocation );
				if ( distCalc < distance ) {
					distance = distCalc;
					index = i;
				}
			}

			_HexXLocation = hexLocationX[index];
			_HexYLocation = hexLocationY[index];
			_Distance = distance;

			return index;
		}

	}
}
