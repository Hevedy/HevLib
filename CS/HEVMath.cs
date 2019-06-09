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
using System.Runtime.CompilerServices;
#endif

namespace HevLib {
	public static class HEVMath {

		public static bool Validate( int _Min, int _Max, params int[] _IntList ) {
			foreach ( int num in _IntList ) {
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
			foreach ( float num in _DoubleList ) {
				if ( num >= _Min && num <= _Max ) { } else { return false; }
			}
			return true;
		}

		public static int FloorToInt( float _Value ) {
			return (int)Math.Floor( _Value );
		}

		public static int FloorToInt( double _Value ) {
			return (int)Math.Floor( _Value );
		}

		public static int TruncateToInt( float _Value ) {
			return (int)Math.Truncate( _Value );
		}

		public static int TruncateToInt( double _Value ) {
			return (int)Math.Truncate( _Value );
		}

		// Integral.Fractional
		// Returns signed fractional part of a float.
		public static float Fractional( float _Value ) {
			return ( _Value - (float)Math.Truncate( _Value ) );
		}

		// Returns signed fractional part of a double.
		public static double Fractional( double _Value ) {
			return ( _Value - (double)Math.Truncate( _Value ) );
		}

		public static int FractionalToInt( float _Value ) {
			return (int)Fractional( _Value );
		}

		public static int FractionalToInt( double _Value ) {
			return (int)Fractional( _Value );
		}

		// Returns the fractional part of a float.
		public static float Frac( float _Value ) {
			return ( _Value - (float)Math.Floor( _Value ) );
		}

		// Returns the fractional part of a double.
		public static double Frac( double _Value ) {
			return ( _Value - (double)Math.Floor( _Value ) );
		}

		public static int FracToInt( float _Value ) {
			return (int)Frac( _Value );
		}

		public static int FracToInt( double _Value ) {
			return (int)Frac( _Value );
		}

		public static int Count( int _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) ) + 1;
		}

		public static int Count( float _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) );
		}

		public static int Count( double _Value ) {
			return _Value == 0 ? 1 : FloorToInt( Math.Log10( Math.Abs( _Value ) ) );
		}

		public static int IntegralCount( float _Value ) {
			return FloorToInt( _Value );
		}

		public static int IntegralCount( double _Value ) {
			return FloorToInt( _Value );
		}

		public static int FractionalCount( float _Value ) {
			return Count( FracToInt( _Value ) );
		}

		public static int FractionalCount( double _Value ) {
			return Count( FracToInt( _Value ) );
		}

		public static float IntegersToFloat( int _A, int _B ) {
			float value = _A;
			int m = 1;
			for ( int i = 0; i <= Count( _B ); ++i ) { m *= 10; }
			return value + ( _B / m );
		}

		public static (int, int) FloatToIntegers( float _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			return (a, b);
		}

		public static int Invert( int _Value ) {
			return _Value * -1;
		}

		public static float Invert( float _Value ) {
			return _Value * -1.0f;
		}

		public static double Invert( double _Value ) {
			return _Value * -1.0;
		}

		public static int Reverse( int _Value ) {
			int value = 0;
			for ( int i = _Value; i != 0; i /= 10 ) {
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
#if UNITY_EDITOR || UNITY_STANDALONE
		private static int NonGeneric( bool x ) => 100;
		private static int NonGeneric( sbyte x ) => 101;
		private static int NonGeneric( byte x ) => 102;
		private static int NonGeneric( ushort x ) => 103;
		private static int NonGeneric( short x ) => 104;
		private static int NonGeneric( uint x ) => 105;
		private static int NonGeneric( int x ) => 106;
		private static int NonGeneric( ulong x ) => 107;
		private static int NonGeneric( long x ) => 108;
		private static int NonGeneric( float x ) => 109;
		private static int NonGeneric( double x ) => 110;
		private static int NonGeneric( decimal x ) => 111;
#else
		[MethodImpl( MethodImplOptions.AggressiveInlining )]
		private static int Generic<T>( T x ) {
			if ( typeof( T ) == typeof( bool ) ) return 100;
			else if ( typeof( T ) == typeof( byte ) ) return 101;
			else if ( typeof( T ) == typeof( sbyte ) ) return 102;
			else if ( typeof( T ) == typeof( ushort ) ) return 103;
			else if ( typeof( T ) == typeof( short ) ) return 104;
			else if ( typeof( T ) == typeof( int ) ) return 105;
			else if ( typeof( T ) == typeof( uint ) ) return 106;
			else if ( typeof( T ) == typeof( ulong ) ) return 107;
			else if ( typeof( T ) == typeof( long ) ) return 108;
			else if ( typeof( T ) == typeof( float ) ) return 109;
			else if ( typeof( T ) == typeof( double ) ) return 110;
			else if ( typeof( T ) == typeof( decimal ) ) return 111;
			else return -1;
		}
#endif

		//var result = Add<int, long, float>(1, 2);
		public static T3 Add<T1, T2, T3>( T1 left, T2 right ) {
			dynamic d1 = left;
			dynamic d2 = right;
			return (T3)( d1 + d2 );
		}

		public static T Add<T>( T a, T b ) where T : struct {
			int id = Generic( a );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)a + (byte)(object)b );
				case 102:
					return (T)(object)( (sbyte)(object)a + (sbyte)(object)b );
				case 103:
					return (T)(object)( (ushort)(object)a + (ushort)(object)b );
				case 104:
					return (T)(object)( (short)(object)a + (short)(object)b );
				case 105:
					return (T)(object)( (int)(object)a + (int)(object)b );
				case 110:
					return (T)(object)( (double)(object)a + (double)(object)b );
				default:
					return default( T );
			}
		}

	}
}
