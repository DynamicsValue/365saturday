import React from 'react';
import SearchContactModalRow from './SearchContactModalRow';
import SearhContactRowModel from '../models/SearchContactRowModel';

export default class SearchContactModal extends React.Component 
{
    constructor(props) {
        super(props);

        this.state = {
            rows: []
        };
    }

    addNewContact() {
        alert('add new');
    }
    render() {
        var c1 = new SearhContactRowModel('1', 'Leo', 'Messi');
        var c2 = new SearhContactRowModel('2', 'Xavi', 'Hernandez');

        //const rows = this.state.rows;
        const rows = [c1, c2];

        const listItems = rows.map((m) =>
            <SearchContactModalRow key={m.id} model={m}></SearchContactModalRow>
        );

        return (
            <div className="modal fade" tabIndex="-1" role="dialog" id="searchContactModal">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                    <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 className="modal-title">Seach Contact</h4>
                    </div>
                    <div className="modal-body">
                        <button className="btn btn-primary" onClick={this.addNewContact}>Add New...</button>
                        <table className="table table-striped">
                            <thead>
                                <tr>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                {listItems}
                            </tbody>
                        </table>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                    </div>
                </div>
            </div>
        );
    }
}