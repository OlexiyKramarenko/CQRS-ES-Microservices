import React from 'react';
import { connect } from 'react-redux';
import { fetchArticles } from  '../actions/articles';
import { Link } from 'react-router-dom';
import './articles.page.css';

class ArticlesPage extends React.Component {
    
    componentDidMount() {
        const categoryId = this.props.match.params.id;
        this.props.fetchArticles(categoryId);        
    }

    render() {
       
        return (
            <div id="order-summary">
                {
                    this.props.articles.map(function (item) {
                        return (
                            <div className="listing-item" key={item.id}>
                                <Link to={`/articles/${item.id}`} className="article-link">
                                    <h3>{item.title}</h3>
                                </Link>
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
 
function mapStateToProps(state) {
    return {
        articles : state.articlesReducer.articles ?
                   state.articlesReducer.articles :
                   []
    }
}

export default connect(mapStateToProps, { fetchArticles } )(ArticlesPage); 