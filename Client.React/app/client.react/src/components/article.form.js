import React from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { fetchArticle, updateArticle, saveArticle } from '../actions/articles';

class ArticleForm extends React.Component {

    state = {
        id: this.props.article ? this.props.article.id : null,
        categoryId: this.props.article ? this.props.article.categoryId : null,
        category: this.props.article ? this.props.article.category : '',
        title: this.props.article ? this.props.article.title : '',
        abstract: this.props.article ? this.props.article.abstract : '',
        body: this.props.article ? this.props.article.body : '',
        city: this.props.article ? this.props.article.city : '',
        country: this.props.article ? this.props.article.country : '',
        releaseDate: this.props.article ? this.props.article.releaseDate : '',
        expireDate: this.props.article ? this.props.article.expireDate : '',
        approved: this.props.article ? this.props.article.approved : '',
        listed: this.props.article ? this.props.article.listed : '',
        commentsEnabled: this.props.article ? this.props.article.commentsEnabled : '',
        onlyForMembers: this.props.article ? this.props.article.onlyForMembers : '',

        redirect: false,
        errors: {}        
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            id: nextProps.article.id,
            categoryId: nextProps.article.categoryId,
            category: nextProps.article.category,
            title: nextProps.article.title,
            abstract: nextProps.article.abstract,
            body: nextProps.article.body,
            city: nextProps.article.city,
            country: nextProps.article.country,
            releaseDate: nextProps.article.releaseDate,
            expireDate: nextProps.article.expireDate,
            approved: nextProps.article.approved,
            listed: nextProps.article.listed,
            commentsEnabled: nextProps.article.commentsEnabled,
            onlyForMembers: nextProps.article.onlyForMembers
        });
    }

    componentDidMount = () => {  
       
        if (this.props.match.params.id) {
            this.props.fetchArticle(this.props.match.params.id);
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

        if (!this.state.category) 
            errors.category = "Category can't be empty";

        if (!this.state.title) 
            errors.title = "Title can't be empty";

        if (!this.state.abstract) 
            errors.abstract = "Abstract сan't be empty";

        if (!this.state.body) 
            errors.body = "Body can't be empty";

        if (!this.state.city) 
            errors.city = "City can't be empty";

        if (!this.state.country) 
            errors.country = "Country can't be empty";

        this.setState({ errors });

        const isValid = Object.keys(errors).length === 0;        
        if (isValid) {
            
            const { id, category, title, abstract, body, city, country } = this.state;
            if(id) {
                this.props.updateArticle({ id, category, title, abstract, body, city, country })
                    .then(
                        () =>{ this.setState({ redirect: true })},
                        (err) => err.response.json()
                                    .then(({errors}) => this.setState({ errors }))
                    );
            }
            else
            {
                this.props.saveArticle({ category, title, abstract, body, city, country })
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
            <form onSubmit = {this.handleSubmit} >

                <div className="text-danger">{this.state.errors.category}</div>
                <div className="form-group">
                    <label className="control-label">Category</label>
                    <input name="category" 
                           type="text" 
                           className="form-control" 
                           value={this.state.category} 
                           onChange={this.handleChange}  />  
                </div>

                <div className="text-danger">{this.state.errors.title}</div>
                <div className="form-group">
                    <label className="control-label">Title</label>
                    <input name="title" 
                           type="text" 
                           className="form-control" 
                           value={this.state.title} 
                           onChange={this.handleChange}  />  
                </div>

                <div className="text-danger">{this.state.errors.abstract}</div>
                <div className="form-group">
                    <label className="control-label">Abstract</label>
                    <input name="abstract" 
                           type="text" 
                           className="form-control" 
                           value={this.state.abstract} 
                           onChange={this.handleChange} />  
                </div>

                <div className="text-danger">{this.state.errors.body}</div>
                <div className="form-group">
                    <label className="control-label">Body</label>
                    <input name="body" 
                           type="text" 
                           className="form-control" 
                           value={this.state.body} 
                           onChange={this.handleChange} />  
                </div>

                <div className="text-danger">{this.state.errors.city}</div>
                <div className="form-group">
                    <label className="control-label">City</label>
                    <input name="city" 
                           type="text" 
                           className="form-control" 
                           value={this.state.city} 
                           onChange={this.handleChange} />  
                </div>

                <div className="text-danger">{this.state.errors.country}</div>
                <div className="form-group">
                    <label className="control-label">Country</label>
                    <input name="country" 
                           type="text" 
                           className="form-control" 
                           value={this.state.country} 
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
            article: state.articlesReducer.article
        }
    }
    return { article: {} };
}

export default connect(mapStateToProps, { fetchArticle, updateArticle, saveArticle })(ArticleForm);