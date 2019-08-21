﻿using ComPact.Builders.V3;
using ComPact.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComPact.UnitTests.Builders
{
    [TestClass]
    public class ResponseBodyV3DslTests
    {
        [TestMethod]
        public void Integer()
        {
            var pactJsonBody = Pact.ResponseBody.With(Some.Integer.Like(1).Named("number")).ToJToken();

            var expectedObject = new { number = 1 };

            Assert.AreEqual(JsonConvert.SerializeObject(expectedObject), JsonConvert.SerializeObject(pactJsonBody));
        }

        [TestMethod]
        public void RulesForInteger()
        {
            var pactJsonElement = Some.Integer.Like(1);

            var matchingRules = new Dictionary<string, Matcher>();
            pactJsonElement.AddMatchingRules(matchingRules, "$");

            Assert.AreEqual("{\"$\":{\"match\":\"integer\"}}", JsonConvert.SerializeObject(matchingRules, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
