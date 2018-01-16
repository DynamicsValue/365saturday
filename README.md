# 365saturday
365 saturday test automation + CI/CD workshop repo
=======================================================


Scenario steps
-----------------

    1. Incoming phonecall to open a list of contacts matching that number. This could be a custom web resource that would call a phone history entity, or the contacts entity directly, via Web API, to pull that information and display it on the web resource. Web API  + odata JS Unit testing

    2. Operator picks up an existing contact or creates a new one. Based on the initial conversation, the operator might pick an existing contact or create a new one (because, for instance, same phone number might be reused by many different people over time). Let's say a new one is created. A plugin then fires to create a new entry in the phone history entity for that contact and phonenumber, so that it will be displayed the next time he calls.  Plugin Unit testing.

    3. Upon selection of a contact, either new or existing, a new case is created and opened automatically. This would be again javascript. If time allows, we could also show some unit testing for the form object.

    4. Let's say the case isn't resolved. A waiting workflow can be triggered to generate an outgoing phonecall to follow up with the user in X number of days if the case is still open. Code activity unit testing.

