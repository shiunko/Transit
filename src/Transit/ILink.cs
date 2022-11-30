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

using System;
using System.Collections.Generic;

namespace Transit
{
    /// <summary>
    /// Represents a hypermedia link, as per http://amundsen.com/media-types/collection/format/#arrays-links
    /// </summary>
    public interface ILink
    {
        /// <summary>
        /// Gets the href.
        /// </summary>
        /// <value>
        /// The href.
        /// </value>
        Uri Href { get; }

        /// <summary>
        /// Gets the rel.
        /// </summary>
        /// <value>
        /// The rel.
        /// </value>
        string Rel { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the prompt.
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        string Prompt { get; }

        /// <summary>
        /// Gets the render semantic
        /// </summary>
        /// <value>
        /// The render.
        /// </value>
        string Render { get; }

        /// <summary>
        /// Converts the link to a dictionary.
        /// </summary>
        /// <returns>The dictionary.</returns>
        IDictionary<string, object> ToDictionary();
    }
}
