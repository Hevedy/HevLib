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
HEVMathHelpers.cs
================================================
*/

using System;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
using System.Runtime.CompilerServices;
#endif

namespace HevLib {
	public static class HEVMathHelpers {

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
		[MethodImpl( MethodImplOptions.AggressiveInlining )] // Post Net Core 2.0 Optimized
		private static int Generic<T>( T x ) {
			if ( typeof( T ) == typeof( bool ) ) return 100;
			else if ( typeof( T ) == typeof( byte ) ) return 101;
			else if ( typeof( T ) == typeof( sbyte ) ) return 102;
			else if ( typeof( T ) == typeof( ushort ) ) return 103;
			else if ( typeof( T ) == typeof( short ) ) return 104;
			else if ( typeof( T ) == typeof( uint ) ) return 105;
			else if ( typeof( T ) == typeof( int ) ) return 106;
			else if ( typeof( T ) == typeof( ulong ) ) return 107;
			else if ( typeof( T ) == typeof( long ) ) return 108;
			else if ( typeof( T ) == typeof( float ) ) return 109;
			else if ( typeof( T ) == typeof( double ) ) return 110;
			else if ( typeof( T ) == typeof( decimal ) ) return 111;
			else return -1;
		}
#endif

		//Add<double>(3.6, 2.12)
		// Adds
		public static T Add<T>( T _A, T _B ) where T : struct {
			int idA = Generic( _A );
			int idB = Generic( _B );
			int id = ( idA == idB ? idA : 0 );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)_A + (byte)(object)_B );
				case 102:
					return (T)(object)( (sbyte)(object)_A + (sbyte)(object)_B );
				case 103:
					return (T)(object)( (ushort)(object)_A + (ushort)(object)_B );
				case 104:
					return (T)(object)( (short)(object)_A + (short)(object)_B );
				case 105:
					return (T)(object)( (uint)(object)_A + (uint)(object)_B );
				case 106:
					return (T)(object)( (int)(object)_A + (int)(object)_B );
				case 107:
					return (T)(object)( (ulong)(object)_A + (ulong)(object)_B );
				case 108:
					return (T)(object)( (long)(object)_A + (long)(object)_B );
				case 109:
					return (T)(object)( (float)(object)_A + (float)(object)_B );
				case 110:
					return (T)(object)( (double)(object)_A + (double)(object)_B );
				case 111:
					return (T)(object)( (decimal)(object)_A + (decimal)(object)_B );
				default:
					return default( T );
			}
		}

		//var result = Add<int, long, float>(1, 2);
		public static T3 Add<T1, T2, T3>( T1 _A, T2 _B ) {
			dynamic d1 = _A;
			dynamic d2 = _B;
			return (T3)( d1 + d2 );
		}

		// Subtracts
		public static T Sub<T>( T _A, T _B ) where T : struct {
			int idA = Generic( _A );
			int idB = Generic( _B );
			int id = ( idA == idB ? idA : 0 );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)_A + (byte)(object)_B );
				case 102:
					return (T)(object)( (sbyte)(object)_A + (sbyte)(object)_B );
				case 103:
					return (T)(object)( (ushort)(object)_A + (ushort)(object)_B );
				case 104:
					return (T)(object)( (short)(object)_A + (short)(object)_B );
				case 105:
					return (T)(object)( (uint)(object)_A + (uint)(object)_B );
				case 106:
					return (T)(object)( (int)(object)_A + (int)(object)_B );
				case 107:
					return (T)(object)( (ulong)(object)_A + (ulong)(object)_B );
				case 108:
					return (T)(object)( (long)(object)_A + (long)(object)_B );
				case 109:
					return (T)(object)( (float)(object)_A + (float)(object)_B );
				case 110:
					return (T)(object)( (double)(object)_A + (double)(object)_B );
				case 111:
					return (T)(object)( (decimal)(object)_A + (decimal)(object)_B );
				default:
					return default( T );
			}
		}

		public static T3 Sub<T1, T2, T3>( T1 _A, T2 _B ) {
			dynamic d1 = _A;
			dynamic d2 = _B;
			return (T3)( d1 - d2 );
		}

		// Multiplies
		public static T Mul<T>( T _A, T _B ) where T : struct {
			int idA = Generic( _A );
			int idB = Generic( _B );
			int id = ( idA == idB ? idA : 0 );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)_A * (byte)(object)_B );
				case 102:
					return (T)(object)( (sbyte)(object)_A * (sbyte)(object)_B );
				case 103:
					return (T)(object)( (ushort)(object)_A * (ushort)(object)_B );
				case 104:
					return (T)(object)( (short)(object)_A * (short)(object)_B );
				case 105:
					return (T)(object)( (uint)(object)_A * (uint)(object)_B );
				case 106:
					return (T)(object)( (int)(object)_A * (int)(object)_B );
				case 107:
					return (T)(object)( (ulong)(object)_A * (ulong)(object)_B );
				case 108:
					return (T)(object)( (long)(object)_A * (long)(object)_B );
				case 109:
					return (T)(object)( (float)(object)_A * (float)(object)_B );
				case 110:
					return (T)(object)( (double)(object)_A * (double)(object)_B );
				case 111:
					return (T)(object)( (decimal)(object)_A * (decimal)(object)_B );
				default:
					return default( T );
			}
		}

		public static T3 Mul<T1, T2, T3>( T1 _A, T2 _B ) {
			dynamic d1 = _A;
			dynamic d2 = _B;
			return (T3)( d1 * d2 );
		}

		// Divides
		public static T Div<T>( T _A, T _B ) where T : struct {
			int idA = Generic( _A );
			int idB = Generic( _B );
			int id = ( idA == idB ? idA : 0 );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)_A / (byte)(object)_B );
				case 102:
					return (T)(object)( (sbyte)(object)_A / (sbyte)(object)_B );
				case 103:
					return (T)(object)( (ushort)(object)_A / (ushort)(object)_B );
				case 104:
					return (T)(object)( (short)(object)_A / (short)(object)_B );
				case 105:
					return (T)(object)( (uint)(object)_A / (uint)(object)_B );
				case 106:
					return (T)(object)( (int)(object)_A / (int)(object)_B );
				case 107:
					return (T)(object)( (ulong)(object)_A / (ulong)(object)_B );
				case 108:
					return (T)(object)( (long)(object)_A / (long)(object)_B );
				case 109:
					return (T)(object)( (float)(object)_A / (float)(object)_B );
				case 110:
					return (T)(object)( (double)(object)_A / (double)(object)_B );
				case 111:
					return (T)(object)( (decimal)(object)_A / (decimal)(object)_B );
				default:
					return default( T );
			}
		}

		public static T3 Div<T1, T2, T3>( T1 _A, T2 _B ) {
			dynamic d1 = _A;
			dynamic d2 = _B;
			return (T3)( d1 / d2 );
		}

		// Modulus
		public static T Mod<T>( T _A, T _B ) where T : struct {
			int idA = Generic( _A );
			int idB = Generic( _B );
			int id = ( idA == idB ? idA : 0 );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)_A % (byte)(object)_B );
				case 102:
					return (T)(object)( (sbyte)(object)_A % (sbyte)(object)_B );
				case 103:
					return (T)(object)( (ushort)(object)_A % (ushort)(object)_B );
				case 104:
					return (T)(object)( (short)(object)_A % (short)(object)_B );
				case 105:
					return (T)(object)( (uint)(object)_A % (uint)(object)_B );
				case 106:
					return (T)(object)( (int)(object)_A % (int)(object)_B );
				case 107:
					return (T)(object)( (ulong)(object)_A % (ulong)(object)_B );
				case 108:
					return (T)(object)( (long)(object)_A % (long)(object)_B );
				case 109:
					return (T)(object)( (float)(object)_A % (float)(object)_B );
				case 110:
					return (T)(object)( (double)(object)_A % (double)(object)_B );
				case 111:
					return (T)(object)( (decimal)(object)_A % (decimal)(object)_B );
				default:
					return default( T );
			}
		}

		public static T3 Mod<T1, T2, T3>( T1 _A, T2 _B ) {
			dynamic d1 = _A;
			dynamic d2 = _B;
			return (T3)( d1 % d2 );
		}

		// Increment
		public static T Inc<T>( T _A ) where T : struct {
			int id = Generic( _A );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)_A + 1 );
				case 102:
					return (T)(object)( (sbyte)(object)_A + 1 );
				case 103:
					return (T)(object)( (ushort)(object)_A + 1 );
				case 104:
					return (T)(object)( (short)(object)_A + 1 );
				case 105:
					return (T)(object)( (uint)(object)_A + 1 );
				case 106:
					return (T)(object)( (int)(object)_A + 1 );
				case 107:
					return (T)(object)( (ulong)(object)_A + 1 );
				case 108:
					return (T)(object)( (long)(object)_A + 1 );
				case 109:
					return (T)(object)( (float)(object)_A + 1 );
				case 110:
					return (T)(object)( (double)(object)_A + 1 );
				case 111:
					return (T)(object)( (decimal)(object)_A + 1 );
				default:
					return default( T );
			}
		}

		public static T2 Inc<T1, T2>( T1 _A ) {
			dynamic d1 = _A;
			return (T2)( d1 + 1 );
		}

		// Decrement
		public static T Dec<T>( T _A ) where T : struct {
			int id = Generic( _A );
			switch ( id ) {
				case 100:
					return default( T );
				case 101:
					return (T)(object)( (byte)(object)_A - 1 );
				case 102:
					return (T)(object)( (sbyte)(object)_A - 1 );
				case 103:
					return (T)(object)( (ushort)(object)_A - 1 );
				case 104:
					return (T)(object)( (short)(object)_A - 1 );
				case 105:
					return (T)(object)( (uint)(object)_A - 1 );
				case 106:
					return (T)(object)( (int)(object)_A - 1 );
				case 107:
					return (T)(object)( (ulong)(object)_A - 1 );
				case 108:
					return (T)(object)( (long)(object)_A - 1 );
				case 109:
					return (T)(object)( (float)(object)_A - 1 );
				case 110:
					return (T)(object)( (double)(object)_A - 1 );
				case 111:
					return (T)(object)( (decimal)(object)_A - 1 );
				default:
					return default( T );
			}
		}

		public static T2 Dec<T1, T2>( T1 _A ) {
			dynamic d1 = _A;
			return (T2)( d1 - 1 );
		}

	}
}
