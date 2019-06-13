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
HEVHelper.cs
================================================
*/

using System;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.IO;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
using System.Linq;
#endif

namespace HevLib {
	class HEVHelper {
		public static readonly string AppDir = Environment.CurrentDirectory;
		public static readonly string AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
		public static readonly string AppNameFull = System.Reflection.Assembly.GetExecutingAssembly().GetName().FullName;
		public static readonly string AppDirFile = System.Reflection.Assembly.GetEntryAssembly().Location;
		public static readonly string AppDirDocuments = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
		public static readonly bool AppIsDLL = HEVIO.FileIsLibrary(AppDirFile);

		public static bool AppSelfString( out string _String ) {
			byte[] bytes = null;
			bool status = false;
			(bytes, status) = HEVIO.FileBytesRead( AppDirFile );
			if ( !status ) { _String = "Error"; return false; }
			_String =  HEVText.ByteArrayToString( bytes );
			return true;
		}

		public static string AppFileHashMD5() {
			string code = "";
			if ( !AppSelfString( out code ) ) { return code; }
			return HEVText.HashMD5( code );
		}

		public static string AppFileHashSHA1() {
			string code = "";
			if ( !AppSelfString( out code ) ) { return code; }
			return HEVText.HashMD5( code );
		}

		public static string AppFileHashSHA256() {
			string code = "";
			if ( !AppSelfString( out code ) ) { return code; }
			return HEVText.HashMD5( code );
		}
	}

	class HEVInstanceHelper : IDisposable {
		public bool hasHandle = false;
		Mutex mutex;

		private void InitMutex( string _CustomID ) {
			//( (GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( GuidAttribute ), false ).GetValue( 0 ) ).Value;
			string appGuid = HEVIO.AssemblyGuidCurrent();
			string mutexId = string.Format( "Global\\{{{0}}}", appGuid );
			if ( HEVText.StringValidate(_CustomID) ) {
				mutexId = _CustomID;
			}
			mutex = new Mutex( false, mutexId );

			var allowEveryoneRule = new MutexAccessRule( new SecurityIdentifier( WellKnownSidType.WorldSid, null ), MutexRights.FullControl, AccessControlType.Allow );
			var securitySettings = new MutexSecurity();
			securitySettings.AddAccessRule( allowEveryoneRule );
			mutex.SetAccessControl( securitySettings );
		}

		public HEVInstanceHelper( int _TimeOut, string _CustomID = "" ) {
			InitMutex( _CustomID );
			try {
				if ( _TimeOut < 0 ) {
					hasHandle = mutex.WaitOne( Timeout.Infinite, false );
				} else if ( _TimeOut == 0 ) {
					hasHandle = mutex.WaitOne( TimeSpan.Zero, false );
				} else {
					hasHandle = mutex.WaitOne( _TimeOut, false );
				}

				if ( hasHandle == false )
					throw new TimeoutException( "Timeout waiting for exclusive access on SingleInstance" );
			} catch ( AbandonedMutexException ) {
				hasHandle = true;
			}
		}

		public void Dispose() {
			if ( mutex != null ) {
				if ( hasHandle )
					mutex.ReleaseMutex();
				mutex.Close();
			}
		}
	}
}
