import React from 'react';

export default class SearhContactRowModel extends React.Component 
{
    constructor(id, firstName, lastName) {
        super();
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
    }
}