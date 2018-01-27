import React from 'react';
import PhoneCallHistoryUtils from '../utils/PhoneCallHistoryUtils.js';

export default class SearchContactModalRow extends React.Component 
{
    constructor(props) {
        super(props);
    }

    selectContact() {
        const contactid = this.props.model.id;
        const phone = this.props.phoneNumber;

        PhoneCallHistoryUtils.createPhoneCallFor(contactid, phone, function(result) {
            if(result) {

            }
        });
    }
    render() {

        const model = this.props.model;

        return (
            <tr>
                <td>{model.firstName}</td>
                <td>{model.lastName}</td>
                <td>
                    <button className="btn btn-primary" onClick={this.selectContact.bind(this)}>Select</button>
                </td>
            </tr>
        );
    }
    
}