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
HEVLibIO.h
================================================
*/


#pragma once

#include "CoreMinimal.h"
#include "Engine.h"
#include "Engine/Engine.h"
#include "HEVLibraryMath.h"

#include "DDSLoader.h"
#include "ImageUtils.h"
#include "IImageWrapper.h"
#include "IImageWrapperModule.h"
#include "Runtime/Core/Public/HAL/FileManager.h"
#include "Runtime/Core/Public/Templates/SharedPointer.h"

#include "HEVLibIO.generated.h"


UENUM()
enum class EHEVINIFilesList : uint8 {
	GGameIni 				UMETA( DisplayName = "Game" ),
	GGameUserSettingsIni	UMETA( DisplayName = "User Settings" ),
	GScalabilityIni			UMETA( DisplayName = "Scalability" ),
	GInputIni				UMETA( DisplayName = "Input" ),
	GEngineIni				UMETA( DisplayName = "Engine" ),
	GameSettingsConfig		UMETA( DisplayName = "Game Settings" ),
	PlayerSettingsConfig	UMETA( DisplayName = "Player Settings" )
};

UCLASS()
class HEVLIBRARY_API UHEVLibraryFiles : public UBlueprintFunctionLibrary {
	GENERATED_BODY()

	UHEVLibraryFiles( const FObjectInitializer& ObjectInitializer );
private:

protected:

public:

	/** Returns the value of the selected bool from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static bool GetConfigBool( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected uint8 from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static uint8 GetConfigByte( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected int32 from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static int32 GetConfigInteger( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected float from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static float GetConfigFloat( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected FVector2D from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static FVector2D GetConfigVector2D( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected FVector from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static FVector GetConfigVector( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected FVector from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static FVector4 GetConfigVector4( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected FRotator from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static FRotator GetConfigRotator( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected FLinearColor from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static FLinearColor GetConfigColor( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected FString from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static FString GetConfigString( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Returns the value of the selected FText from the selected ini config file */
	UFUNCTION( BlueprintPure, Category = "HevLib|IO" )
		static FText GetConfigText( const FString SectionName, const FString VariableName, const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError );

	/** Set the value of the selected bool from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigBool( const FString SectionName, const FString VariableName, const bool BoolValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected uint8 from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigByte( const FString SectionName, const FString VariableName, const uint8 ByteValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected int32 from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigInteger( const FString SectionName, const FString VariableName, const int32 IntValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected float from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigFloat( const FString SectionName, const FString VariableName, const float FloatValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected FVector2D from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigVector2D( const FString SectionName, const FString VariableName, const FVector2D Vec2Value, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected FVector from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigVector( const FString SectionName, const FString VariableName, const FVector VecValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected FVector from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigVector4( const FString SectionName, const FString VariableName, const FVector4 &Vec4Value, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected FRotator from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigRotator( const FString SectionName, const FString VariableName, const FRotator RotValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected FLinearColor from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigColor( const FString SectionName, const FString VariableName, const FLinearColor ColorValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected FString from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigString( const FString SectionName, const FString VariableName, const FString StrValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

	/** Set the value of the selected FText from the selected ini config file */
	UFUNCTION( BlueprintCallable, Category = "HevLib|IO" )
		static void SetConfigText( const FString SectionName, const FString VariableName, const FText TextValue, const EHEVINIFilesList INIFile, const int32 ProfileIndex );

};