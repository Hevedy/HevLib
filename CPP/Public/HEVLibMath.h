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
HEVLibMath.h
================================================
*/


#pragma once

#include "CoreMinimal.h"
#include "Engine.h"
#include "Engine/Engine.h"
#include "HEVLibMath.generated.h"


UCLASS()
class HEVLIBRARY_API UHEVLibMath : public UBlueprintFunctionLibrary {
	GENERATED_BODY()

	UHEVLibMath( const FObjectInitializer& ObjectInitializer );
private:

protected:

public:

	/** Returns the Quaternion from a Euler */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Rotator" )
		static FVector4 EulerToQuaternion( const FRotator RotValue );

	/** Returns the Euler from a Quaternion */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Rotator" )
		static FRotator QuaternionToEuler( const FVector4& Vec4Value );

	/** Returns the sector index of the float using as reference the number of sectors */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Byte" )
		static uint8 FullRotSectorByte( const float FloatValue, const int32 SectorsNumber );

	/** Returns the sector index of the float using as reference the number of sectors */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Integer" )
		static int32 FullRotSectorInt( const float FloatValue, const int32 SectorsNumber );

	/** Returns the sector index of each FVector axis using as reference the number of sectors */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector" )
		static FVector FullRotSectorVector( const FVector VecValue, const FVector SectorsNumber );

	/** Returns the sector index of each FRotator axis using as reference the number of sectors */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector" )
		static FVector FullRotSectorRotator( const FRotator RotValue, const FVector SectorsNumber );

	/** Returns the number of characters in the int */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Integer Size" ), Category = "HevLib|Misc|Utils" )
		static int32 IntegerCount( const int32 IntValue );

	/** Returns the number of characters in the float */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Float Size" ), Category = "HevLib|Misc|Utils" )
		static int32 FloatCount( const float FloatValue );

	/** Returns the number decimals in the float */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Float Decimals" ), Category = "HevLib|Misc|Utils" )
		static int32 DecimalCount( const float FloatValue );

	/** Returns the float of 360 rotation */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Float Rotation (360)" ), Category = "HevLib|Misc|Utils" )
		static float FloatRotation360( const float FloatValue, const float RotationValue );

	/** Returns the float in range of min and max can cross up or down */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Utils" )
		static int32 NormalizeInRangeRoulette( const int32 Value, const int32 Min, const int32 Max );

	/** Returns the float of 360 rotation */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Utils" )
		static float CloseInRotation( const float FloatA, const float FloatB, const bool bFixedNum );

