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
HEVLibMisc.h
================================================
*/


#pragma once

#include "CoreMinimal.h"
#include "Engine.h"
#include "Engine/Engine.h"
#include "HEVLibMath.h"
#include "GameFramework/Actor.h"
#include "Components/SplineComponent.h"
#include "HEVLibMisc.generated.h"


USTRUCT( BlueprintType )
struct FHEVStr2Struct : public FTableRowBase {
	GENERATED_USTRUCT_BODY()

public:

	FHEVStr2Struct()
		: StrA( "" )
		, StrB( "" ) {}

	/** First Colum add index */

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		FString StrA;

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		FString StrB;

};

USTRUCT( BlueprintType )
struct FHEVStr3Struct : public FTableRowBase {
	GENERATED_USTRUCT_BODY()

public:

	FHEVStr3Struct()
		: StrA( "" )
		, StrB( "" )
		, StrC( "" ) {}

	/** First Colum add index */

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		FString StrA;

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		FString StrB;

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		FString StrC;

};

USTRUCT( BlueprintType )
struct FHEVInt2Struct : public FTableRowBase {
	GENERATED_USTRUCT_BODY()

public:

	FHEVInt2Struct()
		: IntA( 0 )
		, IntB( 0 ) {}

	/** First Colum add index */

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		int32 IntA;

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		int32 IntB;

};

USTRUCT( BlueprintType )
struct FHEVInt3Struct : public FTableRowBase {
	GENERATED_USTRUCT_BODY()

public:

	FHEVInt3Struct()
		: IntA( 0 )
		, IntB( 0 )
		, IntC( 0 ) {}

	/** First Colum add index */

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		int32 IntA;

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		int32 IntB;

	/** String */
	UPROPERTY( EditAnywhere, BlueprintReadWrite, Category = "HevLib|Misc|Struct" )
		int32 IntC;

};

UCLASS()
class HEVLIB_API UHEVLibMisc : public UBlueprintFunctionLibrary {
	GENERATED_BODY()

