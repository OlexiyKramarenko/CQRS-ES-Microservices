import React from 'react';
import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';
import { manageComments, deleteComment } from '../../../../actions/articles';
import { connect } from 'react-redux';

class ManageComments extends React.Component {
    
    componentDidMount() {
        this.props.manageComments();
    }

    render() {

        return (
            <table className="list">
                {
                    this.props.comments.map(function (item) {
                        <tr key={item.id}>
                            <td>
                                Комментарий создан <label>{item.addedBy}</label>
                                <br />
                                Email: {item.addedByEmail}  в {item.addedDate}
                                <br />
                                Статья:
					            <NavLink to={`/article_title/${item.id}`}  >{item.articleTitle}</NavLink>
                                <br />
                                {item.body}
                            </td>
                            <td>
                                <NavLink to={`/edit_comment/${item.id}`}>Edit</NavLink>
                            </td>
                            <td>
                                <span onClick={() => this.props.deleteComment(item.id)}>Delete</span>
                            </td>
                        </tr>
                    })
                }
            </table>
        )
    }
}

function mapStateToProps(state) {
    return {
        comments: !state.articles.comments ? [] : state.articles.comments
    }
}

export default connect(mapStateToProps, { manageComments, deleteComment })(ManageComments);
