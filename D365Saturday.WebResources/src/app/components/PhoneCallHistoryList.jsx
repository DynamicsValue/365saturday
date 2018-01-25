import React from 'react';
import PhoneCallHistoryRow from './PhonecallHistoryRow';
import PhoneCallHistoryRowModel from '../models/PhoneCallHistoryRowModel';
import PhoneCallHistoryUtils from '../utils/PhoneCallHistoryUtils';

export default class PhoneCallHistoryList extends React.Component 
{
    constructor(props) {
        super(props);
        this.state = {
            rows: []
        };
    }
    componentDidMount() 
    {
        PhoneCallHistoryUtils.loadHistoryForPhoneNumber(this.props.phoneNumber, function(response) {

        });
    }
    render() {
        var history01 = new PhoneCallHistoryRowModel('1', 'Leo', 'Messi', new Date());
        var history02 = new PhoneCallHistoryRowModel('2', 'Xavi', 'Hernandez', new Date());
        
        //const rows = [history01, history02];
        const rows = this.state.rows;
        
        const listItems = rows.map((m) =>
            <PhoneCallHistoryRow key={m.id} model={m}></PhoneCallHistoryRow>
        );

        if(rows.length == 0) {
            return (
                <p>No history records found for the above phone number.</p>
            );
        }
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