	UHEVLibMisc( const FObjectInitializer& ObjectInitializer );
private:

protected:

public:


	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "EulerToQuaternion" ), Category = "HevLib|Misc|Transformation" )
		static FVector4 EulerToQuaternion( const FRotator RotValue );

	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "QuaternionToEuler" ), Category = "HevLib|Misc|Transformation" )
		static FRotator QuaternionToEuler( const FVector4& Vec4Value );

	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Transformation", meta = ( DisplayName = "CompAddWorldQuat", AdvancedDisplay = "bSweep,SweepHitResult,bTeleport" ) )
		static void ActorCompAddQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport );

	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Transformation", meta = ( DisplayName = "CompSetWorldQuat", AdvancedDisplay = "bSweep,SweepHitResult,bTeleport" ) )
		static void ActorCompSetQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport );

	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Transformation", meta = ( DisplayName = "CompAddRelativeQuat", AdvancedDisplay = "bSweep,SweepHitResult,bTeleport" ) )
		static void ActorCompAddRelativeQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport );

	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Transformation", meta = ( DisplayName = "CompSetRelativeQuat", AdvancedDisplay = "bSweep,SweepHitResult,bTeleport" ) )
		static void ActorCompSetRelativeQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport );

	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Transformation", meta = ( DisplayName = "CompAddLocalQuat", AdvancedDisplay = "bSweep,SweepHitResult,bTeleport" ) )
		static void ActorCompAddLocalQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport );

	/** Returns a float from two ints A and B to A.B */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Make Float" ), Category = "HevLib|Misc|Float" )
		static float MakeFloatFromIntegers( const int32 A, const int32 B );

	/** Returns split a float into two ints A.B to A and B */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Break Float" ), Category = "HevLib|Misc|Int" )
		static int32 DivideFloatIntoIntegers( const float Ref, int32& B );

	/** Returns the float inverted A.B to B.A */
	UFUNCTION( BlueprintCallable, meta = ( DisplayName = "Invert Float Order" ), Category = "HevLib|Misc|Float" )
		static float InvertFloat( const float FloatValue );

	/** Returns FVector2D(A,B) from a float A.B */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector2D FloatSplitToVector2D( const float FloatValue );

	/** Returns FVector(A,B,0) from a float A.B */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector FloatSplitToVector( const float FloatValue );

	/** Returns FVector4(A,B,0,0) from a float A.B */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector4 FloatSplitToVector4( const float FloatValue );

	/** Returns FVector2D(A,B) from the FVector(A,B,C) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector2D VectorToVector2D( const FVector &VecValue );

	/** Returns FVector2D(A,B) from the FVector4(A,B,C,D) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector2D Vector4ToVector2D( const FVector4 &Vec4Value );

	/** Returns FVector(A,B,0) from the FVector2D(A,B) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector VectorIntToVector( const FIntVector &VecIntValue );

	/** Returns FVector(A,B,0) from the FVector2D(A,B) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector Vector2DToVector( const FVector2D &Vec2Value );

	/** Returns FVector(A,B,C) from the FVector4(A,B,C,D) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector Vector4ToVector( const FVector4 &Vec4Value );

	/** Returns FVector(A,B,0) from the FVector2D(A,B) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FIntVector VectorToVectorInt( const FVector &VecValue );

	/** Returns FVector4(A,B,0,0) from the FVector2D(A,B) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector4 Vector2DToVector4( const FVector2D &Vec2Value );

	/** Returns FVector4(A,B,C,0) from the FVector(A,B,C) */
	UFUNCTION( BlueprintCallable, Category = "HevLib|Misc|Vector" )
		static FVector4 VectorToVector4( const FVector &VecValue );

	/** Returns FRotator(C,B,A) from the FRotator(A,B,C) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Rotator" )
		static FRotator RotatorOrderInvert( const FRotator &RotValue );

	/** Returns FVector2D(B,A) from the FVector2D(A,B) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector2D" )
		static FVector2D Vector2DOrderInvert( const FVector2D &Vec2Value );

	/** Returns FVector(C,B,A) from the FVector(A,B,C) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector" )
		static FVector VectorOrderInvert( const FVector &VecValue );

	/** Returns FVector4(D,C,B,A) from the FVector4(A,B,C,D) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector4" )
		static FVector4 Vector4OrderInvert( const FVector4 &Vec4Value );

	/** Returns FRotator(C,A,B) from the FRotator(A,B,C) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Rotator" )
		static FRotator RotatorOrderRight( const FRotator &RotValue );

	/** Returns FVector(C,A,B) from the FVector(A,B,C) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector" )
		static FVector VectorOrderRight( const FVector &VecValue );

	/** Returns FVector(D,A,B,C) from the FVector(A,B,C) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector" )
		static FVector4 Vector4OrderRight( const FVector4 &Vec4Value );

	/** Returns FRotator(B,C,A) from the FRotator(A,B,C) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Rotator" )
		static FRotator RotatorOrderLeft( const FRotator &RotValue );

	/** Returns FVector(B,C,A) from the FVector(A,B,C) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector" )
		static FVector VectorOrderLeft( const FVector &VecValue );

	/** Returns FVector(B,C,D,A) from the FVector(A,B,C,D) */
	UFUNCTION( BlueprintPure, Category = "HevLib|Misc|Vector" )
		static FVector4 Vector4OrderLeft( const FVector4 &Vec4Value );

	UFUNCTION( BlueprintPure, Category = "HevLib|Tools" )
		static FString FormatNumberZeros( const int32 Number, const int32 Length = 3, const bool LeftAlign = true );
		
	UFUNCTION( BlueprintPure, Category = "HevLib|Tools" )
		float GetDistanceAlongSplineForWorldLocation( USplineComponent *_SplineComponent, FVector _Location, int32 _DistanceSolverIterations ) const;
};