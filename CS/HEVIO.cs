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
HEVIO.cs
================================================
*/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
#endif

namespace HevLib {
	public static class HEVIO {

		public static bool FileValidate( string _URL ) {
			if ( !System.IO.File.Exists( _URL ) ) {
				HEVConsole.Print( "FileValidate() Missing File.", EPrintType.eError );
				return false;
			} else {
				return true;
			}
		}

		public static (string, bool) FileTextRead( string _URL ) {
			if ( !FileValidate( _URL ) ) {
				return ("Missing", false);
			}
			string text = System.IO.File.ReadAllText( _URL );
			if ( HEVText.StringValidate( text ) ) {
				HEVConsole.Print( "FileTextLoad() Empty File.", EPrintType.eWarning );
				return ("Empty", true);
			}
			return (text, true);
		}

		public static (string, bool) FileTextReadToString( string _URL ) {
			if ( HEVText.StringValidate( _URL ) ) { HEVConsole.Print( "FileTextReadToString() Invalid URL.", EPrintType.eError ); return (null, false); }
			string data = null;
			string fileURL = null;
			bool status = false;
			fileURL = _URL;
			if ( !FileValidate( fileURL ) ) {
				return (null, false);
			}
			(data, status) = FileTextRead( fileURL );
			if ( !status ) {
				HEVConsole.Print( "FileTextReadToString() Invalid File.", EPrintType.eError );
				return (null, false);
			} else {
				return (data, true);
			}
		}

		public static bool JsonTryParse<T>( this string _String, out T _Result ) {
			bool status = true;
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				Error = ( sender, args ) => { status = false; args.ErrorContext.Handled = true; },
				MissingMemberHandling = MissingMemberHandling.Error
			};
			_Result = JsonConvert.DeserializeObject<T>( _String, settings );
			return status;
		}

		public static (T, bool) FileJSONRead<T>( string _URL ) where T : class, new() {
			if ( !typeof( T ).IsClass ) throw new ArgumentException( "Error - " + _URL + " must have a valid class." );
			T localClass = new T();
			string fileText = "";
			bool status = false;
			(fileText, status) = FileTextRead( _URL );
			if ( !status ) { HEVConsole.Print( "FileJSONRead() Missing File.", EPrintType.eError ); return (localClass, false); }

			bool isValidObject = fileText.JsonTryParse<T>( out localClass );
			if ( isValidObject ) {
				return (localClass, true);
			} else {
				return (localClass, false);
			}
		}

		public static (List<T>, bool) FileJSONReadList<T>( string _URL ) where T : class, new() {
			if ( !typeof( T ).IsClass ) throw new ArgumentException( "Error - " + _URL + " must have a valid class." );
			List<T> localClass = new List<T>();
			string fileText = "";
			bool status = false;
			(fileText, status) = FileTextRead( _URL );
			if ( !status ) { HEVConsole.Print( "FileJSONReadList() Missing File.", EPrintType.eError ); return (localClass, false); }

			bool isValidObject = fileText.JsonTryParse<List<T>>( out localClass );
			if ( isValidObject ) {
				return (localClass, true);
			} else {
				return (localClass, false);
			}
		}

		public static (T, bool) EnumParse<T>( string _Value, T _DefaultValue, string _Suffix = "", string _Prefix = "e" ) where T : struct, IConvertible {
			string value = _Prefix + _Value + _Suffix;
			if ( !typeof( T ).IsEnum ) throw new ArgumentException( "Error - " + value + " T must be an enumerated type." );
			if ( HEVText.StringValidate( value ) ) return (_DefaultValue, false);

			foreach ( T item in Enum.GetValues( typeof( T ) ) ) {
				if ( item.ToString().ToLower().Equals( value.Trim().ToLower() ) ) return (item, true);
			}
			return (_DefaultValue, false);
		}
	}
}
