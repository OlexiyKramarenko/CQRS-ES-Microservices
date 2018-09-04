import React from 'react';
import { Link } from 'react-router-dom';

const CategoriesList = ({ categories }) => {

    const emptyMessage = (
        <p>----------------</p>
    );
  
    const categoriesList = (
        <div>
        {
            categories.map((item) =>                
                    <div className="category-item" key = {item.id}>
                        <Link to={`/categories/${item.id}`}>{item.title}</Link> 
                        <br /><p> {item.description}</p>
                    </div>)
        }
        </div>
    );

    return(
        <div>
            { categories.length === 0 ? emptyMessage : categoriesList }
        </div>
    );
}


export default CategoriesList;