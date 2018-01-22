import React from 'react';

export default class PhoneCallHistoryRowModel extends React.Component 
{
    constructor(id, firstName, lastName, lastCallDate) {
        super();
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.lastCallDate = lastCallDate;
    }
}