//console.log('Hello World!');

import React from 'react';
import { render } from 'react-dom';
import PhoneCallHistoryList from './components/PhoneCallHistoryList';
import PhoneCallHeader from './components/PhoneCallHeader';

class App extends React.Component 
{
    render() {
        return 
            <div>
                <p> Hello React project </p>
                <PhoneCallHeader></PhoneCallHeader>
                <PhoneCallHistoryList></PhoneCallHistoryList>
            </div>;
            
    }
}

render(<App />, document.getElementById('app'));