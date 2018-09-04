import React from 'react';
import { connect } from 'react-redux';
import './categories.page.css';
import { fetchCategories } from  '../actions/categories';
import CategoriesList from './categories.list';

class CategoriesPage extends React.Component {

    componentDidMount() {
        this.props.fetchCategories();        
    }

    render() {
        
        return (
            <div>
                <h3>Article categories</h3>
                <div>Click on the title of the category for which you want to browse the articles:</div>
                <br />
                <div id="order-summary">
                     <CategoriesList categories = { this.props.categories } /> 
                </div>
            </div>
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

export default connect(mapStateToProps, { fetchCategories } )(CategoriesPage); 