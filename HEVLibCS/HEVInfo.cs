using System;

namespace HEVLib {
	class HEVInfo {
		// You must set here you project default namespace if is different from build one otherwise expect crashes.
		// After define this make sure you add "HEVSAFE" to the compiler in order to unlock unsafe parts.
		public static readonly string CUSTOM_NAMESPACE = ""; //EDIT THIS

		public static readonly string Name = "HevLib";
		public static readonly string Author = @"David ""Hevedy"" Palacios";
		public static readonly int VersionMajor = 0;
		public static readonly int VersionMinor = 5;
		public static readonly int VersionPatch = 2;
		public static readonly string Version = VersionMajor + "." + VersionMinor + "." + VersionPatch;
		public static readonly string Info = Name + " by " + Author + " - Version: " + Version;
	}
}
