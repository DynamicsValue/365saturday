//console.log('Hello World!');

import React from 'react';
import { render } from 'react-dom';
import PhoneCallHistoryList from './components/PhoneCallHistoryList';
import PhoneCallHeader from './components/PhoneCallHeader';

class App extends React.Component 
{
    render() {
        let phoneNumber = "+44 666 666 666";

        return <div className="container">
                <div className="col-md-12">
                    <div className="row">
                        <div className="col-md-12">
                            <PhoneCallHeader phoneNumber={phoneNumber}></PhoneCallHeader>
                        </div>
                    </div>
                </div>
                <div className="col-md-12">
                    <div className="row">
                        <div className="col-md-12">
                            <PhoneCallHistoryList phoneNumber={phoneNumber}></PhoneCallHistoryList>
                        </div>
                    </div>
                </div>
            </div>;
            
    }
}

render(<App />, document.getElementById('app'));