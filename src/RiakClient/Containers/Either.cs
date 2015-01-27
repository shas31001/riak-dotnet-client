﻿// Copyright (c) 2011 - OJ Reeves & Jeremiah Peschka
//
// This file is provided to you under the Apache License,
// Version 2.0 (the "License"); you may not use this file
// except in compliance with the License.  You may obtain
// a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

namespace RiakClient.Containers
{
    public class Either<TLeft, TRight>
    {
        public bool IsLeft { get; private set; }
        public TLeft Left { get; private set; }
        public TRight Right { get; private set; }

        public Either(TLeft left)
        {
            Left = left;
            IsLeft = true;
        }

        public Either(TRight right)
        {
            Right = right;
            IsLeft = false;
        }
    }
}