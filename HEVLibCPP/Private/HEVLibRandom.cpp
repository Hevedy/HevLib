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
HEVLibRandom.cpp
================================================
*/


#include "HEVLibRandom.h"
#include "HEVLibPrivatePCH.h"

UHEVLibRandom::UHEVLibRandom( const class FObjectInitializer& ObjectInitializer ) {

}


bool UHEVLibRandom::RandomBool_Uniform() {
	return false;
}

bool UHEVLibRandom::RandomBool_Bernoulli( const float Bias ) {
	return false;
}

bool UHEVLibRandom::RandomBool_MersenneTwister( const float Bias ) {
	return false;
}

uint8 UHEVLibRandom::RandomByte_Uniform( const uint8 Max ) {
	return 0;
}

uint8 UHEVLibRandom::RandomByte_Bernoulli( const float Bias ) {
	return 0;
}

uint8 UHEVLibRandom::RandomByte_MersenneTwister( const float Bias ) {
	return 0;
}

int32 UHEVLibRandom::RandomInt_Uniform( const int32 Max ) {
	return 0;
}

int32 UHEVLibRandom::RandomInt_Bernoulli( const float Bias ) {
	return 0;
}

int32 UHEVLibRandom::RandomInt_MersenneTwister( const float Bias ) {
	return 0;
}

float UHEVLibRandom::RandomFloat_Uniform( const float Max ) {
	return 0.0f;
}

float UHEVLibRandom::RandomFloat_Canonical() {
	return 0.0f;
}