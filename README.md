# 365saturday Workshop
365 saturday test automation + CI/CD workshop repo

## 0. Background
 Let's say a user calls his bank customer service because he wants to know more about of one the bank's banking products and / or services. Dynamics CRM is integrated with a Cisco CTI / Middleware so whenever a phonecall is received, a window opens up automatically in CRM with details about the phonecall, as well as the history of all the contacts who called from that number previously, so the operator can pick an existing one or create a new one. Either way, a new case is created where the operator will enter some information about the call. At the end of the call, the case might be closed if they operator could answer what the user requested, or still open if the call needs a follow up.

## 1. Scenario steps

1. Incoming phonecall to open a list of contacts matching that number. This could be a custom web resource that would display a phonecall history entity, via Web API, to pull that information and display it on the web resource. Web API  + odata JS Unit testing

2.  During the conversation, operator identifies the caller and picks up an existing contact or creates a new one, (because, for instance, the same phone number might be reused by many different people over time). A plugin then fires to create a new entry in the phonecall history entity for that contact and phonenumber, so that it will be displayed the next time he calls.  Plugin Unit testing.

3. Upon selection of a contact, either new or existing, a new case is created and opened automatically. This would be again javascript. If time allows, we could also show some unit testing for the form object.

4. Let's say the case isn't resolved. A waiting workflow can be triggered to generate an outgoing phonecall to follow up with the user in X number of days if the case is still open. Code activity unit testing.

## 2. Workshop schedule

* Intro
* Entity Model & Solution Overview
* Plugin Unit Testing
* Javascript Unit Testing
* Build definition / CI
* Integration Testing
* Release definition / CD
* UI Testing
* Wrap up 

## 3. Entity Model & Solution Overview

### 3.1. Entity Model

* ultra_phonecallhistory:  Entity used to aggregate phone call records by phone number and contact.
* ultra_systemparameter:  Entity used to some system-wide configuration data

### 3.2. Solution Overview / Layout

Note: Restore any NuGet packages first. This will pull the SDKs and CoreTools (i.e. CrmSvcUtil.exe, SolutionPackager etc) automatically to the packages folder.

* D365Saturday.TypedEntities: Class library with the early bound entities needed by the plugins and unit test project. It will use crmsvcutil which can be downloaded from [NuGet](https://docs.microsoft.com/en-gb/dynamics365/customer-engagement/developer/download-tools-nuget).



