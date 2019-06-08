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
HEVRandom.cs
================================================
*/

using System;
using System.Collections.Generic;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
using System.Linq;
#endif

namespace HevLib {
	public static class HEVRandom {

		public static System.Random FixedSeedRandom;

		public static void Initialize( int _Seed ) {
			FixedSeedRandom = new System.Random( _Seed );
		}

		/// <returns>Returns a pseudo-random integer variable.</returns>
		public static int RandomInt() {
			return FixedSeedRandom.Next();
		}

		/// <returns>Returns a pseudo-random normalized float variable.</returns>
		public static float RandomFloat() {
			return (float)FixedSeedRandom.NextDouble();
		}

		/// <returns>Returns a pseudo-random normalized double variable.</returns>
		public static double RandomDouble() {
			return FixedSeedRandom.NextDouble();
		}

		/// <returns>Returns a pseudo-random integer variable.</returns>
		public static int RandomInt( int _Max ) {
			return FixedSeedRandom.Next( _Max );
		}

		/// <returns>Returns a pseudo-random normalized float variable.</returns>
		public static float RandomFloat( float _Max ) {
			return (float)FixedSeedRandom.NextDouble() * _Max;
		}

		/// <returns>Returns a pseudo-random normalized double variable.</returns>
		public static double RandomDouble( float _Max) {
			return FixedSeedRandom.NextDouble() * _Max;
		}

		public static string RandomChar( string _Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" ) {
			return new string( Enumerable.Repeat( _Chars, 1 )
			  .Select( s => s[RandomInt( s.Length )] ).ToArray() );
		}

		public static string RandomString( int _Length = 10, string _Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" ) {
			return new string( Enumerable.Repeat( _Chars, _Length )
			  .Select( s => s[RandomInt( s.Length )] ).ToArray() );
		}

		/// <returns>Returns a pseudo-random integer variable within the given min/max range.</returns>
		public static int RandomInt( int _Min, int _Max ) {
			return FixedSeedRandom.Next( _Min, _Max );
		}

		/// <returns>Returns a pseudo-random float variable within the given min/max range.</returns>
		public static float RandomFloat( float _Min, float _Max ) {
			return RandomFloat() * ( ( _Max - _Min ) + _Min );
		}

		/// <returns>Returns a pseudo-random double variable within the given min/max range.</returns>
		public static double RandomDouble( double _Min, double _Max ) {
			return RandomDouble() * ( ( _Max - _Min ) + _Min );
		}

		/// <returns>Returns a pseudo-random integer index based on weights.</returns>
		public static int RandomByWeight( List<float> _Weights ) {
			int index = 0;
			int maxIndex = _Weights.Count - 1;

			if ( maxIndex < 0 ) { return -1; }

			float[] weights = _Weights.ToArray();

			for ( int i = 0; i < weights.Length; i++ ) {
				weights[i] = weights[i] * RandomFloat( 0.0f, 1.0f );
			}

			float maxValue = weights.Max();
			index = weights.ToList().IndexOf( maxValue );

			return index;
		}
	}
}
