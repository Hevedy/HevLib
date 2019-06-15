﻿/*
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
HEVConsole.cs
================================================
*/

using System;
#if UNITY_EDITOR || UNITY_STANDALONE
using System.Collections;
using UnityEngine;
#else
#endif

namespace HEVLib {

	public enum EPrintType { eDefault, eInfo, eSuccess, eWarning, eError };

	public static class HEVConsole {

		/// <summary>Print on console text.</summary>
		public static void Print( string Text = "Hello World!", EPrintType _Type = EPrintType.eDefault, bool _DebugOnly = false ) {
			string msg = "";
#if DEBUG || UNITY_EDITOR

#else
			if( _DebugOnly ) { return; }
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
#else
			ConsoleColor lastColor = Console.ForegroundColor;
			ConsoleColor color = Console.ForegroundColor;
#endif
			switch ( _Type ) {
				case EPrintType.eDefault:

					break;
				case EPrintType.eInfo:
#if UNITY_EDITOR || UNITY_STANDALONE
					msg = "<color=blue>Info</color> - ";
#else
					color = ConsoleColor.Blue;
					msg = "Info - ";
#endif
					break;
				case EPrintType.eSuccess:
#if UNITY_EDITOR || UNITY_STANDALONE
					msg = "<color=green>Success</color> - ";
#else
					color = ConsoleColor.Green;
					msg = "Success - ";
#endif
					break;
				case EPrintType.eWarning:
#if UNITY_EDITOR || UNITY_STANDALONE
					msg = "<color=yellow>Warning</color> - ";
#else
					color = ConsoleColor.Yellow;
					msg = "Warning - ";
#endif
					break;
				case EPrintType.eError:
#if UNITY_EDITOR || UNITY_STANDALONE
					msg = "<color=red>Error</color> - ";
#else
					color = ConsoleColor.Red;
					msg = "Error - ";
#endif
					break;
			}
#if UNITY_EDITOR || UNITY_STANDALONE
			Debug.Log( msg + Text );
#else
			Console.ForegroundColor = color;
			Console.WriteLine( msg + Text );
			Console.ForegroundColor = lastColor;
#endif
		}

		/// <summary>Print on console an empty line jump or line break.</summary>
		public static void LineJump( int _Lines = 1 ) {
			int lines = HEVMath.Min( _Lines, 10 );
#if UNITY_EDITOR || UNITY_STANDALONE
#else
			for ( int i = 0; i < lines; i++ ) {
				Console.WriteLine();
			}
#endif

		}

		/// <summary>Wait for imput or wait for time on thread call.</summary>
		public static void Wait( int _Seconds = 5, bool _AnyKey = false ) {
			// Don't allow more than 5 min
			int secs = HEVMath.Clamp( _Seconds, 1, 300 );
#if UNITY_EDITOR || UNITY_STANDALONE
			new WaitForSeconds( secs );
#else
			if ( _Seconds < 1 ) {
				if ( _AnyKey ) {
					Console.ReadKey();
				} else {
					Console.ReadLine();
				}
			} else {
				System.Threading.Thread.Sleep( secs * 1000 );
			}
#endif
		}
	}
}
