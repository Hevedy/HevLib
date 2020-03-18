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
HEVRandom.cs
================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else

#endif

namespace HEVLib {
	public static class HEVRandom {

		private static readonly System.Random RandomSeedFixed = new System.Random();
		private static System.Random RandomSeed = RandomSeedFixed;
		private static readonly RNGCryptoServiceProvider CryptoGenerator = new RNGCryptoServiceProvider();

		public static void SetSeed( int _Seed ) {
			RandomSeed = new System.Random( _Seed );
		}

		/// <returns>Returns a pseudo-random integer variable.</returns>
		public static int Int() {
			return RandomSeed.Next();
		}

		/// <returns>Returns a pseudo-random normalized float variable.</returns>
		public static float Float() {
			return (float)RandomSeed.NextDouble();
		}

		/// <returns>Returns a pseudo-random normalized double variable.</returns>
		public static double Double() {
			return RandomSeed.NextDouble();
		}

		/// <returns>Returns a pseudo-random integer variable.</returns>
		public static int Int( int _Max ) {
			return RandomSeed.Next( _Max );
		}

		/// <returns>Returns a pseudo-random normalized float variable.</returns>
		public static float Float( float _Max ) {
			return (float)RandomSeed.NextDouble() * _Max;
		}

		/// <returns>Returns a pseudo-random normalized double variable.</returns>
		public static double Double( float _Max) {
			return RandomSeed.NextDouble() * _Max;
		}

		public static string Char( string _Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" ) {
			return new string( Enumerable.Repeat( _Chars, 1 )
			  .Select( s => s[Int( s.Length )] ).ToArray() );
		}

		public static string String( int _Length = 10, string _Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" ) {
			return new string( Enumerable.Repeat( _Chars, _Length )
			  .Select( s => s[Int( s.Length )] ).ToArray() );
		}

		/// <returns>Returns a pseudo-random integer variable within the given min/max range.</returns>
		public static int Int( int _Min, int _Max ) {
			return RandomSeed.Next( _Min, _Max );
		}

		/// <returns>Returns a pseudo-random float variable within the given min/max range.</returns>
		public static float Float( float _Min, float _Max ) {
			return Float() * ( ( _Max - _Min ) + _Min );
		}

		/// <returns>Returns a pseudo-random double variable within the given min/max range.</returns>
		public static double Double( double _Min, double _Max ) {
			return Double() * ( ( _Max - _Min ) + _Min );
		}

		/// <returns>Returns a pseudo-random integer index based on weights.</returns>
		public static int RandomByWeight( List<float> _Weights ) {
			int index = 0;
			int maxIndex = _Weights.Count - 1;

			if ( maxIndex < 0 ) { return -1; }

			float[] weights = _Weights.ToArray();

			for ( int i = 0; i < weights.Length; i++ ) {
				weights[i] = weights[i] * Float( 0.0f, 1.0f );
			}

			float maxValue = weights.Max();
			index = weights.ToList().IndexOf( maxValue );

			return index;
		}

		public static int CryptoRandomInt( int _Min, int _Max ) {
			byte[] randomNumber = new byte[1];
			CryptoGenerator.GetBytes( randomNumber );

			double asciiValueOfRandomCharacter = Convert.ToDouble( randomNumber[0] );
			double multiplier = HEVMath.Max( 0, ( asciiValueOfRandomCharacter / 255d ) - 0.00000000001d );
			int range = _Max - _Min + 1;
			double randomValueInRange = HEVMath.Floor( multiplier * range );

			return (int)( _Min + randomValueInRange );
		}

		public static int CryptoRandomInt( uint _Length = 1 ) {
			int length = (int)HEVMath.Max( 1, _Length );
			return CryptoRandomInt( 0, ( 10 ^ length ) - 1 );
		}
	}
}
