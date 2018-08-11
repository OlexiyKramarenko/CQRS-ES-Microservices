import React from 'react'; 
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { editComment, updateComment, leaveComment } from '../../../../actions/articles';

class CommentForm extends React.Component {

    state = {
        _id: this.props.comment ? this.props.comment._id : null,
        articleId: this.props.comment ? this.props.comment.articleId : '',
        addedDate: this.props.comment ? this.props.comment.addedDate : '',
        userIp: this.props.comment ? this.props.comment.userIp : '',
        addedBy: this.props.comment ? this.props.comment.addedBy : '',
        comment: this.props.comment ? this.props.comment.comment : '',
        errors: {},
        loading: false,
        redirect: false
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            _id: nextProps.comment._id,
            addedDate: nextProps.comment.addedDate,
            addedBy: nextProps.comment.addedBy,
            userIp: nextProps.comment.userIp,
            comment: nextProps.comment.comment
        });
    }

    componentDidMount = () => {
        const { match } = this.props;
        if (match.params._id) {
            this.props.editComment(match.params._id);
        }
    }

    saveComment = ({ _id, addedDate, userIp, addedBy, comment }) => {

        if (_id) {

            return this.props.updateComment({ _id, addedDate, userIp, addedBy, comment })
                .then(() => { this.setState({ redirect: true }) }, );

        } else {

            return this.props.leaveComment({ addedDate, userIp, addedBy, comment })
                .then(() => { this.setState({ redirect: true }) }, );
        }
    }

    handleSubmit = (e) => {
        e.preventDefault();

        // validation
        let errors = {};

        if (this.state.comment === '') errors.comment = "Cmment  can't be empty";

        this.setState({ errors });
        const isValid = Object.keys(errors).length === 0

        if (isValid) {

            const { _id, addedDate, userIp, addedBy, comment } = this.state;

            this.setState({ loading: true });

            this.saveComment({ _id, addedDate, userIp, addedBy, comment })
                .catch((err) => err.response.json()
                    .then(({ errors }) => this.setState({ errors, loading: false })));
        }
    }

    render() {

        const redirect = <Redirect to={`/manage_comments/${this.state.articleId}`} />

        const form = (
            <form onSubmit={this.handleSubmit}  >
                <div className="text-danger"></div>
                <div className="form-group">
                    <input type="hidden" />
                </div>
                <div className="form-group">
                    <label className="control-label">Added Date</label>
                    <input type="text" className="form-control" value={this.state.addedDate} />
                </div>
                <div className="form-group">
                    <label className="control-label">User Ip</label>
                    <input type="text" className="form-control" value={this.state.userIp} />
                </div>
                <div className="form-group">
                    <label className="control-label">Added By</label>
                    <input type="text" className="form-control" value={this.state.addedBy} />
                </div>
                <div className="form-group">
                    <label className="control-label">Comment</label>
                    <input type="text" className="form-control" value={this.state.comment} />
                </div>
                <div className="form-group">
                    <input type="submit" value="Save" className="btn btn-default" />
                </div>
            </form>
        );

        return this.state.redirect ? redirect : form;
    }
}
 

function mapStateToProps(state, props) {
    const { match } = props;
    if (match.params._id) {
        return {
            comment: state.articles.comments.find(item => item._id === match.params._id)
        }
    }

    return { comment: null };
}

export default connect(mapStateToProps, { editComment, updateComment, leaveComment })(CommentForm);