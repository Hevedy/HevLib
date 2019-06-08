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
using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
using System.Linq;
#endif

namespace HevLib {

	public static class HEVIO {

		public static (T, bool) EnumParse<T>( string _Value, T _DefaultValue, string _Suffix = "", string _Prefix = "e" ) where T : struct, IConvertible {
			string value = _Prefix + _Value + _Suffix;
			if ( !typeof( T ).IsEnum ) throw new ArgumentException( "Error - " + value + " T must be an enumerated type." );
			if ( HEVText.StringValidate( value ) ) return (_DefaultValue, false);

			foreach ( T item in Enum.GetValues( typeof( T ) ) ) {
				if ( item.ToString().ToLower().Equals( value.Trim().ToLower() ) ) return (item, true);
			}
			return (_DefaultValue, false);
		}

		public static bool FileValidate( string _URL ) {
			if ( !System.IO.File.Exists( _URL ) ) {
				HEVConsole.Print( "FileValidate() Missing File." + _URL, EPrintType.eError );
				return false;
			} else {
				return true;
			}
		}

		public static (string[], bool) FileTextRead( string _URL, int _StartLine = 0, int _EndLine = -1 ) {
			string[] lines = null;
			int lastLine = 0;
			if ( !FileValidate( _URL ) ) {
				lines = new string[] { "Missing File" };
				return (lines, false);
			}
			if ( HEVText.StringValidate( System.IO.File.ReadAllText( _URL ) ) ) {
				HEVConsole.Print( "FileTextRead() Empty File." + _URL, EPrintType.eWarning );
				lines = new string[] { "Empty" };
				return (lines, false);
			}
			lines = System.IO.File.ReadAllLines( _URL );
			lastLine = lines.Length - 1;
			if ( _StartLine == 0 && _EndLine == -1 ) {
			} else if ( _StartLine == -1 && _EndLine == -1 ) {
				lines = new string[] { lines[lastLine] };
			} else {
				int startLine = Math.Max( _StartLine, 0 );
				startLine = Math.Min( startLine, lastLine );
				int endLine = Math.Min( _EndLine, lastLine );
				endLine = Math.Max( _StartLine, _EndLine );
				List<string> linesList = new List<string>();
				for ( int i = startLine; i < endLine; i++ ) {
					linesList.Add( lines[i] );
				}
				lines = linesList.ToArray();
			}
			return (lines, true);
		}

		// URL, Line Index if -1 whole doc
		// Double check possible bug at get from line count
		public static bool FileTextWrite( string _URL, string[] _Text, int _LineIndex = -1, bool _Replace = true ) {
			if ( !FileValidate( _URL ) ) {
				HEVConsole.Print( "FileTextWrite() Missing File. Creating new one..." + _URL, EPrintType.eWarning );
			}
			bool status = true;
			string[] linesPre = null;
			string[] linesPost = null;
			string[] linesFinal = null;
			(linesPre, status) = FileTextRead( _URL, 0, _LineIndex );
			(linesPost, status) = FileTextRead( _URL, _LineIndex, -1 );
			try {
				if ( status == false ) {
					linesFinal = _Text;
					System.IO.File.WriteAllLines( _URL, linesFinal, System.Text.Encoding.Unicode );
					status = true;
				} else if ( _LineIndex == 0 ) {
					if ( _Replace ) {
						linesFinal = _Text;
					} else {
						linesFinal = _Text.Concat( linesPost ).ToArray();
					}
					System.IO.File.WriteAllLines( _URL, linesFinal, System.Text.Encoding.Unicode );
					status = true;
				} else if ( _LineIndex == -1 ) {
					if ( _Replace ) {
						linesFinal = linesPre.Concat( _Text ).ToArray();
					} else {
						linesFinal = linesPre.Concat( _Text ).Concat( linesPost ).ToArray();
					}
					linesFinal = linesPre.Concat( _Text ).ToArray();
					System.IO.File.WriteAllLines( _URL, linesFinal, System.Text.Encoding.Unicode );
					status = true;
				}  else {
					if ( _Replace ) {
						linesFinal = linesPre.Concat( _Text ).ToArray();
					} else {
						linesFinal = linesPre.Concat( _Text ).Concat( linesPost ).ToArray();
					}
					System.IO.File.WriteAllLines( _URL, linesFinal, System.Text.Encoding.Unicode );
					status = true;
				}
			} catch {
				status = false;
			}
			if ( !status ) {
				HEVConsole.Print( "FileTextWrite() Error at write." + _URL, EPrintType.eError );
				return false;
			} else {
				return true;
			}
		}

		public static (string[], bool) FileTextReadToString( string _URL ) {
			if ( HEVText.StringValidate( _URL ) ) { HEVConsole.Print( "FileTextReadToString() Invalid URL." + _URL, EPrintType.eError ); return (null, false); }
			string[] data = null;
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
			string[] fileLines = null;
			bool status = false;
			(fileLines, status) = FileTextRead( _URL );
			fileText = HEVText.StringArrayToString( fileLines );
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
			string[] fileLines = null;
			bool status = false;
			(fileLines, status) = FileTextRead( _URL );
			fileText = HEVText.StringArrayToString( fileLines );
			if ( !status ) { HEVConsole.Print( "FileJSONReadList() Missing File.", EPrintType.eError ); return (localClass, false); }

			bool isValidObject = fileText.JsonTryParse<List<T>>( out localClass );
			if ( isValidObject ) {
				return (localClass, true);
			} else {
				return (localClass, false);
			}
		}

		public static (IniData, bool) FileINIRead( string _URL ) {
			bool status = FileValidate( _URL );
			if ( !status ) { HEVConsole.Print( "FileINIRead() Missing File.", EPrintType.eError ); return (null, false); }

			FileIniDataParser parser = new FileIniDataParser();
			IniData data = null;
			try {
				data = parser.ReadFile( _URL );
				status = true;
			} catch {
				status = false;
			}
			if ( !status ) { HEVConsole.Print( "FileINIRead() File Error.", EPrintType.eError ); return (null,false); }
			return (data, true);
		}

		public static bool FileINIWrite( string _URL, IniData _Data ) {
			bool status = FileValidate( _URL );
			if ( !status ) { HEVConsole.Print( "FileINIWrite() Missing File. Creating one...", EPrintType.eWarning ); return false; }

			FileIniDataParser parser = new FileIniDataParser();
			IniData data = _Data;
			try {
				parser.WriteFile( _URL, data );
				status = true;
			} catch {
				status = false;
			}
			if ( !status ) { HEVConsole.Print( "FileINIWrite() Write File Error.", EPrintType.eError ); return false; }
			return true;
		}

	}
}
