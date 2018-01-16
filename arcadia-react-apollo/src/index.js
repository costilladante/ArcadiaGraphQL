import React from 'react';
import ReactDOM from 'react-dom';
import './styles/index.css';
import App from './components/App';
import registerServiceWorker from './registerServiceWorker';
import { ApolloClient, ApolloProvider, createNetworkInterface } from 'react-apollo';
import { BrowserRouter } from 'react-router-dom';

const arcadiaNetworkInterface = createNetworkInterface({
    uri: 'http://localhost:50844/GraphQL/'
})

const client = new ApolloClient({
    networkInterface: arcadiaNetworkInterface
})

ReactDOM.render(
    <BrowserRouter>
    <ApolloProvider client={client}>
        <App />
    </ApolloProvider>
    </BrowserRouter>
    , document.getElementById('root')
);


registerServiceWorker();
