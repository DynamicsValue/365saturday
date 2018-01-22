import React from 'react';

export default class PhoneCallHistoryRow extends React.Component 
{
    render() {

        const model = this.props.model;

        return (
            <tr>
                <td>{model.firstName}</td>
                <td>{model.lastName}</td>
                <td>{model.lastCallDate.toLocaleDateString()}</td>
                <td>
                    <button className="btn btn-primary">Select...</button>
                </td>
            </tr>
        );
    }
}