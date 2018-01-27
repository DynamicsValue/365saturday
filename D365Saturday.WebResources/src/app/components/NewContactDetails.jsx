import React from 'react';
import ContactUtils from '../utils/ContactUtils';

export default class NewContactDetails extends React.Component 
{
    constructor(props) {
        super(props);

        this.state = {
            firstName: '',
            lastName: ''
        };
    }
    componentDidMount() {

    }
    firstNameChanged(event) {
        this.setState({firstName: event.target.value});
    }
    lastNameChanged(event) {
        this.setState({lastName: event.target.value});
    }
    createContact() {
        var parent = this.parent;
        ContactUtils.createContact(this.state, function(result) {
            parent.refresh();
        });
    }
    render() {
        const parent = this.props.parent;

        return (
            <form>
                <div className="form-group">
                    <label htmlFor="firstName">First Name</label>
                    <input type="text" className="form-control" id="firstName" placeholder="Lionel" onChange={this.firstNameChanged.bind(this)} />
                </div>
                <div className="form-group">
                    <label htmlFor="lastName">Last Name</label>
                    <input type="text" className="form-control" id="lastName" placeholder="Messi" onChange={this.lastNameChanged.bind(this)} />
                </div>
                <div className="btn-group" role="group" aria-label="...">
                    <button type="button" className="btn btn-primary" onClick={this.createContact.bind(this)}>Save changes</button>
                    <button type="button" className="btn btn-default" onClick={parent.cancelEditing.bind(parent)}>Close</button>
                </div>
                
            </form>       
        );
    }
}