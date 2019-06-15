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
using System.IO;
using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Reflection;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
using System.Linq;
#endif

namespace HEVLib {

	public static class HEVIO {

		public static bool FileValidate( string _URL, bool _Critical = true ) {
			if ( !System.IO.File.Exists( _URL ) ) {
				EPrintType val;
				if ( _Critical ) { val = EPrintType.eError; } else { val = EPrintType.eWarning; }
				HEVConsole.Print( "FileValidate() Missing file: " + _URL, val );
				return false;
			} else {
				return true;
			}
		}

		public static bool FileIsExecutable( string _URL ) {
			string ext = Path.GetExtension( _URL );
			if ( ext == ".exe" || ext == ".com" || ext == ".bat" || ext == ".msi" || ext == ".sh" || ext == ".deb" || 
				ext == ".elf" || ext == ".bin" || ext == ".rpm" || ext == ".py" ) {
				return false;
			} else {
				return true;
			}
		}

		public static bool FileIsLibrary( string _URL ) {
			string ext = Path.GetExtension( _URL );
			if ( ext == ".dll" || ext == ".dll.lib" || ext == ".ocx" || ext == ".so" || ext == ".o" || ext == ".dylib" || 
				ext == ".bundle" ) {
				return true;
			} else {
				return false;
			}
		}

		public static bool FileIsPackage( string _URL ) {
			string ext = Path.GetExtension( _URL );
			if ( ext == ".zip" || ext == ".rar" || ext == ".7zip" || ext == ".tar.gz" || ext == ".tar" || ext == ".gz" || 
				ext == ".bz2" || ext == ".wim" || ext == ".xz" || ext == ".iso" || ext == ".gzip" || ext == ".bzip2" ) {
				return true;
			} else {
				return false;
			}
		}

		public static (byte[], bool) FileBytesRead( string _URL ) {
			byte[] data = null;
			bool status = false;
			if ( !FileValidate( _URL ) ) {
				return (data, status);
			} else {
				status = true;
			}
			FileStream running = File.OpenRead( _URL );

			byte[] dataS = new byte[running.Length];
			running.Read( dataS, 0, dataS.Length );
			running.Close();
			data = dataS;
			return (data, status);
		}

		public static string AssemblyGuidCurrent() {
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			Object[] attributes = assembly.GetCustomAttributes( typeof( GuidAttribute ), false );
			if ( attributes.Any() ) { return ( (GuidAttribute)attributes.First() ).Value; }
			return "";
		}

		public static (string, bool) AssemblyStringRead( string _URL, Assembly _Assembly = null, bool _Self = true ) {
			string data = "";
			string url = _URL;
			Assembly assem = Assembly.GetEntryAssembly();
			if( _Self || _Assembly == null ) {
				assem = Assembly.GetEntryAssembly();
				//url = HEVProgram.Name + "." + url; Gets Exe name but no assembly
				url = HEVProgram.Namespace + "." + url;
			} else {
				assem = _Assembly;
			}
#if !HEVSAFE
			return (data, false);
#else
			Stream stream = assem.GetManifestResourceStream( url );
			using ( StreamReader reader = new StreamReader( stream ) ) {
				data = reader.ReadToEnd();
			}
			return (data, true);
#endif
		}

		public static bool ResourcesTextReadString( string _URL, out string _String ) {
			bool status = false;
#if HEVSAFE
			(_String,status) = AssemblyStringRead( _URL );
#endif
			return status;
		}

		public static bool ResourcesTextReadStringArray( string _URL, out string[] _Strings, int _StartLine = 0, 
			int _EndLine = -1 ) {
			string[] lines = null;
			string data = "";
			bool status = false;
#if HEVSAFE
			(data, status) = AssemblyStringRead( _URL );
#endif
			if ( !status ) { _Strings = lines; return false; }
			lines = HEVText.StringToStringArray( data, "\n" );

			(lines, status) = HEVText.GetStringArrayLines( lines, _StartLine, _EndLine );
			if ( !status ) { _Strings = lines; return false; }
			_Strings = lines;
			return true;
		}

		public static (string, bool) FileTextReadString( string _URL ) {
			string[] fileLines = null;
			bool status = false;
			(fileLines, status) = FileTextReadStringArray( _URL );
			return (HEVText.StringArrayToString( fileLines ), true);
		}

		public static (string[], bool) FileTextReadStringArray( string _URL, int _StartLine = 0, int _EndLine = -1 ) {
			string[] lines = null;
			bool status = false;
			if ( !FileValidate( _URL ) ) {
				return (lines, false);
			}
			if ( !HEVText.StringValidate( System.IO.File.ReadAllText( _URL ) ) ) {
				HEVConsole.Print( "FileTextRead() Invalid URL " + _URL, EPrintType.eWarning );
				lines = new string[] { "Empty" };
				return (lines, false);
			}
			lines = System.IO.File.ReadAllLines( _URL );

			(lines, status) = HEVText.GetStringArrayLines( lines, _StartLine, _EndLine );
			if ( !status ) { return (lines, false); }
			return (lines, true);
		}


