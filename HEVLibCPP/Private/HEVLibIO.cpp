/*
===========================================================================
This code is part of the HevLib source code content in
HevLib by Hevedy <https://github.com/Hevedy/HevLib>
Mozilla Public License Version 2.0 (MPL-2.0)
Copyright (c) 2018-2020 Hevedy <https://github.com/Hevedy>
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
HEVLibIO.cpp
================================================
*/


#include "HEVLibIO.h"
#include "HEVLibPrivatePCH.h"
#include "HEVLibMath.h"


UHEVLibIO::UHEVLibIO( const class FObjectInitializer& ObjectInitializer ) {

}

static FDateTime GetFileTimeStamp( const FString& File ) {
	return FPlatformFileManager::Get().GetPlatformFile().GetTimeStamp( *File );
}
static void SetTimeStamp( const FString& File, const FDateTime& TimeStamp ) {
	FPlatformFileManager::Get().GetPlatformFile().SetTimeStamp( *File, TimeStamp );
}

static bool FileExists( const FString& File ) {
	return FPlatformFileManager::Get().GetPlatformFile().FileExists( *File );
}
static bool FolderExists( const FString& Dir ) {
	return FPlatformFileManager::Get().GetPlatformFile().DirectoryExists( *Dir );
}

bool UHEVLibIO::GetConfigBool( const FString SectionName, const FString VariableName, 
									  const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return false;

	bool value = false;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->GetBool( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->GetBool( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->GetBool( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->GetBool( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->GetBool( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->GetBool( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			GConfig->GetBool( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return value;
}

uint8 UHEVLibIO::GetConfigByte( const FString SectionName, const FString VariableName, 
									   const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return 0;

	// PR GetByte
	int32 value = 0;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetInt( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetInt( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return ( value < 0 ) ? 0 : ( value > sizeof( uint8 ) ) ? sizeof( uint8 ) : value;
}

int32 UHEVLibIO::GetConfigInteger( const FString SectionName, const FString VariableName, 
										  const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return 0;

	int32 value = 0;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetInt( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetInt( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetInt( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return value;
}

float UHEVLibIO::GetConfigFloat( const FString SectionName, const FString VariableName, 
										const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return 0;

	float value = 0.0f;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetFloat( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetFloat( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetFloat( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetFloat( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetFloat( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetFloat( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetFloat( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return value;
}

FVector2D UHEVLibIO::GetConfigVector2D( const FString SectionName, const FString VariableName, 
											   const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return FVector2D::ZeroVector;

	FVector2D value = FVector2D::ZeroVector;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetVector2D( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetVector2D( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetVector2D( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetVector2D( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetVector2D( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetVector2D( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetVector2D( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return FVector2D( value.X, value.Y );
}

FVector UHEVLibIO::GetConfigVector( const FString SectionName, const FString VariableName, 
										   const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return FVector::ZeroVector;

	FVector value = FVector::ZeroVector;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetVector( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetVector( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetVector( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetVector( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetVector( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetVector( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetVector( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;

	}
	ReadError = error;
	return value;
}


FVector4 UHEVLibIO::GetConfigVector4( const FString SectionName, const FString VariableName, 
											 const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return FVector4( 0.f, 0.f, 0.f, 0.f );

	// PR FVector4::ZeroVector
	FVector4 value = FVector4( 0.f, 0.f, 0.f, 0.f );
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetVector4( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetVector4( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetVector4( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetVector4( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetVector4( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetVector4( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetVector4( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return value;
}

FRotator UHEVLibIO::GetConfigRotator( const FString SectionName, const FString VariableName, 
											 const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return FRotator::ZeroRotator;

	FRotator value = FRotator::ZeroRotator;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetRotator( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetRotator( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetRotator( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetRotator( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetRotator( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetRotator( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetRotator( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return value;
}

FLinearColor UHEVLibIO::GetConfigColor( const FString SectionName, const FString VariableName, 
											   const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return FColor::Black;

	FColor value = FColor::Black;
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetColor( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetColor( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetColor( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetColor( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->GetColor( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetColor( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetColor( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return FLinearColor( value );
}

FString UHEVLibIO::GetConfigString( const FString SectionName, const FString VariableName, 
										   const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return "";

	FString value = "";
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetString( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetString( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetString( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetString( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetString( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetString( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetString( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return value;
}

FText UHEVLibIO::GetConfigText( const FString SectionName, const FString VariableName,
										   const EHEVINIFilesList INIFile, const int32 ProfileIndex, bool &ReadError ) {
	if ( !GConfig ) return FText::GetEmpty();

	FText value = FText::GetEmpty();
	bool error = false;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			error = GConfig->GetText( *SectionName, *VariableName, value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			error = GConfig->GetText( *SectionName, *VariableName, value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			error = GConfig->GetText( *SectionName, *VariableName, value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			error = GConfig->GetText( *SectionName, *VariableName, value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			error = GConfig->GetText( *SectionName, *VariableName, value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			error = GConfig->GetText( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->Flush( true, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			error = GConfig->GetText( *SectionName, *VariableName, value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings" + FString::FromInt( ProfileIndex ) + ".cfg" ) ) );
			break;
	}
	ReadError = error;
	return value;
}

TArray<FString> UHEVLibIO::GetFilesByExtension( const FString _Extension, const EHEVFilesDirList _Directory, const FString _SubDirectory, const bool _Recursive, bool &_Empty ) {
	TArray<FString> save = TArray<FString>();
	TArray<FString> save_Slots = TArray<FString>();

	bool error = false;
	FString dir = "";

	switch ( _Directory ) {
		case EHEVFilesDirList::eGame:
			dir = FPaths::ConvertRelativePathToFull( FPaths::ProjectDir() );
			break;
		case EHEVFilesDirList::ePlugin:
			dir = FPaths::ConvertRelativePathToFull( FPaths::ProjectPluginsDir() );
			break;
		case EHEVFilesDirList::eConfig:
			dir = FPaths::ConvertRelativePathToFull( FPaths::ProjectConfigDir() );
			break;
		case EHEVFilesDirList::eUser:
			dir = FPaths::ConvertRelativePathToFull( FPaths::ProjectUserDir() );
			break;
	}
	dir = dir + _SubDirectory;

	FPaths::NormalizeDirectoryName( dir );
	FString ext = _Extension == "" ? "*" : _Extension;
	FString extComp = "*." + ext;
	const TCHAR* charExt = *extComp;
	//FText textVariable = FText::AsCultureInvariant( "*." + _Extension );
	if ( _Recursive ) {
		IFileManager::Get().FindFilesRecursive( save, *dir, charExt, true, false, true );
	} else {
		IFileManager::Get().FindFiles( save, *dir, charExt );
	}
	//IFileManager::Get().FindFilesRecursive( save, *dir, TEXT( textVariable ), true, true, true );

	int filesCount = save.Num();
	if ( filesCount <= 0 ) {
		_Empty = true;
		return save_Slots;
	}

#if !(UE_BUILD_SHIPPING || UE_BUILD_TEST)

	for ( int32 i = 0; i < filesCount; ++i ) {
		save_Slots.Add( FPaths::GetBaseFilename( save[i] ) );
	}

#else

	for ( int32 i = 0; i < filesCount; ++i ) {
		save_Slots.Add( FPaths::GetBaseFilename( save[i] ) );
	}

#endif

	_Empty = error;
	return save_Slots;
}

void UHEVLibIO::SetConfigBool( const FString SectionName, const FString VariableName, const bool BoolValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetBool( *SectionName, *VariableName, BoolValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetBool( *SectionName, *VariableName, BoolValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetBool( *SectionName, *VariableName, BoolValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetBool( *SectionName, *VariableName, BoolValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetBool( *SectionName, *VariableName, BoolValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetBool( *SectionName, *VariableName, BoolValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetBool( *SectionName, *VariableName, BoolValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}

}

void UHEVLibIO::SetConfigByte( const FString SectionName, const FString VariableName, const uint8 ByteValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	// PR SetByte
	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetInt( *SectionName, *VariableName, ByteValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetInt( *SectionName, *VariableName, ByteValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetInt( *SectionName, *VariableName, ByteValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetInt( *SectionName, *VariableName, ByteValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetInt( *SectionName, *VariableName, ByteValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetInt( *SectionName, *VariableName, ByteValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetInt( *SectionName, *VariableName, ByteValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigInteger( const FString SectionName, const FString VariableName, const int32 IntValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetInt( *SectionName, *VariableName, IntValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetInt( *SectionName, *VariableName, IntValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetInt( *SectionName, *VariableName, IntValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetInt( *SectionName, *VariableName, IntValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetInt( *SectionName, *VariableName, IntValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetInt( *SectionName, *VariableName, IntValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetInt( *SectionName, *VariableName, IntValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigFloat( const FString SectionName, const FString VariableName, const float FloatValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetFloat( *SectionName, *VariableName, FloatValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetFloat( *SectionName, *VariableName, FloatValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetFloat( *SectionName, *VariableName, FloatValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetFloat( *SectionName, *VariableName, FloatValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetFloat( *SectionName, *VariableName, FloatValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetFloat( *SectionName, *VariableName, FloatValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetFloat( *SectionName, *VariableName, FloatValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigVector2D( const FString SectionName, const FString VariableName, const FVector2D Vec2Value, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetVector2D( *SectionName, *VariableName, Vec2Value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetVector2D( *SectionName, *VariableName, Vec2Value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetVector2D( *SectionName, *VariableName, Vec2Value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetVector2D( *SectionName, *VariableName, Vec2Value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetVector2D( *SectionName, *VariableName, Vec2Value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetVector2D( *SectionName, *VariableName, Vec2Value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetVector2D( *SectionName, *VariableName, Vec2Value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigVector( const FString SectionName, const FString VariableName, const FVector VecValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetVector( *SectionName, *VariableName, VecValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetVector( *SectionName, *VariableName, VecValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetVector( *SectionName, *VariableName, VecValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetVector( *SectionName, *VariableName, VecValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetVector( *SectionName, *VariableName, VecValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetVector( *SectionName, *VariableName, VecValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetVector( *SectionName, *VariableName, VecValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigVector4( const FString SectionName, const FString VariableName, const FVector4& Vec4Value, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetVector4( *SectionName, *VariableName, Vec4Value, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetVector4( *SectionName, *VariableName, Vec4Value, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetVector4( *SectionName, *VariableName, Vec4Value, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetVector4( *SectionName, *VariableName, Vec4Value, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetVector4( *SectionName, *VariableName, Vec4Value, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetVector4( *SectionName, *VariableName, Vec4Value, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetVector4( *SectionName, *VariableName, Vec4Value, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigRotator( const FString SectionName, const FString VariableName, const FRotator RotValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetRotator( *SectionName, *VariableName, RotValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetRotator( *SectionName, *VariableName, RotValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetRotator( *SectionName, *VariableName, RotValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetRotator( *SectionName, *VariableName, RotValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetRotator( *SectionName, *VariableName, RotValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetRotator( *SectionName, *VariableName, RotValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetRotator( *SectionName, *VariableName, RotValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigColor( const FString SectionName, const FString VariableName, const FLinearColor ColorValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetColor( *SectionName, *VariableName, ColorValue.ToFColor( true ), GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetColor( *SectionName, *VariableName, ColorValue.ToFColor( true ), GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetColor( *SectionName, *VariableName, ColorValue.ToFColor( true ), GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetColor( *SectionName, *VariableName, ColorValue.ToFColor( true ), GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetColor( *SectionName, *VariableName, ColorValue.ToFColor( true ), GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetColor( *SectionName, *VariableName, ColorValue.ToFColor( true ), FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetColor( *SectionName, *VariableName, ColorValue.ToFColor( true ), FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigString( const FString SectionName, const FString VariableName, const FString StrValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetString( *SectionName, *VariableName, *StrValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetString( *SectionName, *VariableName, *StrValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetString( *SectionName, *VariableName, *StrValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetString( *SectionName, *VariableName, *StrValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetString( *SectionName, *VariableName, *StrValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetString( *SectionName, *VariableName, *StrValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetString( *SectionName, *VariableName, *StrValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}

void UHEVLibIO::SetConfigText( const FString SectionName, const FString VariableName, const FText TextValue, const EHEVINIFilesList INIFile ) {
	if ( !GConfig ) return;

	switch ( INIFile ) {
		case EHEVINIFilesList::eGGameIni:
			GConfig->SetText( *SectionName, *VariableName, TextValue, GGameIni );
			break;
		case EHEVINIFilesList::eGGameUserSettingsIni:
			GConfig->SetText( *SectionName, *VariableName, TextValue, GGameUserSettingsIni );
			break;
		case EHEVINIFilesList::eGScalabilityIni:
			GConfig->SetText( *SectionName, *VariableName, TextValue, GScalabilityIni );
			break;
		case EHEVINIFilesList::eGInputIni:
			GConfig->SetText( *SectionName, *VariableName, TextValue, GInputIni );
			break;
		case EHEVINIFilesList::eGEngineIni:
			GConfig->SetText( *SectionName, *VariableName, TextValue, GEngineIni );
			break;
		case EHEVINIFilesList::eGameSettingsConfig:
			GConfig->SetText( *SectionName, *VariableName, TextValue, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + TEXT( "GameSettings.cfg" ) ) );
			break;
		case EHEVINIFilesList::ePlayerSettingsConfig:
			GConfig->SetText( *SectionName, *VariableName, TextValue, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			GConfig->Flush( false, FString( FPaths::GeneratedConfigDir() + FString( "PlayerSettings.cfg" ) ) );
			break;
	}
}