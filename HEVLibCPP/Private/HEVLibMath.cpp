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
HEVLibMath.cpp
================================================
*/


#include "HEVLibMath.h"
#include "HEVLibPrivatePCH.h"


UHEVLibMath::UHEVLibMath( const class FObjectInitializer& ObjectInitializer ) {

}

FVector4 UHEVLibMath::EulerToQuaternion( const FRotator RotValue ) {
	float c1 = FMath::Cos( RotValue.Pitch / 2 );
	float s1 = FMath::Sin( RotValue.Pitch / 2 );
	float c2 = FMath::Cos( RotValue.Yaw / 2 );
	float s2 = FMath::Sin( RotValue.Yaw / 2 );
	float c3 = FMath::Cos( RotValue.Roll / 2 );
	float s3 = FMath::Sin( RotValue.Roll / 2 );
	float c1c2 = c1 * c2;
	float s1s2 = s1 * s2;
	return FVector4( c1c2 * s3 + s1s2 * c3,
					 s1 * c2 * c3 + c1 * s2 * s3,
					 c1 * s2 * c3 - s1 * c2 * s3,
					 c1c2 * c3 - s1s2 * s3 );
}

FRotator UHEVLibMath::QuaternionToEuler( const FVector4& Vec4Value ) {
	float test = Vec4Value.X * Vec4Value.Y + Vec4Value.Z * Vec4Value.W;
	if ( test > 0.499 ) {
		return FRotator( 2 * FMath::Atan2( Vec4Value.X, Vec4Value.W ), PI / 2, 0 );
	}
	if ( test < -0.499 ) {
		return FRotator( -2 * FMath::Atan2( Vec4Value.X, Vec4Value.Y ), PI / 2, 0 );
	}
	float sqx = Vec4Value.X * Vec4Value.X;
	float sqy = Vec4Value.Y * Vec4Value.Y;
	float sqz = Vec4Value.Z * Vec4Value.Z;
	return FRotator( atan2( 2 * Vec4Value.Y * Vec4Value.W - 2 * Vec4Value.X * Vec4Value.Z, 1 - 2 * sqy - 2 * sqz ),
					 asin( 2 * test ),
					 atan2( 2 * Vec4Value.X * Vec4Value.W - 2 * Vec4Value.Y * Vec4Value.Z, 1 - 2 * sqx - 2 * sqz ) );
}

int32 UHEVLibMath::FullRotSector( const float FloatValue, const int32 SectorsNumber ) {
	int32 calcSectors = FMath::TruncToInt( 360 / SectorsNumber );
	int32 calcValue = FMath::TruncToInt( FMath::TruncToInt( FloatValue + 360 ) % 360 );
	return FMath::TruncToInt( calcValue / calcSectors );
}

uint8 UHEVLibMath::FullRotSectorByte( const float FloatValue, const int32 SectorsNumber ) {
	return (uint8)FullRotSector( FloatValue, SectorsNumber );
}

int32 UHEVLibMath::FullRotSectorInt( const float FloatValue, const int32 SectorsNumber ) {
	return FullRotSector( FloatValue, SectorsNumber );
}

FVector UHEVLibMath::FullRotSectorVector( const FVector VectorValue, const FVector SectorsNumber ) {
	return FVector( FullRotSector( VectorValue.X, SectorsNumber.X ),
					FullRotSector( VectorValue.Y, SectorsNumber.Y ),
					FullRotSector( VectorValue.Z, SectorsNumber.Z ) );
}

FVector UHEVLibMath::FullRotSectorRotator( const FRotator RotValue, const FVector SectorsNumber ) {
	return FVector( FullRotSector( RotValue.Roll, SectorsNumber.X ),
			 FullRotSector( RotValue.Pitch, SectorsNumber.Y ),
			 FullRotSector( RotValue.Yaw, SectorsNumber.Z ) );
}

int32 UHEVLibMath::IntegerCount( const int32 IntValue ) {
	//return IntValue == 0 ? 1 : FMath::FloorToInt( FMath::Log10( FMath::Abs( IntValue ) ) ) + 1;
	return 0;
}

int32 UHEVLibMath::FloatCount( const float FloatValue ) {
	//return FloatValue == 0 ? 1 : FMath::FloorToInt( FMath::Log10( FMath::Abs( FloatValue ) ) );
	return 0;
}

int32 UHEVLibMath::DecimalCount( const float FloatValue ) {

	return FMath::FloorToInt( 1 / FloatValue );
}

