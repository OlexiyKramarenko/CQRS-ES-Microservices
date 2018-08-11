import React from 'react';
import { Link } from 'react-router-dom';
import './show.categories.style.css';

class ShowCategories extends React.Component {
    render() {

        const categories = [{ id: 1, title: "one" }, { id: 2, title: "two" }];

        return (
            <div>
                <h3>Article categories</h3>
                <div>Click on the title of the category for which you want to browse the articles:</div>
                <br />
                <div id="order-summary">
                    <div>
                        {
                            categories.map(function (item) {
                                return (
                                    <div className="category-item" key={item.id}>
                                        <Link to={`/browse_articles/${item.id}`}>{item.title}</Link>
                                        <br />
                                        <p> Description</p>
                                    </div>
                                )
                            })
                        }
                    </div>
                    <b>No categories to show</b>
                </div>
            </div>
        )
    }
}

export default ShowCategories; 
