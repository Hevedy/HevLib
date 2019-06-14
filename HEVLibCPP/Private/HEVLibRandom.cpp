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
HEVLibRandom.cpp
================================================
*/


#include "HEVLibRandom.h"
#include "HEVLibPrivatePCH.h"

UHEVLibRandom::UHEVLibRandom( const class FObjectInitializer& ObjectInitializer ) {

}


bool UHEVLibRandom::RandomBool_Uniform() {
	return FMath::HRandBool_Uniform();
}

bool UHEVLibRandom::RandomBool_Bernoulli( const float Bias ) {
	return FMath::HRandBool_Bernoulli( Bias );
}

bool UHEVLibRandom::RandomBool_MersenneTwister( const float Bias ) {
	return FMath::HRandBool_Bernoulli( Bias );
}

uint8 UHEVLibRandom::RandomByte_Uniform( const uint8 Max ) {
	return FMath::HRandByte_Uniform( Max );
}

uint8 UHEVLibRandom::RandomByte_Bernoulli( const float Bias ) {
	return FMath::HRandByte_Bernoulli( Bias );
}

uint8 UHEVLibRandom::RandomByte_MersenneTwister( const float Bias ) {
	return FMath::HRandByte_Bernoulli( Bias );
}

int32 UHEVLibRandom::RandomInt_Uniform( const int32 Max ) {
	return FMath::HRandInt_Uniform( Max );
}

int32 UHEVLibRandom::RandomInt_Bernoulli( const float Bias ) {
	return FMath::HRandInt_Bernoulli( Bias );
}

int32 UHEVLibRandom::RandomInt_MersenneTwister( const float Bias ) {
	return FMath::HRandInt_Bernoulli( Bias );
}

float UHEVLibRandom::RandomFloat_Uniform( const float Max ) {
	return FMath::HRandFloat_Uniform( Max );
}

float UHEVLibRandom::RandomFloat_Canonical() {
	return FMath::HRandFloat_Canonical();
}