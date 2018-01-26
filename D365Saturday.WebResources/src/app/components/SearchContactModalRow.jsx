import React from 'react';

export default class SearchContactModalRow extends React.Component 
{
    constructor(props) {
        super(props);
    }
    render() {

        const model = this.props.model;

        return (
            <tr>
                <td>{model.firstName}</td>
                <td>{model.lastName}</td>
                <td>
                    <button className="btn btn-primary">Select</button>
                </td>
            </tr>
        );
    }
    
}