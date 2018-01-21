import React from 'react';
import PhoneCallHistoryRow from './PhonecallHistoryRow';

export default class PhoneCallHistoryList extends React.Component 
{
    render() {
        return 
            <div>
                <div className="row"><PhoneCallHistoryRow></PhoneCallHistoryRow></div>
                <div className="row"><PhoneCallHistoryRow /><PhoneCallHistoryRow /></div>
                <div className="row"><PhoneCallHistoryRow /><PhoneCallHistoryRow /></div>
            </div>;
    }
}