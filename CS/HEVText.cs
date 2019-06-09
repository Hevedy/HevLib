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
HEVText.cs
================================================
*/

using System;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
#endif

namespace HevLib {
	public static class HEVText {

		public static bool StringIsNullOrInvalid( string _String ) {
			if ( string.IsNullOrEmpty( _String ) || _String == " " || _String == "  " || _String == "   " || _String == "    " ) {
				return true;
			} else {
				return false;
			}
		}

		public static bool StringValidate( params string[] _StringList ) {
			foreach ( string str in _StringList ) {
				if ( StringIsNullOrInvalid( str ) ) {
					return false;
				}
			}
			return true;
		}

		public static string StringArrayToString( string[] _Array, string _Separator = "\r\n" ) {
			string result = string.Join( _Separator, _Array );
			return result;
		}
	}
}
