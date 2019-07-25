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
HEVLibMisc.cpp
================================================
*/


#include "HEVLibMisc.h"
#include "HEVLibPrivatePCH.h"
#include "HEVLibMath.h"

#include "Runtime/Core/Public/GenericPlatform/GenericPlatformDriver.h"
#include "Runtime/Core/Public/Misc/SecureHash.h"
#include "Runtime/Core/Public/Logging/MessageLog.h"

#if WITH_EDITOR
#include "Runtime/Core/Public/Internationalization/Regex.h"
#endif


UHEVLibMisc::UHEVLibMisc( const class FObjectInitializer& ObjectInitializer ) {

}

FVector4 UHEVLibMisc::EulerToQuaternion( const FRotator RotValue ) {
	const FQuat quat = FQuat( RotValue );
	return FVector4( quat.X, quat.Y, quat.Z, quat.W );
}

FRotator UHEVLibMisc::QuaternionToEuler( const FVector4& Vec4Value ) {
	const FQuat quat = FQuat( Vec4Value.X, Vec4Value.Y, Vec4Value.Z, Vec4Value.W );
	return FRotator( quat );
}

void UHEVLibMisc::ActorCompAddQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport ) {
	const FQuat quat = FQuat( Vec4Value.X, Vec4Value.Y, Vec4Value.Z, Vec4Value.W );
	Target->AddWorldRotation( quat, bSweep, ( bSweep ? &SweepHitResult : nullptr ), TeleportFlagToEnum( bTeleport ) );
}

void UHEVLibMisc::ActorCompSetQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport ) {
	const FQuat quat = FQuat( Vec4Value.X, Vec4Value.Y, Vec4Value.Z, Vec4Value.W );
	Target->SetWorldRotation( quat, bSweep, ( bSweep ? &SweepHitResult : nullptr ), TeleportFlagToEnum( bTeleport ) );

}

void UHEVLibMisc::ActorCompAddRelativeQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport ) {
	const FQuat quat = FQuat( Vec4Value.X, Vec4Value.Y, Vec4Value.Z, Vec4Value.W );
	Target->AddRelativeRotation( quat, bSweep, ( bSweep ? &SweepHitResult : nullptr ), TeleportFlagToEnum( bTeleport ) );

}

void UHEVLibMisc::ActorCompSetRelativeQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport ) {
	const FQuat quat = FQuat( Vec4Value.X, Vec4Value.Y, Vec4Value.Z, Vec4Value.W );
	Target->SetRelativeRotation( quat, bSweep, ( bSweep ? &SweepHitResult : nullptr ), TeleportFlagToEnum( bTeleport ) );

}

void UHEVLibMisc::ActorCompAddLocalQuaternion( USceneComponent* Target, const FVector4& Vec4Value, bool bSweep, FHitResult& SweepHitResult, bool bTeleport ) {
	const FQuat quat = FQuat( Vec4Value.X, Vec4Value.Y, Vec4Value.Z, Vec4Value.W );
	Target->AddLocalRotation( quat, bSweep, ( bSweep ? &SweepHitResult : nullptr ), TeleportFlagToEnum( bTeleport ) );

}

float UHEVLibMisc::MakeFloatFromIntegers( const int32 A, const int32 B ) {
	float value = A;
	int32 m = 1;
	for ( int32 i = 0; i <= UHEVLibMath::IntegerCount( B ); ++i ) { m *= 10; }
	return value + ( B / m );
}

int32 UHEVLibMisc::DivideFloatIntoIntegers( const float Ref, int32& B ) {
	B = FMath::Frac( Ref );
	return FMath::TruncToInt( Ref );
}

float UHEVLibMisc::InvertFloat( const float FloatValue ) {
	int32 a = FMath::TruncToInt( FloatValue );
	int32 b = FMath::Frac( FloatValue );
	int32 m = 1;
	for ( int32 i = 0; i <= UHEVLibMath::IntegerCount( FloatValue ); ++i ) { m *= 10; }
	return b + ( a / m );
}

FVector2D UHEVLibMisc::FloatSplitToVector2D( const float FloatValue ) {
	return FVector2D( FMath::TruncToInt( FloatValue ), FMath::Frac( FloatValue ) );
}

FVector UHEVLibMisc::FloatSplitToVector( const float FloatValue ) {
	return FVector( FMath::TruncToInt( FloatValue ), FMath::Frac( FloatValue ), 0.0f );
}

FVector4 UHEVLibMisc::FloatSplitToVector4( const float FloatValue ) {
	return FVector4( FMath::TruncToInt( FloatValue ), FMath::Frac( FloatValue ), 0.0f, 0.0f );
}

FVector2D UHEVLibMisc::VectorToVector2D( const FVector &VecValue ) {
	return FVector2D( VecValue.X, VecValue.Y );
}

FVector2D UHEVLibMisc::Vector4ToVector2D( const FVector4 &Vec4Value ) {
	return FVector2D( Vec4Value.X, Vec4Value.Y );
}

FVector UHEVLibMisc::VectorIntToVector( const FIntVector &VecIntValue ) {
	return FVector( FMath::TruncToInt( VecIntValue.X ), FMath::TruncToInt( VecIntValue.Y ), FMath::TruncToInt( VecIntValue.Z ) );
}

