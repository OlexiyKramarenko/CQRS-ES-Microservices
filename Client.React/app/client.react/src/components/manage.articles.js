import React from 'react';
import { Link } from 'react-router-dom';
import { fetchArticles, deleteArticle } from '../actions/articles';
import { connect } from 'react-redux';

class ManageArticles extends React.Component {

    componentDidMount() {
        this.props.fetchArticles();
    }

    render() {  
        return (
            <table className="list">
                <tbody>
                {
                   this.props.articles.map(function (item, i) {
                      return <tr key={i}>
                            <td>
                                <b>{item.title}</b>
                                <br />
                                <b>Posted by:</b>{item.addedBy}<br />
                                <b>Abstract:</b>{item.abstract}<br />
                            </td>
                            <td>
                                <Link to={`/article_form/${item.id}`}>Edit Article</Link>
                            </td>
                            <td>
                                <a onClick={() => this.props.deleteArticle(item.id)}>Delete</a>
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
        articles : state.articlesReducer.articles ?
                   state.articlesReducer.articles :
                   []
    }
}

export default connect(mapStateToProps, { fetchArticles, deleteArticle })(ManageArticles);
