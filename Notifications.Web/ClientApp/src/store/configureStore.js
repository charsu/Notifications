import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import * as Notifications from './Notifications';

const signalR = require("@aspnet/signalr");

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/notificationsHub")
    .build();

export default function configureStore(history, initialState) {
    const reducers = {
        notifications: Notifications.reducer
    };

    const middleware = [
        thunk,
        routerMiddleware(history)
    ];

    // In development, use the browser's Redux dev tools extension if installed
    const enhancers = [];
    const isDevelopment = process.env.NODE_ENV === 'development';
    if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
        enhancers.push(window.devToolsExtension());
    }

    const rootReducer = combineReducers({
        ...reducers,
        routing: routerReducer
    });

    var store = createStore(
        rootReducer,
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
    );

    signalRRegisterCommands(store);
    return store;
}


export function signalRRegisterCommands(store) {
    connection.on('BroadcastNotification', function (userId, userNotification) {
        store.dispatch({
            type: 'ADD_USER_NOTIFICATIONS',
            payload: { userId, userNotification }
        })
    });

    connection.start();
}
