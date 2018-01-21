﻿/*global.XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;

var xrmFakedContext = require('../src/xrmFakedContext.js');
global.Xrm = xrmFakedContext.Xrm;

var WebApiClient = require('../webresources/WebApiClient.js');
var assert = require('chai').assert;
var Guid = require('guid');
*/

var assert = require('chai').assert;

describe("Web API", function () {
    it("testing", function() {
        assert.equal(true, true);

    });

    it("$select: it should retrieve fields specified in $select clause", function () {

        xrmFakedContext.initialize("accounts", [
            { id: Guid.create(), name: 'Company 1', revenue: 3000, other: "somevalue" },
            { id: Guid.create(), name: 'Company 2', revenue: 100001, other: "someothervalue" }
        ]);

        var bWasCalled = false;

        WebApiClient.retrieveMultiple("accounts?$select=name,revenue", function (data) {
            bWasCalled = true;
            assert.equal(data.value.length, 2); //2 records
            assert.equal(data.value[0].name, "Company 1"); 
            assert.equal(data.value[1].name, "Company 2"); 
            assert.equal(data.value[0].revenue, 3000);
            assert.equal(data.value[1].revenue, 100001); 
            assert.equal(data.value[0].other, undefined);
            assert.equal(data.value[1].other, undefined); 
        });

        assert.isTrue(bWasCalled);
    });
});
