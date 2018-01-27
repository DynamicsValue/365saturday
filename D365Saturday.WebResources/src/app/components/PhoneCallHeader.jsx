import React from 'react';

import SearchContactModal from './SearchContactModal';

export default class PhoneCallHeader extends React.Component 
{
    constructor(props) 
    {
        super(props);
        this.state = {
            start: new Date(),
            elapsed: 0
        };
    }
    
    componentDidMount() {
        var self = this;
        this.timer = setInterval(function() {
            self.tick()
        }, 500); //Call tick every half second
    }

    componentWillUnmount() {
        clearInterval(this.timer);
    }

    tick() {
        this.setState({
            start: this.state.start,
            elapsed: new Date() - this.state.start
        });
    }

    showSearchContact() {
        $('#searchContactModal').modal('show');
    }
    render() {

        const phoneNumber = this.props.phoneNumber;

        var totalSeconds = this.state.elapsed / 1000;
        var totalHours = totalSeconds / 3600;
        var remainingSeconds = totalSeconds % 3600;
        var totalMinutes = remainingSeconds / 60;
        remainingSeconds = remainingSeconds % 60;
        
        var pad = "00";

        
        if (remainingSeconds >= 60) 
            remainingSeconds = 0;

        var hoursTemp = Math.floor(totalHours).toString();
        var minutesTemp = Math.floor(totalMinutes).toString();
        var secondsTemp = Math.floor(remainingSeconds).toString();

        const hours = pad.substring(0, pad.length - hoursTemp.length) + hoursTemp;
        const minutes = pad.substring(0, pad.length - minutesTemp.length) + minutesTemp;
        const seconds = pad.substring(0, pad.length - secondsTemp.length) + secondsTemp;

        return (
            <div>
                <div style={{paddingBottom: '40px'}} className="row">
                    <div className="col-md-4">
                        <h1>{phoneNumber}</h1>
                    </div>
                    <div className="col-md-4">
                        <h1 style={{textAlign: 'center'}}>{hours}:{minutes}:{seconds}</h1>
                    </div>
                    <div className="col-md-4">
                        <h1 style={{textAlign: 'right'}}>
                            <button className="btn btn-lg btn-success" onClick={this.showSearchContact}>Search Contact</button>
                        </h1>
                    </div>
                </div>
                <SearchContactModal phoneNumber={phoneNumber} />
            </div>
        );
    }

}