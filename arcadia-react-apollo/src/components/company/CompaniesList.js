import React, { Component } from 'react';
import Company from './Company';
import { graphql, gql } from 'react-apollo';

class CompaniesList extends Component {
    render() {
        if (this.props.allCompaniesQuery && this.props.allCompaniesQuery.loading) {
            return <div>Loading companies... </div>
        }

        if (this.props.allCompaniesQuery && this.props.allCompaniesQuery.error) {
            return <div>Oh noes! Something went wrong!</div>
        }

        const companiesToRender = this.props.allCompaniesQuery.allCompanies;

        return (
            <div>
                {companiesToRender.map(company => (
                    <Company key={company.id} company={company} />
                ))}
            </div>
        )
    }
}

export const ALL_COMPANIES_QUERY = gql`
    query AllCompanies {
        allCompanies {
            id,
            name
        }
    }
`

export default graphql(ALL_COMPANIES_QUERY, { name: 'allCompaniesQuery' })(CompaniesList);