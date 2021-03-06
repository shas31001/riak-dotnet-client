// <copyright file="RiakConstants.cs" company="Basho Technologies, Inc.">
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

namespace RiakClient
{
    using System.Collections.Generic;
    using Messages;

    public static class RiakConstants
    {
        public const string DefaultBucketType = null;

        public static class RiakEnterprise
        {
            public enum ReplicationMode
            {
                False = RpbBucketProps.RpbReplMode.FALSE,
                Realtime = RpbBucketProps.RpbReplMode.REALTIME,
                FullSync = RpbBucketProps.RpbReplMode.FULLSYNC,
                True = RpbBucketProps.RpbReplMode.TRUE
            }
        }

        public static class ContentTypes
        {
            public const string Any = @"*/*";
            public const string ApplicationOctetStream = @"application/octet-stream";
            public const string ApplicationJson = @"application/json";
            public const string TextPlain = @"text/plain";
            public const string TextHtml = @"text/html";
            public const string MultipartMixed = @"multipart/mixed";
            public const string ImageJpg = @"image/jpeg";
            public const string ImageGif = @"image/gif";
            public const string ImagePng = @"image/png";
            public const string ErlangBinary = @"application/x-erlang-binary";
            public const string Xml = @"application/xml";
            public const string ProtocolBuffers = ApplicationOctetStream; // @"application/x-protobuf";
        }

        public static class IndexSuffix
        {
            public const string Integer = @"_int";
            public const string Binary = @"_bin";
        }

        public static class MapReduceLanguage
        {
            public const string JavaScript = "javascript";
            public const string Json = JavaScript;
            public const string Erlang = "erlang";
        }

        public static class MapReducePhaseType
        {
            public const string Map = @"map";
            public const string Reduce = @"reduce";
            public const string Link = @"link";
        }

        public static class CharSets
        {
            public const string Utf8 = @"UTF-8";
            public const string Binary = null;
        }

        public static class Defaults
        {
            public const string ContentType = ContentTypes.ApplicationJson;
            public const string CharSet = CharSets.Utf8;

            public static class Rest
            {
                public static readonly Timeout Timeout = new Timeout(30000);
            }

            public static class YokozunaIndex
            {
                public const string IndexName = "_yz_default";
                public const int NVal = 3;
            }
        }

        public static class KeyFilterTransforms
        {
            public const string IntToString = @"int_to_string";
            public const string StringToInt = @"string_to_int";
            public const string FloatToString = @"float_to_string";
            public const string StringToFloat = @"string_to_float";
            public const string ToUpper = @"to_upper";
            public const string ToLower = @"to_lower";
            public const string Tokenize = @"tokenize";
        }

        public static class SystemIndexKeys
        {
            public const string RiakKeysIndex = "$key";
            public const string RiakBucketIndex = "$bucket";

            public static readonly HashSet<string> SystemBinKeys = new HashSet<string> { RiakKeysIndex, RiakBucketIndex };
            public static readonly HashSet<string> SystemIntKeys = new HashSet<string>();
        }

        public static class Rest
        {
            public const string UserAgent = "RiakClient v2.0 (REST)";

            public static class QueryParameters
            {
                public static class Bucket
                {
                    public const string GetPropertiesKey = @"props";
                    public const string GetPropertiesValue = @"true";
                }
            }

            public static class Uri
            {
                public const string RiakRoot = "/riak";
                public const string MapReduce = "/mapred";
                public const string BucketPropsFmt = "/buckets/{0}/props";
                public const string StatsRoot = "/stats";
            }

            public static class Scheme
            {
                public const string Ssl = @"https";
            }

            public static class HttpHeaders
            {
                public const string DisableCacheKey = @"Pragma";
                public const string DisableCacheValue = @"no-cache";
            }

            public static class HttpMethod
            {
                public const string Get = "GET";
                public const string Post = "POST";
                public const string Put = "PUT";
                public const string Delete = "DELETE";
            }
        }

        public static class SearchFieldKeys
        {
            public const string BucketType = "_yz_rt";
            public const string Bucket = "_yz_rb";
            public const string Key = "_yz_rk";

            public const string Id = "_yz_id";
            public const string Score = "score";

            public const string LegacySearchId = "id";
        }
    }
}