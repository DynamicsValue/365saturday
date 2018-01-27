import React from 'react';
import SearchContactModalRow from './SearchContactModalRow';
import SearhContactRowModel from '../models/SearchContactRowModel';
import NewContactDetails from './NewContactDetails';
import ContactUtils from '../utils/ContactUtils';

export default class SearchContactModal extends React.Component 
{
    constructor(props) {
        super(props);

        this.state = {
            isEditing: false,
            rows: []
        };
    }

    componentDidMount() {
        this.refresh();
    }
    addNewContact() {
        const currentState = this.state;
        this.setState({
            isEditing: true,
            rows: currentState.rows
        });
    }
    cancelEditing() {
        const currentState = this.state;
        this.setState({
            isEditing: false,
            rows: currentState.rows
        });
    }

    refresh() {
        //load contacts
        var self = this;
        ContactUtils.getAllContacts(function(result) {
            let contacts = [];
            for(var i=0; i < result.value.length; i++) {
                let c = result.value[i];
                contacts.push(new SearhContactRowModel(c.contactid, c.firstname, c.lastname) )
            }
            self.setState({
                isEditing: false,
                rows: contacts
            })
        });
    }
    render() {
        //var c1 = new SearhContactRowModel('1', 'Leo', 'Messi');
        //var c2 = new SearhContactRowModel('2', 'Xavi', 'Hernandez');

        const rows = this.state.rows;
        const phoneNumber = this.props.phoneNumber;

        //const rows = [c1, c2];

        const listItems = rows.map((m) =>
            <SearchContactModalRow key={m.id} model={m} phoneNumber={phoneNumber}></SearchContactModalRow>
        );

        let contactDetails = <br />;
        if(this.state.isEditing) {
            contactDetails = <NewContactDetails parent={this} />;
        }
        
        return (
            <div>
                
                <div className="modal fade" tabIndex="-1" role="dialog" id="searchContactModal">
                    <div className="modal-dialog" role="document">
                        <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 className="modal-title">Lookup Contact</h4>
                        </div>
                        <div className="modal-body">
                            <button className="btn btn-primary" onClick={this.addNewContact.bind(this)}>Add New...</button>
                            <br />
                            {contactDetails}
                            <br />
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
            </div>
        );
    }
}