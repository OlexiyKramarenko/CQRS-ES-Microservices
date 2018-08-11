import React from 'react';
import { NavLink } from 'react-router-dom';
import './manage.articles.style.css';
import { manageArticles, deleteArticle } from '../../../../actions/articles';
import { connect } from 'react-redux';

class ManageArticles extends React.Component {

    componentDidMount() {
        const categoryId= this.props.match.params.id;
        this.props.manageArticles(categoryId);
    }

    render() {
 
        return (
            <div>
                {
                     this.props.articles.map(function (item,i) {
                     return   <div className="listing-item" key={i}>
                            <div className="edit_delete_links">
                                <NavLink to={`/edit_article/${item.id}`}>edit</NavLink>&nbsp;&nbsp;
                                <span onClick={() => this.props.deleteArticle(item.id)}>delete</span>
                            </div>

                            <NavLink to={`/show_article/${item.id}`} className="article-link">
                                <h3>{item.title}</h3>
                            </NavLink>

                            <b>Posted by:</b>{item.addedBy}<br />
                            <b>Abstract:</b>{item.abstract}<br />
                        </div>
                    })
                }
            </div>
        );
    }
}


function mapStateToProps(state) {
    return {
        articles: !state.articles.articles ? [] : state.articles.articles
    }
}

export default connect(mapStateToProps, { manageArticles, deleteArticle })(ManageArticles);