float UHEVLibMath::FloatRotation360( const float FloatValue, const float RotationValue ) {
	float rotation;
	rotation = RotationValue;
	if ( FloatValue != 0.f ) {
		( rotation + FloatValue ) > 360.0f ? rotation = ( rotation + FloatValue ) - 360.0f : ( rotation + FloatValue ) < 0.0f ? rotation = ( rotation + FloatValue ) + 360.0f : rotation = ( rotation + FloatValue );
	}
	return rotation;
}

int32 UHEVLibMath::NormalizeInRangeRoulette( const int32 Value, const int32 Min, const int32 Max ) {
	int32 min = Min;
	int32 val = Value;
	int32 max = Max;
	if ( val < min ) {
		return max - ( ( val % max ) * -1 );
	} else if ( val > max ) {
		return val % max;
	} else {
		return val;
	}
}

float UHEVLibMath::CloseInRotation( const float FloatA, const float FloatB, const bool bFixedNum ) {
	float a = FloatA < 0.0f ? FloatA + 360.0f : FloatA;
	float b = FloatB < 0.0f ? FloatB + 360.0f : FloatB;

	if ( FloatA == FloatB ||
		 FloatA == 0.0f && FloatB == 360.0f ||
		 FloatA == 360.0f && FloatB == 0.0f ) {
		return 0.0f;
	}

	float left = ( 360 - FloatA ) + FloatB;
	float right = FloatA - FloatB;
	if ( FloatA < FloatB ) {
		if ( FloatB > 0 ) {
			left = FloatB - FloatA;
			right = ( 360 - FloatB ) + FloatA;
		} else {
			left = ( 360 - FloatB ) + FloatA;
			right = FloatB - FloatA;
		}
	}
	float obj = ( ( left <= right ) ? left : ( right * -1 ) );
	if ( bFixedNum ) {
		obj >= 0 ? ( obj == 0 ? 0.0f : 1.0f ) : -1.0f;
	}
	return obj;

}

int32 UHEVLibMath::IMakeFullFromHalfRot( const int32 IntValue ) {
	return IntValue < 0 ? IntValue + 360 : IntValue;
}

float UHEVLibMath::FMakeFullFromHalfRot( const float FloatValue ) {
	return FloatValue < 0.0f ? FloatValue + 360.0f : FloatValue;
}

int32 UHEVLibMath::ICMakeHalfFromFullRot( const int32 IntValue ) {
	return IntValue > 180 ? IntValue - 360 : IntValue;
}

float UHEVLibMath::FMakeHalfFromFullRot( const float FloatValue ) {
	return FloatValue > 180.0f ? FloatValue - 360.0f : FloatValue;
}

FRotator UHEVLibMath::MakeFullFromHalfRot( const FRotator RotValue ) {
	FRotator value;
	value.Roll = RotValue.Roll < 0.0f ? RotValue.Roll + 360.0f : RotValue.Roll;
	value.Pitch = RotValue.Pitch < 0.0f ? RotValue.Pitch + 360.0f : RotValue.Pitch;
	value.Yaw = RotValue.Yaw < 0.0f ? RotValue.Yaw + 360.0f : RotValue.Yaw;
	return value;
}

FRotator UHEVLibMath::MakeHalfFromFullRot( const FRotator RotValue ) {
	FRotator value;
	value.Roll = RotValue.Roll > 180.0f ? RotValue.Roll - 360.0f : RotValue.Roll;
	value.Pitch = RotValue.Pitch > 180.0f ? RotValue.Pitch - 360.0f : RotValue.Pitch;
	value.Yaw = RotValue.Yaw > 180.0f ? RotValue.Yaw - 360.0f : RotValue.Yaw;
	return value;
}

FVector2D UHEVLibMath::V2DMakeFullFromHalfRot( const FVector2D Vec2Value ) {
	FVector2D value;
	value.X = Vec2Value.X < 0.0f ? Vec2Value.X + 360.0f : Vec2Value.X;
	value.Y = Vec2Value.Y < 0.0f ? Vec2Value.Y + 360.0f : Vec2Value.Y;
	return value;
}

FVector2D UHEVLibMath::V2DMakeHalfFromFullRot( const FVector2D Vec2Value ) {
	FVector2D value;
	value.X = Vec2Value.X > 180.0f ? Vec2Value.X - 360.0f : Vec2Value.X;
	value.Y = Vec2Value.Y > 180.0f ? Vec2Value.Y - 360.0f : Vec2Value.Y;
	return value;
}

