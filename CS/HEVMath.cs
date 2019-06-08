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
			return (_Value - (float)Math.Truncate( _Value ));
		}

		// Returns signed fractional part of a double.
		public static double Fractional( double _Value ) {
			return (_Value - (double)Math.Truncate( _Value ));
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
			for ( int i = 0; i <= Count(_B); ++i ) { m *= 10; }
			return value + ( _B / m );
		}

		public static (int,int) FloatToIntegers( float _Value ) {
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

		public static float Revert( float _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			int m = 1;
			for ( int i = 0; i <= Count( _Value ); ++i ) { m *= 10; }
			return b + ( a / m );
		}

		public static double Revert( double _Value ) {
			int a = TruncateToInt( _Value );
			int b = FracToInt( _Value );
			int m = 1;
			for ( int i = 0; i <= Count( _Value ); ++i ) { m *= 10; }
			return b + ( a / m );
		}
	}
}
