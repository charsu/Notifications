import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Notifications';

class Notifications extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        //// This method is called when the route parameters change
        //this.ensureDataFetched();
    }

    ensureDataFetched() {
        const { userId } = this.props;
        this.props.requestNotifications(userId);
    }

    renderNotifications = notifications => {
        return (
            <ul>
                {notifications.map((item, i) => (<li key={item.id}>
                    <div>{item.title}</div>
                    <div>{item.body}</div>
                </li>))}
            </ul>);
    }

    render() {
        const { notifications } = this.props;

        return (
            <div>
                <h1>Notifications</h1>

                <p>Hello user {this.props.userId}</p>

                {notifications && this.renderNotifications(notifications)}

            </div>
        );
    }
}

export default connect(
    state => state.notifications,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Notifications);
