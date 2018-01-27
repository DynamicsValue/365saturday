var WebApiClient = require("./WebApiClient");

(function (exports) {

    WebApiClient.ApiVersion = "9.0";
    WebApiClient.ReturnAllPages = true;

    exports.createContact = function(contactData, callback) 
    {
        //Check if contact exists or not and create a new one based on that...
        var request = {
            entityName: "contact",
            entity: {firstname: contactData.firstName, lastname: contactData.lastName}
        };

        WebApiClient.Create(request)
            .then(function(response){
                if(callback)
                    callback(response);
            })
            .catch(function(error) {
                // Handle error
            });
    };

    exports.getAllContacts = function(callback) {
        var request = {
            entityName: "contact",
            queryParams: "?$select=firstname,lastname"
        };

        WebApiClient.Retrieve(request)
            .then(function(response){
                if(callback) {
                    callback(response);
                }
            })
            .catch(function(error) {
                // Handle error
            });
    };
})(typeof exports === 'undefined' ? this['ContactUtils'] = {} : exports);