		public static bool FileTextWriteString( string _URL, string _Text, bool _Replace = true ) {
			string[] fileLines = HEVText.StringToStringArray(_Text, "\n"); //\r\n Count as double
			return FileTextWriteStringArray( _URL, fileLines, _Replace );
		}  

		public static bool FileTextWriteStringArray( string _URL, string[] _Text, bool _Replace = true, 
			int _LineIndex = -1 ) {
			bool file = true;
			if ( !FileValidate( _URL, false ) ) {
				HEVConsole.Print( "FileTextWriteStringArray() Missing file. Creating new one at " + 
					_URL, EPrintType.eWarning );
				file = false;
			}
			bool status = false;
			string[] linesPre = null;
			string[] linesPost = null;
			string[] linesFinal = null;

			if ( file ) {
				(linesPre, status) = FileTextReadStringArray( _URL );
				if ( !status ) { return false; }
				(linesPost, status) = HEVText.GetStringArrayLines( linesPre, _LineIndex, -1 );
				(linesPre, status) = HEVText.GetStringArrayLines( linesPre, 0, _LineIndex );
			}

			if ( status == false ) {
				linesFinal = _Text;
			} else if ( _LineIndex == 0 ) {
				if ( _Replace ) {
					linesFinal = _Text;
				} else {
					linesFinal = _Text.Concat( linesPost ).ToArray();
				}
			} else if ( _LineIndex == -1 ) {
				if ( _Replace ) {
					linesFinal = linesPre.Concat( _Text ).ToArray();
				} else {
					linesFinal = linesPre.Concat( _Text ).Concat( linesPost ).ToArray();
				}
			} else {
				if ( _Replace ) {
					linesFinal = linesPre.Concat( _Text ).ToArray();
				} else {
					linesFinal = linesPre.Concat( _Text ).Concat( linesPost ).ToArray();
				}
			}

			try {
				if ( !file ) {
					string dir = System.IO.Path.GetDirectoryName( _URL );
					HEVConsole.Print( dir, EPrintType.eInfo);
					if ( !System.IO.Directory.Exists( dir ) ) {
						DirectoryInfo di = System.IO.Directory.CreateDirectory( dir );
						if ( !di.Exists ) {
							HEVConsole.Print( "Administrator privileges are need in order to create the files.", 
								EPrintType.eError );
							return false;
						}
					}
					//System.IO.File.CreateText( _URL );
				} 
				System.IO.File.WriteAllLines( _URL, linesFinal, System.Text.Encoding.UTF8 );
				status = true;
			} catch {
				status = false;
			}
			if ( !status ) {
				HEVConsole.Print( "FileTextWriteStringArray() At write." + _URL, EPrintType.eError );
				return false;
			} else {
				return true;
			}
		}

		public static bool JSONParseClassTry<T>( this string _String, out T _Result ) {
			bool status = true;
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				Error = ( sender, args ) => { status = false; args.ErrorContext.Handled = true; },
				MissingMemberHandling = MissingMemberHandling.Error
			};
			_Result = JsonConvert.DeserializeObject<T>( _String, settings );
			if ( !status ) HEVConsole.Print( "JSONParseClassTry().", EPrintType.eError );

			return status;
		}

		public static (T, bool) JSONReadClass<T>( string _String ) where T : class, new() {
			if ( !typeof( T ).IsClass ) throw new ArgumentException( "Error - JSONReadClass() must have a valid class." );
			T localClass = new T();
			string fileText = _String;
			bool status = false;

			if ( !HEVText.StringValidate( _String ) ) {
				HEVConsole.Print( "JSONReadClass() Empty string.", EPrintType.eWarning);
				return (localClass, false);
			}
			status = fileText.JSONParseClassTry<T>( out localClass );
			return (localClass, status);
		}

		public static (List<T>, bool) JSONReadClassList<T>( string _String ) where T : class, new() {
			if ( !typeof( T ).IsClass ) throw new ArgumentException( "Error - JSONReadClassList() must have a valid class." );
			List<T> localClass = new List<T>();
			string fileText = _String;
			bool status = false;

			if ( !HEVText.StringValidate( _String ) ) {
				HEVConsole.Print( "JSONReadClassList() Empty string.", EPrintType.eWarning );
				return (localClass, false);
			}
			status = fileText.JSONParseClassTry<List<T>>( out localClass );
			return (localClass, status);
		}

		public static (T, bool) FileJSONReadClass<T>( string _URL ) where T : class, new() {
			if ( !typeof( T ).IsClass ) throw new ArgumentException( "Error - FileJSONReadClass() " + _URL + 
				" must have a valid class." );
			T localClass = new T();
			string fileText = "";
			bool status = false;
			(fileText, status) = FileTextReadString( _URL );
			if ( !status ) {
				HEVConsole.Print( "FileJSONReadClass() Missing File at " + _URL, EPrintType.eError );
				return (localClass, false);
			}

			(localClass, status) = JSONReadClass<T>( fileText );
			return (localClass, status);
		}

