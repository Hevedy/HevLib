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
HEVLib.Build.cs
================================================
*/


using UnrealBuildTool;
using System.IO;

public class HEVLib : ModuleRules
{
	public HEVLib(ReadOnlyTargetRules Target) : base(Target)
	{
		
		//bEnforceIWYU = false;
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicIncludePaths.Add( Path.Combine( ModuleDirectory, "Public" ) );
        PrivateIncludePaths.Add( Path.Combine( ModuleDirectory, "Private" ) );

        PublicDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add other public dependencies that you statically link with here ...
				"Core",
				"CoreUObject",
				"Engine",
				"InputCore"
			}
			);

		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"RHI",
				"RenderCore",
				"HTTP",
				"UMG", "Slate", "SlateCore",
				"ImageWrapper"
				// ... add private dependencies that you statically link with here ...
			}
			);

		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);
	}
}
