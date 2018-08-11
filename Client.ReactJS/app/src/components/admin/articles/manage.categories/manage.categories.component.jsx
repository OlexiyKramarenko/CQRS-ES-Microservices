import React from 'react';
import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';
import { manageCategories, deleteCategory } from '../../../../actions/articles';
import { connect } from 'react-redux';

class ManageCategories extends React.Component {

    componentDidMount() {
        this.props.manageCategories();
    }

    render() {
  
        return (
            <table className="list">
                <tbody>
                {
                   this.props.categories.map(function (item, i) {
                      return <tr key={i}>
                            <td>
                                <b>{item.title}</b>
                                <br />
                                {item.description}
                            </td>
                            <td>
                                <NavLink to={`/manage_articles/${item.id}`}>Manage Articles</NavLink>
                            </td>
                            <td>
                                <span onClick={() => this.props.deleteCategory(item.id)}>Delete</span>
                            </td>  
                        </tr>
                    })
                }
                </tbody>
            </table>
        )
    }
}

function mapStateToProps(state) {
    return {
        categories: !state.articles.categories ? [] : state.articles.categories
    }
}

export default connect(mapStateToProps, { manageCategories, deleteCategory })(ManageCategories);
