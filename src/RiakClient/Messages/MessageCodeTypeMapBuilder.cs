// <copyright file="MessageCodeTypeMapBuilder.cs" company="Basho Technologies, Inc.">
// Copyright (c) 2011 - OJ Reeves & Jeremiah Peschka
// Copyright (c) 2014 - Basho Technologies, Inc.
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
// </copyright>

namespace RiakClient.Messages
{
    using System;
    using System.Collections.Generic;

    internal static class MessageCodeTypeMapBuilder
    {
        private static readonly Dictionary<MessageCode, Type> MessageCodeToTypeMap;
        private static readonly Dictionary<Type, MessageCode> TypeToMessageCodeMap;

        static MessageCodeTypeMapBuilder()
        {
            MessageCodeToTypeMap = new Dictionary<MessageCode, Type>
            {
                { MessageCode.RpbErrorResp, typeof(RpbErrorResp) },
                { MessageCode.RpbGetClientIdResp, typeof(RpbGetClientIdResp) },
                { MessageCode.RpbSetClientIdReq, typeof(RpbSetClientIdReq) },
                { MessageCode.RpbGetServerInfoResp, typeof(RpbGetServerInfoResp) },
                { MessageCode.RpbGetReq, typeof(RpbGetReq) },
                { MessageCode.RpbGetResp, typeof(RpbGetResp) },
                { MessageCode.RpbPutReq, typeof(RpbPutReq) },
                { MessageCode.RpbPutResp, typeof(RpbPutResp) },
                { MessageCode.RpbDelReq, typeof(RpbDelReq) },
                { MessageCode.RpbListBucketsReq, typeof(RpbListBucketsReq) },
                { MessageCode.RpbListBucketsResp, typeof(RpbListBucketsResp) },
                { MessageCode.RpbListKeysReq, typeof(RpbListKeysReq) },
                { MessageCode.RpbListKeysResp, typeof(RpbListKeysResp) },
                { MessageCode.RpbGetBucketReq, typeof(RpbGetBucketReq) },
                { MessageCode.RpbGetBucketResp, typeof(RpbGetBucketResp) },
                { MessageCode.RpbSetBucketReq, typeof(RpbSetBucketReq) },
                { MessageCode.RpbMapRedReq, typeof(RpbMapRedReq) },
                { MessageCode.RpbMapRedResp, typeof(RpbMapRedResp) },
                { MessageCode.RpbIndexReq, typeof(RpbIndexReq) },
                { MessageCode.RpbIndexResp, typeof(RpbIndexResp) },
                { MessageCode.RpbSearchQueryReq, typeof(RpbSearchQueryReq) },
                { MessageCode.RpbSearchQueryResp, typeof(RpbSearchQueryResp) },
                { MessageCode.RpbResetBucketReq, typeof(RpbResetBucketReq) },
                { MessageCode.RpbCSBucketReq, typeof(RpbCSBucketReq) },
                { MessageCode.RpbCSBucketResp, typeof(RpbCSBucketResp) },
                { MessageCode.RpbCounterUpdateReq, typeof(RpbCounterUpdateReq) },
                { MessageCode.RpbCounterUpdateResp, typeof(RpbCounterUpdateResp) },
                { MessageCode.RpbCounterGetReq, typeof(RpbCounterGetReq) },
                { MessageCode.RpbCounterGetResp, typeof(RpbCounterGetResp) },

                { MessageCode.RpbYokozunaIndexGetReq, typeof(RpbYokozunaIndexGetReq) },
                { MessageCode.RpbYokozunaIndexGetResp, typeof(RpbYokozunaIndexGetResp) },
                { MessageCode.RpbYokozunaIndexPutReq, typeof(RpbYokozunaIndexPutReq) },
                { MessageCode.RpbYokozunaIndexDeleteReq, typeof(RpbYokozunaIndexDeleteReq) },
                { MessageCode.RpbYokozunaSchemaGetReq, typeof(RpbYokozunaSchemaGetReq) },
                { MessageCode.RpbYokozunaSchemaGetResp, typeof(RpbYokozunaSchemaGetResp) },
                { MessageCode.RpbYokozunaSchemaPutReq, typeof(RpbYokozunaSchemaPutReq) },

                { MessageCode.DtFetchReq, typeof(DtFetchReq) },
                { MessageCode.DtFetchResp, typeof(DtFetchResp) },
                { MessageCode.DtUpdateReq, typeof(DtUpdateReq) },
                { MessageCode.DtUpdateResp, typeof(DtUpdateResp) },

                { MessageCode.RpbGetBucketTypeReq, typeof(RpbGetBucketTypeReq) },
                { MessageCode.RpbSetBucketTypeReq, typeof(RpbSetBucketTypeReq) },
                { MessageCode.RpbAuthReq, typeof(RpbAuthReq) }
            };

            TypeToMessageCodeMap = new Dictionary<Type, MessageCode>();

            foreach (var item in MessageCodeToTypeMap)
            {
                TypeToMessageCodeMap.Add(item.Value, item.Key);
            }
        }

        public static byte GetMessageCodeFor(Type type)
        {
            MessageCode messageCode = TypeToMessageCodeMap[type];
            return (byte)messageCode;
        }

        public static Type GetTypeFor(MessageCode messageCode)
        {
            return MessageCodeToTypeMap[messageCode];
        }

        public static bool Contains(MessageCode messageCode)
        {
            return MessageCodeToTypeMap.ContainsKey(messageCode);
        }

        public static string GetTypeNameFor(MessageCode messageCode)
        {
            return MessageCodeToTypeMap[messageCode].Name;
        }
    }
}
