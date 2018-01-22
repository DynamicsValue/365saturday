import React from 'react';
import PhoneCallHistoryRow from './PhonecallHistoryRow';
import PhoneCallHistoryRowModel from '../models/PhoneCallHistoryRowModel';

export default class PhoneCallHistoryList extends React.Component 
{
    render() {
        var history01 = new PhoneCallHistoryRowModel('1', 'Leo', 'Messi', new Date());
        var history02 = new PhoneCallHistoryRowModel('2', 'Xavi', 'Hernandez', new Date());
        
        const rows = [history01, history02];
        const listItems = rows.map((m) =>
            <PhoneCallHistoryRow key={m.id} model={m}></PhoneCallHistoryRow>
        );

        return (
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Last Call Date</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {listItems}
                </tbody>
            </table>
        );
    }
}