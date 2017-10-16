import React from 'react';
import ReactDOM from 'react-dom';
import './styles/index.css';
import App from './components/App';
import registerServiceWorker from './registerServiceWorker';
import { ApolloClient, ApolloProvider, createNetworkInterface } from 'react-apollo';

const arcadiaNetworkInterface = createNetworkInterface({
    uri: 'http://localhost:50844'
})

const client = new ApolloClient({
    networkInterface: arcadiaNetworkInterface
})

ReactDOM.render(
    <ApolloProvider client={client}>
        <App />
    </ApolloProvider>,
    document.getElementById('root')
);


registerServiceWorker();
