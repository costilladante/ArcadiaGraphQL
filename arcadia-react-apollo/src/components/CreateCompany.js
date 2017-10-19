import React, { Component } from 'react';
import { graphql, gql } from 'react-apollo';

class CreateCompany extends Component {

    state = {
        name: ''
    }

    render() {
        return (
            <div>
                <input
                    value={this.state.name}
                    onChange={(e) => this.setState({ name: e.target.value })}
                    type='text'
                    placeholder='The name of the new company'
                />
                <button
                    onClick={() => this._createCompany()}
                >
                    Submit
        </button>
            </div>
        )
    }

    _createCompany = async () => {
        const { name } = this.state;
        await this.props.createCompanyMutation(
            {
                variables: {
                    company: {
                        name: name
                    }
                }
            }
        );
        this.props.history.push('/');
    }
}

const CREATE_COMPANY_MUTATION = gql`
    mutation CreateCompanyMutation($company: CompanyInput!){
        createCompany(
            company: $company
        ) {
            id
            name
        }
    }
`

export default graphql(CREATE_COMPANY_MUTATION, { name: 'createCompanyMutation' })(CreateCompany)