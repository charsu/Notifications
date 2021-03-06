import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Notifications from './components/Notifications';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/notifications' component={Notifications} />
    </Layout>
);
