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
HEVText.cs
================================================
*/

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else

#endif

namespace HEVLib {
	public static class HEVText {

		private static bool IsNullOrInvalid( string _String ) {
			if ( string.IsNullOrEmpty( _String ) || _String == " " || _String == "  " || _String == "   " || _String == "    " ) {
				return true;
			} else {
				return false;
			}
		}

		/// <summary>Validate a string or a list of strings, make sure aren't empty, invalid or null.</summary>
		public static bool Validate( params string[] _StringList ) {
			foreach ( string str in _StringList ) {
				if ( IsNullOrInvalid( str ) ) {
					return false;
				}
			}
			return true;
		}

		public static bool TryParse( string _String, out bool _Result ) {
			if ( !Validate( _String ) ) { _Result = false; return false; }
			string str = _String.ToLower();
			if ( str == "0" || str == "f" || str == "false" ) {
				_Result = false; return true;
			} else if ( str == "1" || str == "t" || str == "true" ) {
				_Result = true; return true;
			} else {
				_Result = false; return false;
			}
		}

		public static bool TryParse( string _String, out int _Result, bool _Clamp = false, int _Min = 0, int _Max = 9999 ) {
			int value = -1;
			if ( !Validate( _String ) ) { _Result = value; return false; }
			string str = _String.ToLower();
			if ( !int.TryParse( str, out value ) ) { _Result = value; return false; }

			if( _Clamp ) {
				int min = HEVMath.Min( _Min, _Max );
				int max = HEVMath.Max( _Min, _Max );
				if ( min == max ) {
					value = max;
				} else {
					value = HEVMath.Clamp( value, min, max );
				}
			}
			_Result = value;
			return true;
			/* Sensitive
			if ( HEVMath.Validate( _Min, _Max, value ) ) {
				_Result = value;
				return true;
			} else {
				value = Math.Clamp( value, _Min, _Max );
				_Result = value;
				return false;
			}
			*/
		}

		public static bool TryParseHEV( this string _String, out bool _Result ) {
			return TryParse( _String, out _Result );
		}

		public static bool TryParseHEV( this string _String, out int _Result, bool _Clamp = false, int _Min = 0, int _Max = 9999 ) {
			return TryParse( _String, out _Result, _Clamp, _Min, _Max );
		}

		public static string ToString( List<string> _Array, string _Separator = "\r\n" ) { //\r\n
			if ( _Array.Count < 1 ) return null;
			string separator = ( _Separator == "" ? "\r\n" : _Separator );
			string result = string.Join( separator, _Array );
			return result;
		}

		public static string ToString( string[] _Array, string _Separator = "\r\n" ) { //\r\n
			if ( _Array.Length < 1 ) return null;
			string separator = ( _Separator == "" ? "\r\n" : _Separator );
			string result = string.Join( separator, _Array );
			return result;
		}

		public static string[] ToStringArray( string _String, string _Separator = ",", bool _ClearJumps = true ) {
			if ( !Validate( _String ) ) return null;
			string separator = (_Separator == "" ? "," : _Separator);
			string[] result = _String.Split( separator.ToCharArray() );
			if ( _ClearJumps ) {
				for ( int i = 0; i < result.Length; i++ ) {
					result[i] = result[i].Replace( "\n\r\t", "" ).Replace( "\r\n", "" ).Replace( "\r", "" ).Replace( "\n", "" );
				}
			}
			return result;
		}

		public static List<string> ToStringList( string _String, string _Separator = ",", bool _ClearJumps = true ) {
			if ( !Validate( _String ) ) return null;
			string[] result = _String.Split( _Separator.ToCharArray() );
			if( _ClearJumps ) {
				for ( int i = 0; i < result.Length; i++ ) {
					result[i] = result[i].Replace( "\n\r\t", "" ).Replace( "\r\n", "" ).Replace( "\r", "" ).Replace( "\n", "" );
				}
			}
			return result.ToList();
		}

		public static string ByteArrayToString( byte[] _ByteArray ) {
			return Encoding.UTF8.GetString( _ByteArray );
		}

		public static (string[], bool) GetStringArrayLines( string[] _String, int _StartLine = 0, int _EndLine = -1 ) {
			string[] lines = _String;
			int lastLine = 0;

			if ( lines.Length < 1 ) {
				HEVConsole.Print( "GetStringArrayLines() Empty string array.", EPrintType.eError );
				return (lines, false);
			}
			lastLine = lines.Length - 1;
			if ( _StartLine == 0 && _EndLine == -1 ) {
			} else if ( _StartLine == -1 ) {
				lines = new string[] { lines[lastLine] };
			} else {
				int startLine = HEVMath.Max( _StartLine, 0 );
				startLine = HEVMath.Min( startLine, lastLine );
				int endLine = HEVMath.Min( _EndLine, lastLine );
				endLine = HEVMath.Max( _StartLine, _EndLine );
				List<string> linesList = new List<string>();
				for ( int i = startLine; i < endLine; i++ ) {
					linesList.Add( lines[i] );
				}
				lines = linesList.ToArray();
			}
			return (lines, true);
		}

		/// <summary>Returns enum from string.</summary>
		public static (T, bool) EnumParse<T>( string _Value, T _DefaultValue, string _Suffix = "", string _Prefix = "e" ) 
			where T : struct, IConvertible {
			string value = _Prefix + _Value + _Suffix;
			if ( !typeof( T ).IsEnum ) throw new ArgumentException( "Error - " + value + " T must be an enumerated type." );
			if ( !Validate( value ) ) return (_DefaultValue, false);

			foreach ( T item in Enum.GetValues( typeof( T ) ) ) {
				if ( item.ToString().ToLower().Equals( value.Trim().ToLower() ) ) return (item, true);
			}
			return (_DefaultValue, false);
		}

		/// <summary>Returns hash MD5 from given string.</summary>
		public static string HashMD5( string _Input, bool _LowerCase = false ) {
			using ( MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider() ) {
				byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes( _Input );
				byte[] hash = md5.ComputeHash( inputBytes );

				StringBuilder sb = new StringBuilder();
				for ( int i = 0; i < hash.Length; i++ ) {
					// "x2" lower case, "X2" upper case
					sb.Append( hash[i].ToString( ( _LowerCase ? "x2" : "X2" ) ) );
				}
				return sb.ToString();
			}
		}

		/// <summary>Returns hash SHA1 from given string.</summary>
		public static string HashSHA1( string _Input, bool _LowerCase = false ) {
			using ( SHA1Managed sha1 = new SHA1Managed() ) {
				byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes( _Input );
				byte[] hash = sha1.ComputeHash( inputBytes );

				StringBuilder sb = new StringBuilder( hash.Length * 2 );
				foreach ( byte b in hash ) {
					// "x2" lower case, "X2" upper case
					sb.Append( b.ToString( ( _LowerCase ? "x2" : "X2" ) ) );
				}
				return sb.ToString();
			}
		}

		/// <summary>Returns hash SHA256 from given string.</summary>
		public static string HashSHA256( string _Input, bool _LowerCase = false ) {
			using ( SHA256Managed sha256 = new SHA256Managed() ) {
				byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes( _Input );
				byte[] hash = sha256.ComputeHash( inputBytes );

				StringBuilder sb = new StringBuilder( hash.Length * 2 );
				foreach ( byte b in hash ) {
					// "x2" lower case, "X2" upper case
					sb.Append( b.ToString( ( _LowerCase ? "x2" : "X2" ) ) );
				}
				return sb.ToString();
			}
		}
	}
}
