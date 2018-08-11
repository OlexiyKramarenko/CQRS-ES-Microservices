import React from 'react';
import PropTypes from 'prop-types';
import { Redirect } from 'react-router-dom';
import { editDepartment, updateDepartment, addDepartment } from '../../../../actions/store';
import { connect } from 'react-redux';

class DepartmentForm extends React.Component {

    state = {
        _id: this.props.department ? this.props.department._id : null,
        addedBy: this.props.department ? this.props.department.addedBy : '',
        addedDate: this.props.department ? this.props.department.addedDate : '',
        title: this.props.department ? this.props.department.title : '',
        importance: this.props.department ? this.props.department.importance : '',
        description: this.props.department ? this.props.department.description : '',
        errors: {},
        loading: false,
        redirect: false
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            _id: nextProps.department._id,
            addedBy: nextProps.department.addedBy,
            addedDate: nextProps.department.addedDate,
            title: nextProps.department.title,
            importance: nextProps.department.importance,
            description: nextProps.department.description
        });
    }

    componentDidMount = () => {
        const { match } = this.props;
        if (match.params._id) {
            this.props.editDepartment(match.params._id);
        }
    }
    handleSubmit = (e) => {
        e.preventDefault();

        // validation
        let errors = {};

        if (this.state.addedBy === '') errors.addedBy = "'AddedBy' field can't be empty";
        if (this.state.addedDate === '') errors.addedDate = "'Added Date' field сan't be empty";
        if (this.state.title === '') errors.title = "'Title' can't be empty";
        if (this.state.importance === '') errors.importance = "'Importance'  can't be empty";
        if (this.state.description === '') errors.description = "'Description'  can't be empty";

        this.setState({ errors });
        const isValid = Object.keys(errors).length === 0

        if (isValid) {

            const {
                _id, addedBy, addedDate, title, importance, description
            } = this.state;

            this.setState({ loading: true });

            this.saveDepartment({
                _id, addedBy, addedDate, title, importance, description
            })
                .catch((err) => err.response.json()
                    .then(({ errors }) => this.setState({ errors, loading: false })));
        }
    }
    saveDepartment = ({
        _id, addedBy, addedDate, title, importance, description }) => {

        if (_id) {

            return this.props.updateDepartment({
                _id, addedBy, addedDate, title, importance, description
            })
                .then(() => { this.setState({ redirect: true }) }, );

        } else {

            return this.props.addDepartment({
                addedBy, addedDate, title, importance, description
            })
                .then(() => { this.setState({ redirect: true }) }, );
        }
    }

    render() {

        const redirect = <Redirect to={`/manage_departments`} />

        const form = (
            <form onSubmit={this.handleSubmit}>

                <div className="form-group">
                    <label className="control-label">AddedBy</label>
                    <input
                        type="text"
                        className="form-control"
                        value={this.state.addedBy} />
                </div>
                <div className="form-group">
                    <label className="control-label">AddedDate</label>
                    <input
                        type="text"
                        className="form-control"
                        value={this.state.addedDate} />
                </div>
                <div className="form-group">
                    <label className="control-label">Title</label>
                    <input
                        type="text"
                        className="form-control"
                        value={this.state.title} />
                </div>
                <div className="form-group">
                    <label className="control-label">Importance</label>
                    <input
                        type="text"
                        className="form-control"
                        value={this.state.importance} />
                </div>
                <div className="form-group">
                    <label className="control-label">Description</label>
                    <input
                        type="text"
                        className="form-control"
                        value={this.state.description} />
                </div>
                <div className="form-group">
                    <input
                        type="submit"
                        value="Update"
                        className="btn btn-default" />
                </div>
            </form>
        );

        return this.state.redirect ? redirect : form;
    }
}


DepartmentForm.propTypes = {
    addedBy: PropTypes.element.isRequired,
    title: PropTypes.element.isRequired,
    importance: PropTypes.element.isRequired,
    description: PropTypes.element.isRequired
};

function mapStateToProps(state, props) {
    const { match } = props;
    if (match.params._id) {
        return {
            department: state.departments.find(item => item._id === match.params._id)
        }
    }

    return { department: null };
}

export default connect(mapStateToProps, { editDepartment, updateDepartment, addDepartment })(DepartmentForm);