		public static (List<T>, bool) FileJSONReadClassList<T>( string _URL ) where T : class, new() {
			if ( !typeof( T ).IsClass ) throw new ArgumentException( "Error - FileJSONReadClassList() " + _URL + 
				" must have a valid class." );
			List<T> localClass = new List<T>();
			string fileText = "";
			bool status = false;
			(fileText, status) = FileTextReadString( _URL );
			if ( !status ) {
				HEVConsole.Print( "FileJSONReadClassList() Missing file at " + _URL, EPrintType.eError );
				return (localClass, false);
			}

			(localClass, status) = JSONReadClassList<T>( fileText );
			return (localClass, status);
		}

		public static (IniData, bool) INIRead( string _String ) {
			if ( !HEVText.StringValidate( _String ) ) {
				HEVConsole.Print( "INIRead() Empty string.", EPrintType.eError );
				return (null, false);
			}
			bool status = false;
			FileIniDataParser parser = new FileIniDataParser();
			parser.Parser.Configuration.ThrowExceptionsOnError = true;
			IniData data = null;

			try {
				data = parser.Parser.Parse( _String );
				status = true;
			} catch {
				status = false;
			}
			if ( !status ) {
				HEVConsole.Print( "INIRead() Parser to data.", EPrintType.eError );
				return (null, false);
			}
			return (data, true);
		}

		public static (string, bool) INIWrite( IniData _Data ) {
			bool status = false;
			string data = "";
			if ( _Data != null ) {
				HEVConsole.Print( "INIWrite() Empty data.", EPrintType.eError );
				return (null, false);
			}

			try {
				data = _Data.ToString();
				status = true;
			} catch {
				status = false;
			}
			if ( !status ) {
				HEVConsole.Print( "INIWrite() Parser to string.", EPrintType.eError );
				return (null,false);
			}
			return (data, true);
		}

		public static (IniData, bool) FileINIRead( string _URL ) {
			bool status = FileValidate( _URL );
			if ( !status ) {
				HEVConsole.Print( "FileINIRead() Missing file at " + _URL, EPrintType.eError );
				return (null, false);
			}

			FileIniDataParser parser = new FileIniDataParser();
			parser.Parser.Configuration.ThrowExceptionsOnError = true;
			IniData data = null;
			try {
				data = parser.ReadFile( _URL );
				status = true;
			} catch {
				status = false;
			}
			if ( !status ) {
				HEVConsole.Print( "FileINIRead() Parser file read.", EPrintType.eError );
				return (null,false);
			}
			return (data, true);
		}

		public static bool FileINIWrite( string _URL, IniData _Data ) {
			bool status = FileValidate( _URL );
			if ( !status ) {
				HEVConsole.Print( "FileINIWrite() Missing file. Creating one at " + _URL, EPrintType.eWarning );
				return false;
			}

			FileIniDataParser parser = new FileIniDataParser();
			parser.Parser.Configuration.ThrowExceptionsOnError = true;
			IniData data = _Data;
			try {
				parser.WriteFile( _URL, data, Encoding.UTF8 );
				status = true;
			} catch {
				status = false;
			}
			if ( !status ) {
				HEVConsole.Print( "FileINIWrite() Parser file write.", EPrintType.eError );
				return false;
			}
			return true;
		}

		// Returns false if need to save the file
		public static bool DataINIReadWrite( this IniData _Data, string _Section, string _Key, ref bool _Value ) {
			IniData data = _Data;
			bool status = false;
			bool value = _Value;
			if ( !HEVText.TryParse( data[_Section][_Key], out value ) ) {
				value = _Value;
				data[_Section][_Key] = value.ToString();
				status = false;
			} else {
				status = true;
			}
			_Data = data;
			_Value = value;
			return status;
		}

		public static bool DataINIReadWrite( this IniData _Data, string _Section, string _Key, ref int _Value, bool _Clamp = false, int _Min = 0, int _Max = 9999 ) {
			IniData data = _Data;
			bool status = false;
			int value = _Value;
			if ( !HEVText.TryParse( data[_Section][_Key], out value, false ) ) {
				value = _Value;
				if ( _Clamp ) {
					value = Math.Clamp( value, _Min, _Max );
				}
				data[_Section][_Key] = value.ToString();
				status = false;
			} else {
				if ( HEVMath.Validate( _Min, _Max, value ) ) {
					status = true;
				} else {
					if ( _Clamp ) {
						value = Math.Clamp( value, _Min, _Max );
						status = false;
					} else {
						status = true;
					}
				}
			}
			_Data = data;
			_Value = value;
			return status;
		}

		public static bool DataINIReadWrite( this IniData _Data, string _Section, string _Key, ref string _Value ) {
			IniData data = _Data;
			bool status = false;
			string value = _Value;
			if ( !HEVText.StringValidate( data[_Section][_Key] ) ) {
				data[_Section][_Key] = _Value;
				status = false;
			} else {
				status = true;
			}
			_Data = data;
			_Value = value;
			return status;
		}
	}
}
