import React from 'react';
import { NavLink } from 'react-router-dom';
import './browse.articles.style.css';

class BrowseArticles extends React.Component {
    render() {

        const articles = [
            { id: 1, title: "ahahah", addedBy: "John", abstract: "..some text 1" },
            { id: 2, title: "hihihi", addedBy: "David", abstract: "..some text 2" }];

        return (
            <div id="order-summary">
                {
                    articles.map(function (item) {
                        return (
                            <div className="listing-item" key={item.id}>
                                <div className="edit_delete_links">
                                    <a>edit</a>&nbsp;&nbsp;
							<a>delete</a>
                                </div>
                                <NavLink to={`/show_article/${item.id}`} className="article-link">
                                    <h3>{item.title}</h3>
                                </NavLink>
                                <b>Posted by:</b>{item.addedBy}<br />
                                <b>Abstract:</b>{item.abstract}<br />
                            </div>
                        )
                    })
                }
            </div>
        )
    }
}

export default BrowseArticles; 