FVector UHEVLibMath::VMakeFullFromHalfRot( const FVector VecValue ) {
	FVector value;
	value.X = VecValue.X < 0.0f ? VecValue.X + 360.0f : VecValue.X;
	value.Y = VecValue.Y < 0.0f ? VecValue.Y + 360.0f : VecValue.Y;
	value.Z = VecValue.Z < 0.0f ? VecValue.Z + 360.0f : VecValue.Z;
	return value;
}

FVector UHEVLibMath::VMakeHalfFromFullRot( const FVector VecValue ) {
	FVector value;
	value.X = VecValue.X > 180.0f ? VecValue.X - 360.0f : VecValue.X;
	value.Y = VecValue.Y > 180.0f ? VecValue.Y - 360.0f : VecValue.Y;
	value.Z = VecValue.Z > 180.0f ? VecValue.Z - 360.0f : VecValue.Z;
	return value;
}

FVector4 UHEVLibMath::V4MakeFullFromHalfRot( const FVector4& Vec4Value ) {
	FVector4 value;
	value.X = Vec4Value.X < 0.0f ? Vec4Value.X + 360.0f : Vec4Value.X;
	value.Y = Vec4Value.Y < 0.0f ? Vec4Value.Y + 360.0f : Vec4Value.Y;
	value.Z = Vec4Value.Z < 0.0f ? Vec4Value.Z + 360.0f : Vec4Value.Z;
	value.W = Vec4Value.W < 0.0f ? Vec4Value.W + 360.0f : Vec4Value.W;
	return value;
}

FVector4 UHEVLibMath::V4MakeHalfFromFullRot( const FVector4& Vec4Value ) {
	FVector4 value;
	value.X = Vec4Value.X > 180.0f ? Vec4Value.X - 360.0f : Vec4Value.X;
	value.Y = Vec4Value.Y > 180.0f ? Vec4Value.Y - 360.0f : Vec4Value.Y;
	value.Z = Vec4Value.Z > 180.0f ? Vec4Value.Z - 360.0f : Vec4Value.Z;
	value.W = Vec4Value.W > 180.0f ? Vec4Value.W - 360.0f : Vec4Value.W;
	return value;
}


uint8 UHEVLibMath::BGetCloser( uint8 Ref, uint8 A, uint8 B ) {
	return Closer<uint8>( Ref, A, B );
}

uint8 UHEVLibMath::BGetFurther( uint8 Ref, uint8 A, uint8 B ) {
	return Further<uint8>( Ref, A, B );
}

int32 UHEVLibMath::IGetCloser( int32 Ref, int32 A, int32 B ) {
	return Closer<int32>( Ref, A, B );
}

int32 UHEVLibMath::IGetFurther( int32 Ref, int32 A, int32 B ) {
	return Further<int32>( Ref, A, B );
}

float UHEVLibMath::FGetCloser( float Ref, float A, float B ) {
	return Closer<float>( Ref, A, B );
}

float UHEVLibMath::FGetFurther( float Ref, float A, float B ) {
	return Further<float>( Ref, A, B );
}

uint8 UHEVLibMath::BGetCloserSubNum( uint8 Ref, uint8 RefA, uint8 RefB, uint8 A, uint8 B ) {
	return ( ( Closer<uint8>( Ref, RefA, RefB )) == RefA ? A : B);
}

uint8 UHEVLibMath::BGetFurtherSubNum( uint8 Ref, uint8 RefA, uint8 RefB, uint8 A, uint8 B ) {
	return ( ( Further<uint8>( Ref, RefA, RefB )) == RefA ? A : B);
}

int32 UHEVLibMath::IGetCloserSubNum( int32 Ref, int32 RefA, int32 RefB, int32 A, int32 B ) {
	return ( ( Closer<int32>( Ref, RefA, RefB )) == RefA ? A : B);
}

int32 UHEVLibMath::IGetFurtherSubNum( int32 Ref, int32 RefA, int32 RefB, int32 A, int32 B ) {
	return ( ( Further<int32>( Ref, RefA, RefB )) == RefA ? A : B);
}

float UHEVLibMath::FGetCloserSubNum( float Ref, float RefA, float RefB, float A, float B ) {
	return ( ( Closer<float>( Ref, RefA, RefB )) == RefA ? A : B);
}

