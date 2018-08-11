import React from 'react';
import PropTypes from 'prop-types';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { editCategory, updateCategory, addCategory } from '../../../../actions/articles';

class CategoryForm extends React.Component {

    state = {
        _id: this.props.category ? this.props.category._id : null,
        title: this.props.category ? this.props.category.title : '',
        importance: this.props.category ? this.props.category.importance : '',
        description: this.props.category ? this.props.category.description : '',
        errors: {},
        loading: false,
        redirect: false
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            _id: nextProps.category._id,
            title: nextProps.category.title,
            importance: nextProps.category.importance,
            description: nextProps.category.description
        });
    }

    componentDidMount = () => {
        const { match } = this.props;
        if (match.params._id) {
            this.props.editCategory(match.params._id);
        }
    }

    saveCategory = ({ _id, title, importance, description }) => {

        if (_id) {

            return this.props.updateCategory({ _id, title, importance, description })
                .then(() => { this.setState({ redirect: true }) }, );

        } else {

            return this.props.addCategory({ title, importance, description })
                .then(() => { this.setState({ redirect: true }) }, );
        }
    }

    handleSubmit = (e) => {
        e.preventDefault();

        // validation
        let errors = {};

        if (this.state.title === '') errors.title = "Title can't be empty";
        if (this.state.importance === '') errors.importance = "Importance сan't be empty";
        if (this.state.description === '') errors.description = "Description  can't be empty";

        this.setState({ errors });
        const isValid = Object.keys(errors).length === 0

        if (isValid) {

            const { _id, title, importance, description } = this.state;

            this.setState({ loading: true });

            this.saveCategory({ _id, title, importance, description })
                .catch((err) => err.response.json()
                .then(({ errors }) => this.setState({ errors, loading: false })));
        }
    }

    render() {

        const redirect = <Redirect to={`/manage_categories`} />

        const form = (
            <form onSubmit={this.handleSubmit} >
                <div className="text-danger"></div>
                <div className="form-group">
                    <input type="hidden" />
                </div>
                <div className="form-group">
                    <label className="control-label">Title</label>
                    <input type="text" className="form-control" value={this.state.title} />
                </div>
                <div className="form-group">
                    <label className="control-label">Importance</label>
                    <input type="text" className="form-control" value={this.state.importance} />
                </div>
                <div className="form-group">
                    <label className="control-label">Description</label>
                    <input type="text" className="form-control" value={this.state.description} />
                </div>

                <div className="form-group">
                    <input type="submit" value="Save" className="btn btn-default" />
                </div>
            </form>
        );

        return this.state.redirect ? redirect : form;
    }
}

CategoryForm.propTypes = {
    title: PropTypes.element.isRequired,
    importance: PropTypes.element.isRequired,
    description: PropTypes.element.isRequired
};


function mapStateToProps(state, props) {
    const { match } = props;
    if (match.params._id) {
        return {
            category: state.articles.categories.find(item => item._id === match.params._id)
        }
    }

    return { category: null };
}

export default connect(mapStateToProps, { editCategory, updateCategory, addCategory })(CategoryForm);