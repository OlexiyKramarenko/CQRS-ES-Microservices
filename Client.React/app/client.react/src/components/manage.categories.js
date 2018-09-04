import React from 'react';
import { Link } from 'react-router-dom';
import { fetchCategories, deleteCategory } from '../actions/categories';
import { connect } from 'react-redux';

class ManageCategories extends React.Component {

    componentDidMount() {
        this.props.fetchCategories();        
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
                                        <Link to={`/manage_categories/${item.id}`}>Manage Articles</Link>
                                    </td>
                                    <td>
                                        <a onClick={() => this.props.deleteCategory(item.id)}>Delete</a>
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
        categories : state.categoriesReducer.categories ? 
                     state.categoriesReducer.categories : 
                     []
    }
}

export default connect(mapStateToProps, { fetchCategories, deleteCategory })(ManageCategories);
