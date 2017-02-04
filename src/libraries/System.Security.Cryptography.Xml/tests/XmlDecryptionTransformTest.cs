//
// Unit tests for XmlDecryptionTransform
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
//
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security.Cryptography.Xml;
using System.Xml;
using Xunit;

namespace MonoTests.System.Security.Cryptography.Xml
{

    public class UnprotectedXmlDecryptionTransform : XmlDecryptionTransform
    {
        public bool UnprotectedIsTargetElement(XmlElement inputElement, string idValue)
        {
            return base.IsTargetElement(inputElement, idValue);
        }
    }

    public class XmlDecryptionTransformTest
    {

        private UnprotectedXmlDecryptionTransform transform;
        public XmlDecryptionTransformTest()
        {
            transform = new UnprotectedXmlDecryptionTransform();
        }

        [Fact]
        public void IsTargetElement_XmlElementNull()
        {
            Assert.False(transform.UnprotectedIsTargetElement(null, "value"));
        }

        [Fact]
        public void IsTargetElement_StringNull()
        {
            XmlDocument doc = new XmlDocument();
            Assert.False(transform.UnprotectedIsTargetElement(doc.DocumentElement, null));
        }
    }
}

