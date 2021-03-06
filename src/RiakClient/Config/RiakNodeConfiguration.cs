// <copyright file="RiakNodeConfiguration.cs" company="Basho Technologies, Inc.">
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

namespace RiakClient.Config
{
    using System.Configuration;
    using System.Runtime.InteropServices;

    [ComVisible(false)]
    public sealed class RiakNodeConfiguration : ConfigurationElement, IRiakNodeConfiguration
    {
        private static readonly Timeout DefaultTimeout = new Timeout(4000);

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("hostAddress", IsRequired = true)]
        public string HostAddress
        {
            get { return (string)this["hostAddress"]; }
            set { this["hostAddress"] = value; }
        }

        [ConfigurationProperty("pbcPort", DefaultValue = 8087, IsRequired = false)]
        public int PbcPort
        {
            get { return (int)this["pbcPort"]; }
            set { this["pbcPort"] = value; }
        }

        [ConfigurationProperty("restScheme", DefaultValue = "http", IsRequired = false)]
        public string RestScheme
        {
            get { return (string)this["restScheme"]; }
            set { this["restScheme"] = value; }
        }

        [ConfigurationProperty("restPort", DefaultValue = 8098, IsRequired = false)]
        public int RestPort
        {
            get { return (int)this["restPort"]; }
            set { this["restPort"] = value; }
        }

        [ConfigurationProperty("poolSize", DefaultValue = 30, IsRequired = false)]
        public int PoolSize
        {
            get { return (int)this["poolSize"]; }
            set { this["poolSize"] = value; }
        }

        /*
         * TODO: put this back in when we've got the idling stuff figured out
         * [ConfigurationProperty("idleTimeout", DefaultValue = 15000, IsRequired = false)]
         * public int IdleTimeout
         * {
         *     get { return (int)this["idleTimeout"]; }
         *     set { this["idleTimeout"] = value; }
         * }
         */

        public Timeout NetworkReadTimeout
        {
            get
            {
                int networkReadTimeoutMilliseconds;
                if (int.TryParse(NetworkReadTimeoutProperty, out networkReadTimeoutMilliseconds))
                {
                    return new Timeout(networkReadTimeoutMilliseconds);
                }
                else
                {
                    return DefaultTimeout;
                }
            }
        }

        public Timeout NetworkWriteTimeout
        {
            get
            {
                int networkWriteTimeoutMilliseconds;
                if (int.TryParse(this.NetworkWriteTimeoutProperty, out networkWriteTimeoutMilliseconds))
                {
                    return new Timeout(networkWriteTimeoutMilliseconds);
                }
                else
                {
                    return DefaultTimeout;
                }
            }
        }

        public Timeout NetworkConnectTimeout
        {
            get
            {
                int networkConnectTimeoutMilliseconds;
                if (int.TryParse(this.NetworkConnectTimeoutProperty, out networkConnectTimeoutMilliseconds))
                {
                    return new Timeout(networkConnectTimeoutMilliseconds);
                }
                else
                {
                    return DefaultTimeout;
                }
            }
        }

        [ConfigurationProperty("networkReadTimeout", DefaultValue = "4000", IsRequired = false)]
        private string NetworkReadTimeoutProperty
        {
            get { return (string)this["networkReadTimeout"]; }
            set { this["networkReadTimeout"] = value; }
        }

        [ConfigurationProperty("networkWriteTimeout", DefaultValue = "4000", IsRequired = false)]
        private string NetworkWriteTimeoutProperty
        {
            get { return (string)this["networkWriteTimeout"]; }
            set { this["networkWriteTimeout"] = value; }
        }

        [ConfigurationProperty("networkConnectTimeout", DefaultValue = "4000", IsRequired = false)]
        private string NetworkConnectTimeoutProperty
        {
            get { return (string)this["networkConnectTimeout"]; }
            set { this["networkConnectTimeout"] = value; }
        }
    }
}