import React from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { fetchCategory, updateCategory, saveCategory } from '../actions/categories';

class CategoryForm extends React.Component {

    state = {
        id: this.props.category ? this.props.category.id : null,
        title: this.props.category ? this.props.category.title : '',
        importance: this.props.category ? this.props.category.importance : '',
        description: this.props.category ? this.props.category.description : '',

        redirect: false,
        errors: {}        
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            id: nextProps.category ? nextProps.category.id : null,
            title: nextProps.category ? nextProps.category.title : '',
            importance: nextProps.category ? nextProps.category.importance : '',
            description: nextProps.category ? nextProps.category.description : ''
        });
    }

    componentDidMount = () => {  
       
        if (this.props.match.params.id) {
            this.props.fetchCategory(this.props.match.params.id);
        }
    }

    handleChange = (e) => {
 
        let inputFieldName = e.target.name;
        let inputFieldValue = e.target.value;
     
        if (!!this.state.errors[inputFieldName]) {
     
          let errors = Object.assign({}, this.state.errors);
     
          delete errors[inputFieldName];
     
          this.setState({ [inputFieldName]: inputFieldValue, errors });
    
        } else {
    
          this.setState({ [inputFieldName]: inputFieldValue }); 
        }
    }

    handleSubmit = (e) => {
        e.preventDefault();

        // validation
        let errors = {};

        if (!this.state.title) 
            errors.title = "Title can't be empty";

        if (!this.state.importance) 
            errors.importance = "Importance сan't be empty";

        if (!this.state.description) 
            errors.description = "Description  can't be empty";

        this.setState({ errors });

        const isValid = Object.keys(errors).length === 0;        
        if (isValid) {
            
            const { id, title, importance, description } = this.state;
            if(id) {
                this.props.updateCategory({ id, title, importance, description })
                    .then(
                        () =>{ this.setState({ redirect: true })},
                        (err) => err.response.json()
                                    .then(({errors}) => this.setState({ errors }))
                    );
            }
            else
            {
                this.props.saveCategory({ title, importance, description })
                    .then(
                        () =>{ this.setState({ redirect: true })},
                        (err) => err.response.json()
                                    .then(({errors}) => this.setState({ errors }))
                    );
            }
        }
    }

    render() {
        
        const redirect = <Redirect to={`/manage_categories`} />

        const form = (
            <form onSubmit={this.handleSubmit} >

                <div className="text-danger">{this.state.errors.title}</div>
                <div className="form-group">
                    <label className="control-label">Title</label>
                    <input name="title" 
                           type="text" 
                           className="form-control" 
                           value={this.state.title} 
                           onChange={this.handleChange}  />  
                </div>

                <div className="text-danger">{this.state.errors.importance}</div>
                <div className="form-group">
                    <label className="control-label">Importance</label>
                    <input name="importance" 
                           type="text" 
                           className="form-control" 
                           value={this.state.importance} 
                           onChange={this.handleChange} />  
                </div>

                <div className="text-danger">{this.state.errors.description}</div>
                <div className="form-group">
                    <label className="control-label">Description</label>
                    <input name="description" 
                           type="text" 
                           className="form-control" 
                           value={this.state.description} 
                           onChange={this.handleChange} /> 
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

    if (props.match.params.id) {
        return {
            category: state.categoriesReducer.category
        }
    }
    return { category: {} };
}

export default connect(mapStateToProps, { fetchCategory, updateCategory, saveCategory })(CategoryForm);