float UHEVLibMath::FGetFurtherSubNum( float Ref, float RefA, float RefB, float A, float B ) {
	return ( ( Further<float>( Ref, RefA, RefB )) == RefA ? A : B);
}

void UHEVLibMath::CloserByteArray( const uint8 ByteRefValue, const TArray<uint8>& ByteArray, const bool NotEqual,
									   int32& IndexOfCloserValue, uint8& CloserValue ) {
	CloserValue = Closer<uint8>( ByteRefValue, ByteArray, NotEqual, &IndexOfCloserValue );
}

void UHEVLibMath::FurtherByteArray( const uint8 ByteRefValue, const TArray<uint8>& ByteArray, int32& IndexOfFurtherValue,
										uint8& FurtherValue ) {
	FurtherValue = Further<uint8>( ByteRefValue, ByteArray, &IndexOfFurtherValue );
}

void UHEVLibMath::CloserIntegerArray( const int32 IntRefValue, const TArray<int32>& IntArray, const bool NotEqual, 
									  int32& IndexOfCloserValue, int32& CloserValue ) {
	CloserValue = Closer<int32>( IntRefValue, IntArray, NotEqual, &IndexOfCloserValue );
}

void UHEVLibMath::FurtherIntegerArray( const int32 IntRefValue, const TArray<int32>& IntArray, int32& IndexOfFurtherValue, 
									   int32& FurtherValue ) {
	FurtherValue = Further<int32>( IntRefValue, IntArray, &IndexOfFurtherValue );
}

void UHEVLibMath::CloserFloatArray( const float FloatRefValue, const TArray<float>& FloatArray, const bool NotEqual, 
										int32& IndexOfCloserValue, float& CloserValue ) {
	CloserValue = Closer<float>( FloatRefValue, FloatArray, NotEqual, &IndexOfCloserValue );
}

void UHEVLibMath::FurtherFloatArray( const float FloatRefValue, const TArray<float>& FloatArray, int32& IndexOfFurtherValue, 
										 float& FurtherValue ) {
	FurtherValue = Further<float>( FloatRefValue, FloatArray, &IndexOfFurtherValue );
}

void UHEVLibMath::MinByteArray( const TArray<uint8>& ByteArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMinValue,
									   float& MinValue ) {
	if ( NumberOfIndexToDiscard < 0 || NumberOfIndexToDiscard >= ByteArray.Num() ) {
		IndexOfMinValue = -1; MinValue = -1; return;
	}
	TArray<uint8> localArray = ByteArray; TArray<uint8> localArrayRef;
	int32 minIndex = -1; int32 lastMinIndex = -1; float minValue = -1; int32 numdiff = 0;
	for ( int32 i = -1; i < NumberOfIndexToDiscard; i++ ) {
		minValue = FMath::Min<uint8>( localArray, &minIndex );
		localArrayRef.Add( minIndex );
		localArray.RemoveAt( minIndex );
		lastMinIndex = minIndex;
	}
	for ( int32 i = 0; i < localArrayRef.Num(); i++ ) {
		minIndex = ( localArrayRef[i] < lastMinIndex ) ? minIndex + 1 : minIndex;
	}
	IndexOfMinValue = minIndex; MinValue = minValue;
}

void UHEVLibMath::MaxByteArray( const TArray<uint8>& ByteArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMaxValue,
									   float& MaxValue ) {
	if ( NumberOfIndexToDiscard < 0 || NumberOfIndexToDiscard >= ByteArray.Num() ) {
		IndexOfMaxValue = -1; MaxValue = -1; return;
	}
	TArray<uint8> localArray = ByteArray; TArray<uint8> localArrayRef;
	int32 maxIndex = -1; int32 lastMaxIndex = -1; float maxValue = -1; int32 numdiff = 0;
	for ( int32 i = -1; i < NumberOfIndexToDiscard; i++ ) {
		maxValue = FMath::Max<uint8>( localArray, &maxIndex );
		localArrayRef.Add( maxIndex );
		localArray.RemoveAt( maxIndex );
		lastMaxIndex = maxIndex;
	}
	for ( int32 i = 0; i < localArrayRef.Num(); i++ ) {
		maxIndex = ( localArrayRef[i] < lastMaxIndex ) ? maxIndex + 1 : maxIndex;
	}
	IndexOfMaxValue = maxIndex; MaxValue = maxValue;
}

