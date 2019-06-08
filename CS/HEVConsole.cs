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
HEVConsole.cs
================================================
*/

using System;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
#endif

namespace HevLib {

	public enum EPrintType { eInfo, eWarning, eError };

	public static class HEVConsole {

		public static void Print( string Text, EPrintType _Type = EPrintType.eInfo ) {
			string msg = "";
#if UNITY_EDITOR || UNITY_STANDALONE
#else
			ConsoleColor lastColor = Console.ForegroundColor;
			ConsoleColor color = Console.ForegroundColor;
#endif
			switch ( _Type ) {
				case EPrintType.eInfo:
#if UNITY_EDITOR || UNITY_STANDALONE
				msg = "<color=blue>Info</color> - ";
#else
					color = ConsoleColor.Blue;
					msg = "Info - ";
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
	}
}
