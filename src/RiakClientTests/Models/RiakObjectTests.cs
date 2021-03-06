// <copyright file="RiakObjectTests.cs" company="Basho Technologies, Inc.">
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

namespace RiakClientTests.Models
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using RiakClient.Exceptions;
    using RiakClient.Models;

    [TestFixture]
    public class RiakObjectTests
    {
        private const string Bucket = "bucket";
        private const string Key = "key";

        [Test]
        public void RiakObject_RequiresNonNullNonEmptyBucketName()
        {
            Assert.Catch<ArgumentOutOfRangeException>(
                () => new RiakObject((string)null, Key, "value"),
                "Expected ArgumentOutOfRangeException");
        }

        [Test]
        public void RiakObjectId_RequiresNonNullNonEmptyBucketName()
        {
            Assert.Catch<ArgumentOutOfRangeException>(
                () => new RiakObjectId((string)null, Key),
                "Expected ArgumentOutOfRangeException");
        }

        [Test]
        public void RiakObject_RequiresNonNullObjectId()
        {
            Assert.Catch<ArgumentNullException>(
                () => new RiakObject((RiakObjectId)null, Key, "value"),
                "Expected ArgumentOutOfRangeException");
        }

        [Test]
        public void ToRiakObjectIdProducesAValidRiakObjectId()
        {
            var riakObject = new RiakObject(Bucket, Key, "value");
            var riakObjectId = riakObject.ToRiakObjectId();

            riakObjectId.Bucket.ShouldEqual(Bucket);
            riakObjectId.Key.ShouldEqual(Key);
        }

        [Test]
        public void RiakIndexNameManglingIsHandledAutomatically()
        {
            var riakObject = new RiakObject(Bucket, Key, "value");
            riakObject.BinIndex("name").Set("jeremiah");
            riakObject.BinIndex("state_bin").Set("oregon");
            riakObject.IntIndex("age").Add(32);
            riakObject.IntIndex("cats_int").Add(2);

            riakObject.BinIndexes.Values.Select(v => v.RiakIndexName).Contains("name").ShouldBeFalse();
            riakObject.BinIndexes.Values.Select(v => v.RiakIndexName).Contains("name_bin").ShouldBeTrue();
            riakObject.BinIndexes.Values.Select(v => v.RiakIndexName).Contains("state").ShouldBeFalse();
            riakObject.BinIndexes.Values.Select(v => v.RiakIndexName).Contains("state_bin").ShouldBeFalse();
            riakObject.BinIndexes.Values.Select(v => v.RiakIndexName).Contains("state_bin_bin").ShouldBeTrue();

            riakObject.IntIndexes.Values.Select(v => v.RiakIndexName).Contains("age").ShouldBeFalse();
            riakObject.IntIndexes.Values.Select(v => v.RiakIndexName).Contains("age_int").ShouldBeTrue();
            riakObject.IntIndexes.Values.Select(v => v.RiakIndexName).Contains("cats").ShouldBeFalse();
            riakObject.IntIndexes.Values.Select(v => v.RiakIndexName).Contains("cats_int").ShouldBeFalse();
            riakObject.IntIndexes.Values.Select(v => v.RiakIndexName).Contains("cats_int_int").ShouldBeTrue();
        }

        [Test]
        public void RiakIndexingSupportsMultipleValuesCorrectly()
        {
            var riakObject = new RiakObject(Bucket, Key, "value");

            riakObject.BinIndex("jobs").Set("dogsbody");
            riakObject.BinIndex("jobs").Values.Count.ShouldEqual(1);

            riakObject.BinIndex("jobs").Add("toilet cleaner", "president", "juggler");
            riakObject.BinIndex("jobs").Values.Count.ShouldEqual(4);

            riakObject.BinIndex("jobs").Remove("dogsbody", "juggler");
            riakObject.BinIndex("jobs").Values.Count.ShouldEqual(2);

            riakObject.BinIndex("jobs").Set("general", "engineer", "cook");
            riakObject.BinIndex("jobs").Values.Count.ShouldEqual(3);
            riakObject.BinIndex("jobs").Values.Contains("general").ShouldBeTrue();

            riakObject.BinIndex("jobs").Clear();
            riakObject.BinIndex("jobs").Values.Count.ShouldEqual(0);

            riakObject.BinIndex("jobs").Delete();
            riakObject.BinIndexes.ContainsKey("jobs").ShouldBeFalse();

            riakObject.IntIndex("years").Set(10);
            riakObject.IntIndex("years").Values.Count.ShouldEqual(1);

            riakObject.IntIndex("years").Add(20, 40, 999);
            riakObject.IntIndex("years").Values.Count.ShouldEqual(4);

            riakObject.IntIndex("years").Remove(40, 999);
            riakObject.IntIndex("years").Values.Count.ShouldEqual(2);

            riakObject.IntIndex("years").Set(51, 52, 53);
            riakObject.IntIndex("years").Values.Count.ShouldEqual(3);
            riakObject.IntIndex("years").Values.Contains(52).ShouldBeTrue();

            riakObject.IntIndex("years").Clear();
            riakObject.IntIndex("years").Values.Count.ShouldEqual(0);

            riakObject.IntIndex("years").Delete();
            riakObject.IntIndexes.ContainsKey("years").ShouldBeFalse();
        }
        
        [Test]
        public void VectorClocksCanBeSetThroughInterface()
        {
            var vclock = new byte[] { 0, 1, 2, 3, 4, 5 };

            var riakObject = new RiakObject(Bucket, Key, "value");
            ((IWriteableVClock)riakObject).SetVClock(vclock);

            riakObject.VectorClock.ShouldEqual(vclock);
        }

        [Test]
        public void SecondaryIndexesAreForcedToLowerCase()
        {
            var obj = new RiakObject(Bucket, Key);

            obj.BinIndex("UPPERCASE").Set("foo");
            obj.IntIndex("MixedCase").Set(10);

            obj.BinIndexes.ContainsKey("uppercase").ShouldBeTrue();
            obj.IntIndexes.ContainsKey("mixedcase").ShouldBeTrue();

            obj.BinIndex("UPPERCASE").Values.First().ShouldEqual("foo");
            obj.BinIndex("uppercase").Values.First().ShouldEqual("foo");
            obj.IntIndex("MixedCase").Values.First().ShouldEqual(10);
            obj.IntIndex("mixedcase").Values.First().ShouldEqual(10);
        }

        [Test]
        public void ExceptionThrownWhenMixingLinkWalkingAndBucketTypes()
        {
            var oldId = new RiakObjectId(Bucket, Key);
            var newId = new RiakObjectId("Type", Bucket, Key);
            
            var oldObject = new RiakObject(oldId, "value");
            var newObject = new RiakObject(newId, "value");

            const string LinkTag = "badlinktag";

#pragma warning disable 618
            Assert.Throws<RiakUnsupportedException>(
                () => oldObject.LinkTo(newId, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => oldObject.LinkTo(newObject, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => oldObject.RemoveLink(newId, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => oldObject.RemoveLink(newObject, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => oldObject.RemoveLinks(newId),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => oldObject.RemoveLinks(newObject),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => newObject.LinkTo(oldId, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => newObject.LinkTo(oldObject, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => newObject.RemoveLink(oldId, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => newObject.RemoveLink(oldObject, LinkTag),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => newObject.RemoveLinks(oldId),
                "RiakUnsupportedException was expected.");
            
            Assert.Throws<RiakUnsupportedException>(
                () => newObject.RemoveLinks(oldObject),
                "RiakUnsupportedException was expected.");

            Assert.DoesNotThrow(() => oldObject.LinkTo(oldId, LinkTag));
            Assert.DoesNotThrow(() => oldObject.LinkTo(oldObject, LinkTag));
            Assert.DoesNotThrow(() => oldObject.RemoveLink(oldId, LinkTag));
            Assert.DoesNotThrow(() => oldObject.RemoveLink(oldObject, LinkTag));
            Assert.DoesNotThrow(() => oldObject.RemoveLinks(oldId));
            Assert.DoesNotThrow(() => oldObject.RemoveLinks(oldObject));
#pragma warning restore 618
        }
    }
}
