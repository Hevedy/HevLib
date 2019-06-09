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
HEVLibRandom.h
================================================
*/


#pragma once

#include "CoreMinimal.h"
#include "Engine.h"
#include "Engine/Engine.h"
#include "HEVLibRandom.generated.h"

UCLASS()
class HEVLIBRARY_API UHEVLibRandom : public UBlueprintFunctionLibrary {
	GENERATED_BODY()

	UHEVLibraryRandom( const FObjectInitializer& ObjectInitializer );
private:

protected:

public:

	/** Returns a bool value using the Uniform method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Bool (Uniform)" ), Category = "HevLib|Random" )
		static bool RandomBool_Uniform();

	/** Returns a bool value using the Bernoulli method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Bool (Bernoulli)" ), Category = "HevLib|Random" )
		static bool RandomBool_Bernoulli( const float Bias = 0.5f );

	/** Returns a bool value using the Bernoulli Twister method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Bool (Mersenne Twister)" ), Category = "HevLib|Random" )
		static bool RandomBool_MersenneTwister( const float Bias = 0.5f );

	/** Returns a uint8 in the range 0 to X value using the Uniform method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Byte (Uniform)" ), Category = "HevLib|Random" )
		static uint8 RandomByte_Uniform( const uint8 Max );

	/** Returns a uint8 in the range 0 to 1 value using the Bernoulli method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Byte (Bernoulli)" ), Category = "HevLib|Random" )
		static uint8 RandomByte_Bernoulli( const float Bias = 0.5f );

	/** Returns a uint8 in the range 0 to 1 value using the Bernoulli Twister method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Byte (Mersenne Twister)" ), Category = "HevLib|Random" )
		static uint8 RandomByte_MersenneTwister( const float Bias = 0.5f );

	/** Returns a int32 in the range 0 to X value using the Uniform method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Integer (Uniform)" ), Category = "HevLib|Random" )
		static int32 RandomInt_Uniform( const int32 Max );

	/** Returns a int32 in the range 0 to 1 value using the Bernoulli method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Integer (Bernoulli)" ), Category = "HevLib|Random" )
		static int32 RandomInt_Bernoulli( const float Bias = 0.5f );

	/** Returns a int32 in the range 0 to 1 value using the Bernoulli Twister method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Integer (Mersenne Twister)" ), Category = "HevLib|Random" )
		static int32 RandomInt_MersenneTwister( const float Bias = 0.5f );

	/** Returns a float in the range 0.0 to X.X value using the Uniform method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Float (Uniform)" ), Category = "HevLib|Random" )
		static float RandomFloat_Uniform( const float Max );

	/** Returns a float in the range 0.0 to 1.0 value using the Canonical method */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Random Float (Canonical)" ), Category = "HevLib|Random" )
		static float RandomFloat_Canonical();

};