void UHEVLibMath::MinIntegerArray( const TArray<int32>& IntArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMinValue,
									 float& MinValue ) {
	if ( NumberOfIndexToDiscard < 0 || NumberOfIndexToDiscard >= IntArray.Num() ) {
		IndexOfMinValue = -1; MinValue = -1; return;
	}
	TArray<int32> localArray = IntArray; TArray<int32> localArrayRef;
	int32 minIndex = -1; int32 lastMinIndex = -1; float minValue = -1; int32 numdiff = 0;
	for ( int32 i = -1; i < NumberOfIndexToDiscard; i++ ) {
		minValue = FMath::Min<int32>( localArray, &minIndex );
		localArrayRef.Add( minIndex );
		localArray.RemoveAt( minIndex );
		lastMinIndex = minIndex;
	}
	for ( int32 i = 0; i < localArrayRef.Num(); i++ ) {
		minIndex = ( localArrayRef[i] < lastMinIndex ) ? minIndex + 1 : minIndex;
	}
	IndexOfMinValue = minIndex; MinValue = minValue;
}

void UHEVLibMath::MaxIntegerArray( const TArray<int32>& IntArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMaxValue,
									 float& MaxValue ) {
	if ( NumberOfIndexToDiscard < 0 || NumberOfIndexToDiscard >= IntArray.Num() ) {
		IndexOfMaxValue = -1; MaxValue = -1; return;
	}
	TArray<int32> localArray = IntArray; TArray<int32> localArrayRef;
	int32 maxIndex = -1; int32 lastMaxIndex = -1; float maxValue = -1; int32 numdiff = 0;
	for ( int32 i = -1; i < NumberOfIndexToDiscard; i++ ) {
		maxValue = FMath::Max<int32>( localArray, &maxIndex );
		localArrayRef.Add( maxIndex );
		localArray.RemoveAt( maxIndex );
		lastMaxIndex = maxIndex;
	}
	for ( int32 i = 0; i < localArrayRef.Num(); i++ ) {
		maxIndex = ( localArrayRef[i] < lastMaxIndex ) ? maxIndex + 1 : maxIndex;
	}
	IndexOfMaxValue = maxIndex; MaxValue = maxValue;
}

void UHEVLibMath::MinFloatArray( const TArray<float>& FloatArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMinValue, 
									   float& MinValue ) {
	if ( NumberOfIndexToDiscard < 0 || NumberOfIndexToDiscard >= FloatArray.Num() ) {
		IndexOfMinValue = -1; MinValue = -1; return;
	}
	TArray<float> localArray = FloatArray; TArray<int32> localArrayRef;
	int32 minIndex = -1; int32 lastMinIndex = -1; float minValue = -1; int32 numdiff = 0;
	for ( int32 i = -1; i < NumberOfIndexToDiscard; i++ ) {
		minValue = FMath::Min<float>( localArray, &minIndex );
		localArrayRef.Add( minIndex );
		localArray.RemoveAt( minIndex );
		lastMinIndex = minIndex;
	}
	for ( int32 i = 0; i < localArrayRef.Num(); i++ ) {
		minIndex = ( localArrayRef[i] < lastMinIndex ) ? minIndex + 1 : minIndex;
	}
	IndexOfMinValue = minIndex; MinValue = minValue;
}

void UHEVLibMath::MaxFloatArray( const TArray<float>& FloatArray, const int32 NumberOfIndexToDiscard, int32& IndexOfMaxValue, 
										float& MaxValue ) {
	if ( NumberOfIndexToDiscard < 0 || NumberOfIndexToDiscard >= FloatArray.Num() ) {
		IndexOfMaxValue = -1; MaxValue = -1; return;
	}
	TArray<float> localArray = FloatArray; TArray<int32> localArrayRef;
	int32 maxIndex = -1; int32 lastMaxIndex = -1; float maxValue = -1; int32 numdiff = 0;
	for ( int32 i = -1; i < NumberOfIndexToDiscard; i++ ) {
		maxValue = FMath::Max<float>( localArray, &maxIndex );
		localArrayRef.Add( maxIndex );
		localArray.RemoveAt( maxIndex );
		lastMaxIndex = maxIndex;
	}
	for ( int32 i = 0; i < localArrayRef.Num(); i++ ) {
		maxIndex = ( localArrayRef[i] < lastMaxIndex ) ? maxIndex + 1 : maxIndex;
	}
	IndexOfMaxValue = maxIndex; MaxValue = maxValue;
}