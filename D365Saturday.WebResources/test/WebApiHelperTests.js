

var PhoneCallHistoryUtils = require('../src/app/utils/PhoneCallHistoryUtils');
var assert = require('chai').assert;
var Guid = require('guid');
var egde = require('edge');

describe("WebApiHelper Tests", function () {

    var xrmFakedContext = require('fakexrmeasy.v9');
    xrmFakedContext.setProxyPath('../packages/FakeXrmEasy.EdgeProxy.v9.0.0.1/lib/net452', 'v9');
    
    it("Should_retrieve_phonecall_history_records_for_a_phonenumber", function(done) {

        //Arrange
        var contact1 = {id: Guid.create(), logicalName: "contact"};
        var contact2 = {id: Guid.create(), logicalName: "contact"};
        var phoneHistory1 = { id: Guid.create(), logicalName: "ultra_phonecallhistory", ultra_phonenumber: '+44666 666 666', ultra_contactid = contact1 };
        var phoneHistory2 = { id: Guid.create(), logicalName: "ultra_phonecallhistory", ultra_phonenumber: '+44777 666 666', ultra_contactid = contact2 };
        
        xrmFakedContext.initialize([
            contact1,
            contact2,
            phoneHistory1,
            phoneHistory2
        ]);

        PhoneCallHistoryUtils.loadHistoryForPhoneNumber('+44666 666 666', function(result) {
            assert.equal(result.value.length, 1); 
            assert.equal(result.value[0].ultra_phonenumber, "Company 1");
            assert.equal(result.value[0].ultra_contactid.id, contact1.id);

            done();
        });
    });

    
});