FVector UHEVLibMisc::Vector2DToVector( const FVector2D &Vec2Value ) {
	return FVector( Vec2Value.X, Vec2Value.Y, 0.0f );
}

FVector UHEVLibMisc::Vector4ToVector( const FVector4 &Vec4Value ) {
	return FVector( Vec4Value.X, Vec4Value.Y, Vec4Value.Z );
}

FIntVector UHEVLibMisc::VectorToVectorInt( const FVector &VecValue ) {
	return FIntVector( VecValue.X, VecValue.Y, VecValue.Z );
}

FVector4 UHEVLibMisc::Vector2DToVector4( const FVector2D &Vec2Value ) {
	return FVector4( Vec2Value.X, Vec2Value.Y, 0.0f, 0.0f );
}

FVector4 UHEVLibMisc::VectorToVector4( const FVector &VecValue ) {
	return FVector4( VecValue.X, VecValue.Y, VecValue.Z, 0.0f );
}

FRotator UHEVLibMisc::RotatorOrderInvert( const FRotator &RotValue ) {
	return FRotator( RotValue.Roll, RotValue.Yaw, RotValue.Pitch );
}

FVector2D UHEVLibMisc::Vector2DOrderInvert( const FVector2D &Vec2Value ) {
	return FVector2D( Vec2Value.Y, Vec2Value.X );
}

FVector UHEVLibMisc::VectorOrderInvert( const FVector &VecValue ) {
	return FVector( VecValue.Z, VecValue.Y, VecValue.X );
}

FVector4 UHEVLibMisc::Vector4OrderInvert( const FVector4 &Vec4Value ) {
	return FVector4( Vec4Value.W, Vec4Value.Z, Vec4Value.Y, Vec4Value.X );
}

FRotator UHEVLibMisc::RotatorOrderRight( const FRotator &RotValue ) {
	return FRotator( RotValue.Roll, RotValue.Pitch, RotValue.Yaw );
}

FVector UHEVLibMisc::VectorOrderRight( const FVector &VecValue ) {
	return FVector( VecValue.Z, VecValue.X, VecValue.Y );
}

FVector4 UHEVLibMisc::Vector4OrderRight( const FVector4 &Vec4Value ) {
	return FVector4( Vec4Value.W, Vec4Value.X, Vec4Value.Y, Vec4Value.Z );
}

FRotator UHEVLibMisc::RotatorOrderLeft( const FRotator &RotValue ) {
	return FRotator( RotValue.Yaw, RotValue.Roll, RotValue.Pitch );
}

FVector UHEVLibMisc::VectorOrderLeft( const FVector &VecValue ) {
	return FVector( VecValue.Y, VecValue.Z, VecValue.X );
}

FVector4 UHEVLibMisc::Vector4OrderLeft( const FVector4 &Vec4Value ) {
	return FVector4( Vec4Value.Y, Vec4Value.Z, Vec4Value.W, Vec4Value.X );
}

FString UHEVLibMisc::FormatNumberZeros( const int32 Number, const int32 Length, const bool LeftAlign ) {
	FString str = FString::FromInt( Number );
	FString subStr = "";
	int32 numLength = UHEVLibMath::IntegerCount( Number );
	if ( numLength >= Length && Length == 0 && numLength == 0 ) {
		return "-1";
	} else if ( numLength >= Length ) {
		return str;
	} else {
		int calc = Length - numLength;
		for ( int i = 0; i < calc; i++ ) {
			subStr = subStr + "0";
		}
		return LeftAlign ? ( subStr + str ) : ( str + subStr );
	}
}

// Based in https://answers.unrealengine.com/questions/153956/get-distance-along-spline-from-world-location.html from caasanchezcu
float UHEVLibMisc::GetDistanceAlongSplineForWorldLocation( USplineComponent *SplineComponent, FVector Location, int32 DistanceSolverIterations ) const {
	const float ClosestInputKey = SplineComponent->FindInputKeyClosestToWorldLocation( Location );
	const int32 PreviousPoint = FMath::TruncToInt( ClosestInputKey );

	float Distance = SplineComponent->GetDistanceAlongSplineAtSplinePoint( PreviousPoint );
	Distance += ( ClosestInputKey - PreviousPoint ) * ( SplineComponent->GetDistanceAlongSplineAtSplinePoint( PreviousPoint + 1 ) - Distance );

	for ( int32 i = 0; i < DistanceSolverIterations; ++i ) {
		const float InputKeyAtDistance = SplineComponent->SplineCurves.ReparamTable.Eval( Distance, 0.0f );
		const float Delta = ( SplineComponent->GetLocationAtSplineInputKey( InputKeyAtDistance, ESplineCoordinateSpace::World ) - SplineComponent->GetLocationAtSplineInputKey( ClosestInputKey, ESplineCoordinateSpace::World ) ).Size();
		if ( InputKeyAtDistance < ClosestInputKey ) {
			Distance += Delta;
		} else if ( InputKeyAtDistance > ClosestInputKey ) {
			Distance -= Delta;
		} else {
			break;
		}
	}
	return FMath::Clamp( Distance, 0.0f, SplineComponent->GetSplineLength() );
}