	/** Returns the euler like int32 value */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "To Full From Half (Integer)" ), Category = "HevLib|Misc|Integer" )
		static int32 IMakeFullFromHalfRot( const int32 IntValue );

	/** Returns the euler like float value */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "To Full From Half (Float)" ), Category = "HevLib|Misc|Float" )
		static float FMakeFullFromHalfRot( const float FloatValue );

	/** Returns the normalize like int32 value */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "To Half From Full (Integer)" ), Category = "HevLib|Misc|Integer" )
		static int32 ICMakeHalfFromFullRot( const int32 IntValue );

	/** Returns the normalize like float value */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "To Half From Full (Float)" ), Category = "HevLib|Misc|Float" )
		static float FMakeHalfFromFullRot( const float FloatValue );

	/** Returns the euler like FRotator value */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Convert 180 To 360 Rotation" ), Category = "HevLib|Misc|Rotator" )
		static FRotator MakeFullFromHalfRot( const FRotator RotValue );

	/** Returns the normalize like FRotator value */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Convert 360 To 180 Rotation" ), Category = "HevLib|Misc|Rotator" )
		static FRotator MakeHalfFromFullRot( const FRotator RotValue );

	/** Returns the euler like FVector2D value */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Convert 180 To 360 Rotation" ), Category = "HevLib|Misc|Vector2D" )
		static FVector2D V2DMakeFullFromHalfRot( const FVector2D Vec2Value );

	/** Returns the normalize like FVector2D value */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Convert 360 To 180 Rotation" ), Category = "HevLib|Misc|Vector2D" )
		static FVector2D V2DMakeHalfFromFullRot( const FVector2D Vec2Value );

	/** Returns the euler like FVector value */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Convert 180 To 360 Rotation" ), Category = "HevLib|Misc|Vector" )
		static FVector VMakeFullFromHalfRot( const FVector VecValue );

	/** Returns the normalize like FVector value */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Convert 360 To 180 Rotation" ), Category = "HevLib|Misc|Vector" )
		static FVector VMakeHalfFromFullRot( const FVector VecValue );

	/** Returns the euler like FVector4 value */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Convert 180 To 360 Rotation" ), Category = "HevLib|Misc|Vector4" )
		static FVector4 V4MakeFullFromHalfRot( const FVector4& Vec4Value );

	/** Returns the normalize like FVector value */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Convert 360 To 180 Rotation" ), Category = "HevLib|Misc|Vector4" )
		static FVector4 V4MakeHalfFromFullRot( const FVector4& Vec4Value );
	
	// Returns the closer value of A and B
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Closer (Byte)", CompactNodeTitle = "CLOS" ), Category = "HevLib|Misc|Byte" )
		static uint8 BGetCloser( uint8 Ref, uint8 A, uint8 B );

	// Returns the further value of A and B
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Further (Byte)", CompactNodeTitle = "FURT" ), Category = "HevLib|Misc|Byte" )
		static uint8 BGetFurther( uint8 Ref, uint8 A, uint8 B );

	// Returns the closer value of A and B
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Closer (int)", CompactNodeTitle = "CLOS" ), Category = "HevLib|Misc|Integer" )
		static int32 IGetCloser( int32 Ref, int32 A, int32 B );

	// Returns the further value of A and B
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Further (int)", CompactNodeTitle = "FURT" ), Category = "HevLib|Misc|Integer" )
		static int32 IGetFurther( int32 Ref, int32 A, int32 B );

	// Returns the closer value of A and B
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Closer (float)", CompactNodeTitle = "CLOS" ), Category = "HevLib|Misc|Float" )
		static float FGetCloser( float Ref, float A, float B );

	// Returns the further value of A and B
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Further (float)", CompactNodeTitle = "FURT" ), Category = "HevLib|Misc|Float" )
		static float FGetFurther( float Ref, float A, float B );

	/** Returns the closer value of A and B using provided numbers */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Closer Number (Byte)", CompactNodeTitle = "CLOSN" ), Category = "HevLib|Misc|Byte" )
		static uint8 BGetCloserSubNum( uint8 Ref, uint8 RefA, uint8 RefB, uint8 A, uint8 B );

	/** Returns the further value of A and B using provided numbers */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Further Number (Byte)", CompactNodeTitle = "FURTN" ), Category = "HevLib|Misc|Byte" )
		static uint8 BGetFurtherSubNum( uint8 Ref, uint8 RefA, uint8 RefB, uint8 A, uint8 B );

	/** Returns the closer value of A and B using provided numbers */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Closer Number (int)", CompactNodeTitle = "CLOSN" ), Category = "HevLib|Misc|Integer" )
		static int32 IGetCloserSubNum( int32 Ref, int32 RefA, int32 RefB, int32 A, int32 B );

	/** Returns the further value of A and B using provided numbers */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Further Number (int)", CompactNodeTitle = "FURTN" ), Category = "HevLib|Misc|Integer" )
		static int32 IGetFurtherSubNum( int32 Ref, int32 RefA, int32 RefB, int32 A, int32 B );

	/** Returns the closer value of A and B using provided numbers */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Closer Number (float)", CompactNodeTitle = "CLOSN" ), Category = "HevLib|Misc|Float" )
		static float FGetCloserSubNum( float Ref, float RefA, float RefB, float A, float B );

	/** Returns the further value of A and B using provided numbers */
	UFUNCTION( BlueprintPure, meta = ( DisplayName = "Further Number (float)", CompactNodeTitle = "FURTN" ), Category = "HevLib|Misc|Float" )
		static float FGetFurtherSubNum( float Ref, float RefA, float RefB, float A, float B );

	/** Returns the closer byte in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Byte" )
		static void CloserByteArray( const uint8 ByteRefValue, const TArray<uint8>& ByteArray, const bool NotEqual, int32& IndexOfCloserValue, uint8& CloserValue );

	/** Returns the further byte in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Byte" )
		static void FurtherByteArray( const uint8 ByteRefValue, const TArray<uint8>& ByteArray, int32& IndexOfFurtherValue, uint8& FurtherValue );

	/** Returns the closer integer in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Integer" )
		static void CloserIntegerArray( const int32 IntRefValue, const TArray<int32>& IntArray, const bool NotEqual, int32& IndexOfCloserValue, int32& CloserValue );

	/** Returns the further integer in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Integer" )
		static void FurtherIntegerArray( const int32 IntRefValue, const TArray<int32>& IntArray, int32& IndexOfFurtherValue, int32& FurtherValue );

	/** Returns the closer float in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void CloserFloatArray( const float FloatRefValue, const TArray<float>& FloatArray, const bool NotEqual, int32& IndexOfCloserValue, float& CloserValue );

	/** Returns the further float in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void FurtherFloatArray( const float FloatRefValue, const TArray<float>& FloatArray, int32& IndexOfFurtherValue, float& FurtherValue );

	/** Returns the min byte in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void MinByteArray( const TArray<uint8>& ByteArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMinValue, float& MinValue );

	/** Returns the max byte in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void MaxByteArray( const TArray<uint8>& ByteArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMaxValue, float& MaxValue );

	/** Returns the min integer in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void MinIntegerArray( const TArray<int32>& IntArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMinValue, float& MinValue );

	/** Returns the max integer in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void MaxIntegerArray( const TArray<int32>& IntArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMaxValue, float& MaxValue );

	/** Returns the min float in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void MinFloatArray( const TArray<float>& FloatArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMinValue, float& MinValue );

	/** Returns the max float in the array and their index at which it was found. Returns value of 0 and index of -1 if the supplied array is empty. */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Float" )
		static void MaxFloatArray( const TArray<float>& FloatArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMaxValue, float& MaxValue );

	/** Returns closer value in a generic way */
	template< class T >
	static CONSTEXPR FORCEINLINE T Closer( const T Reference, const T A, const T B ) {
		return ( ( ( Reference - A ) >= (T)0 ) ? ( Reference - A ) : -( Reference - A ) ) <= ( ( ( Reference - B ) >= (T)0 ) ? ( Reference - B ) : -( Reference - B ) ) ? A : B;
	}

	/** Returns further value in a generic way */
	template< class T >
	static CONSTEXPR FORCEINLINE T Further( const T Reference, const T A, const T B ) {
		return ( ( ( Reference - A ) >= (T)0 ) ? ( Reference - A ) : -( Reference - A ) ) >= ( ( ( Reference - B ) >= (T)0 ) ? ( Reference - B ) : -( Reference - B ) ) ? A : B;
	}

	/**
	* Closer number to given of Array
	* @param	Array of templated type
	* @param	Reference value templated type to compare
	* @param	Optional boolean to search only the closer values and no the equals
	* @param	Optional pointer for returning the index of the closer element, if multiple closer elements the first index is returned
	* @return	The closer value found in the array or default value if the array was empty or can't find a correct value
	*/
	template< class T >
	static FORCEINLINE T Closer( const T Reference, const TArray<T>& Values, const bool NotEqual, int32* CloserIndex = NULL ) {
		if ( Values.Num() == 0 ) {
			if ( CloserIndex ) {
				*CloserIndex = INDEX_NONE;
			}
			return T();
		}

		T CurCloser = ( ( Reference - Values[0] ) >= (T)0 ) ? ( Reference - Values[0] ) : -( Reference - Values[0] );
		int32 CurCloserIndex = 0;
		if ( CurCloser == 0 && NotEqual ) {
			CurCloserIndex = -1;
		}

		for ( int32 v = 1; v < Values.Num(); ++v ) {
			const T Value = ( ( Reference - Values[v] ) >= (T)0 ) ? ( Reference - Values[v] ) : -( Reference - Values[v] );
			if ( Value < CurCloser ) {
				if ( !NotEqual || ( NotEqual && Value != 0.f ) ) { // From 0 to 0.f probably fix
					CurCloser = Value;
					CurCloserIndex = v;
				}
			}
		}

		if ( CloserIndex ) {
			*CloserIndex = CurCloserIndex == -1 ? INDEX_NONE : CurCloserIndex;
		}
		return Values.Num() == 0 ? 0 : Values[CurCloserIndex == -1 ? 0 : CurCloserIndex];
	}

	/**
	* Further number to given of Array
	* @param	Array of templated type
	* @param	Reference value templated type to compare
	* @param	Optional pointer for returning the index of the further element, if multiple further elements the first index is returned
	* @return	The further value found in the array or default value if the array was empty
	*/
	template< class T >
	static FORCEINLINE T Further( const T Reference, const TArray<T>& Values, int32* FurtherIndex = NULL ) {
		if ( Values.Num() == 0 ) {
			if ( FurtherIndex ) {
				*FurtherIndex = INDEX_NONE;
			}
			return T();
		}

		T CurFurther = ( ( Reference - Values[0] ) >= (T)0 ) ? ( Reference - Values[0] ) : -( Reference - Values[0] );
		int32 CurFurtherIndex = 0;
		for ( int32 v = 1; v < Values.Num(); ++v ) {
			const T Value = ( ( Reference - Values[v] ) >= (T)0 ) ? ( Reference - Values[v] ) : -( Reference - Values[v] );
			if ( CurFurther < Value ) {
				CurFurther = Value;
				CurFurtherIndex = v;
			}
		}

		if ( FurtherIndex ) {
			*FurtherIndex = CurFurtherIndex == -1 ? INDEX_NONE : CurFurtherIndex;
		}
		return Values.Num() == 0 ? 0 : Values[CurFurtherIndex == -1 ? 0 : CurFurtherIndex];
	}

};