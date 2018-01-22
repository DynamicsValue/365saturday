
//Retrieves all phoneCall history records for a given number
import WebApiClient from "./WebApiClient";

export default class PhoneCallHistoryUtils  
{
    constructor() {
        WebApiClient.ApiVersion = "9.0";
        WebApiClient.ReturnAllPages = true;
    }

    /**
     * @param {string} phoneNumber Incoming call number
     * @param {function} callback Callback function to return a list
     */
    loadHistoryForPhoneNumber(phoneNumber, callback) 
    {
        var request = {
            entityName: "ultra_phonecallhistory",
            queryParams: "?$select=ultra_contactid,ultra_lastcalldate&$orderby=ultra_lastcalldate desc&$filter=ultra_phonenumber eq '" + phoneNumber + "'"
        };

        WebApiClient.Retrieve(request)
            .then(function(response){
                if(callback) {
                    
                }
            })
            .catch(function(error) {
                // Handle error
            });
    }
}