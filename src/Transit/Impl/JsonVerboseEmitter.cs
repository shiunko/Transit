﻿// Copyright © 2014 Rick  All Rights Reserved.
//
// This code is a C# port of the Java version created and maintained by Cognitect, therefore
//
// Copyright © 2014 Cognitect. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS-IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Transit.Impl
{
    /// <summary>
    /// Represents a JSON verbose emitter.
    /// </summary>
    internal class JsonVerboseEmitter : JsonEmitter
    {
        public JsonVerboseEmitter(JsonWriter jsonWriter, IImmutableDictionary<Type, IWriteHandler> handlers)
            : base(jsonWriter, handlers)
        {
        }

        public override void EmitString(string prefix, string tag, string s, bool asDictionaryKey, WriteCache cache)
        {
            string outString = cache.CacheWrite(Util.MaybePrefix(prefix, tag, s), asDictionaryKey);
            if (asDictionaryKey)
                jsonWriter.WritePropertyName(outString);
            else
                jsonWriter.WriteValue(outString);
        }

        protected override void EmitTagged(string t, object obj, bool ignored, WriteCache cache)
        {
            EmitDictionaryStart(1L);
            EmitString(Constants.EscTag, t, "", true, cache);
            Marshal(obj, false, cache);
            EmitDictionaryEnd();
        }

        protected override void EmitDictionary(IEnumerable<KeyValuePair<object, object>> keyValuePairs, 
            bool ignored, WriteCache cache)
        {
            long sz = keyValuePairs.Count();

            EmitDictionaryStart(sz);
            foreach (KeyValuePair<object, object> item in keyValuePairs)
            {
                Marshal(item.Key, true, cache);
                Marshal(item.Value, false, cache);
            }
            EmitDictionaryEnd();
        }
    }
}
