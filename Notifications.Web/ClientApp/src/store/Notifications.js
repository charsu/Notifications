const requestNotificationsType = 'REQUEST_USER_NOTIFICATIONS';
const receiveNotificationsType = 'RECEIVE_USER_NOTIFICATIONS';
const initialState = { userId: 1, isLoading: false };

export const actionCreators = {
    requestNotifications: userId => async (dispatch, getState) => {
        if (getState().notifications.isLoading) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestNotificationsType, userId });

        const url = `api/Notifications/${userId}`;
        const response = await fetch(url);
        const notifications = await response.json();

        dispatch({ type: receiveNotificationsType, userId, notifications });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestNotificationsType) {
        return {
            ...state,
            isLoading: true
        };
    }

    if (action.type === receiveNotificationsType) {
        return {
            ...state,
            notifications: action.notifications,
            isLoading: false
        };
    }

    return state;
};
