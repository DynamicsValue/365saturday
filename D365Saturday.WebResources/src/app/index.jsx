﻿//console.log('Hello World!');

import React from 'react';
import { render } from 'react-dom';

class App extends React.Component 
{
    render() {
        return <p> Hello React project </p>;
    }
}

render(<App />, document.getElementById('app'));