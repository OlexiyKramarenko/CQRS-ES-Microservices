import React from 'react';
import { connect } from 'react-redux';
import { fetchArticle } from  '../actions/articles';
import { saveComment } from  '../actions/comments';
import { Redirect } from 'react-router-dom';

class ArticleInfo extends React.Component {
        
    state = {         
        articleId: this.props.article ? this.props.article.id : null,
        name: '',
        email: '',
        body: '',

        errors: {},
        redirect: false 
    }

    componentDidMount() {       
        const articleId = this.props.match.params.id; 
        this.props.fetchArticle(articleId);     
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
    
        if (this.state.name === '') {
          errors.name = "Name can't be empty";
        }
    
        if (this.state.email === '') {
          errors.email = "Email can't be empty";
        }          
    
        if (this.state.body === '') {
            errors.body = "Body can't be empty";
        }   
 
        this.setState({ errors });
    
        const isValid = Object.keys(errors).length === 0
        if (isValid) {
            
          const { name, email, body } = this.state;
    
          const articleId = this.props.article.id;

          this.props.saveComment({ name, email, body, articleId })
          .then(
            () =>{ this.setState({ redirect : true })},
            (err) => err.response.json().then(({errors}) => this.setState({ errors }))
          );    
        }    
    }

    render() { 

        const redirect = <Redirect to={`/categories`} />

        const form = (  
            <div id="order-summary">
                <h3>{this.props.article.title}</h3>
                <p>{this.props.article.body}</p>               
                <br />
                <h3>Post your comment</h3> 
                 
                <form onSubmit = { this.handleSubmit }>

                    <div className="text-danger">{this.state.errors.name}</div>
                    <div className="form-group">
                        <label className="control-label">Name:</label> 
                        <input name="name" 
                               type="text" 
                               value={this.state.name} 
                               className="form-control" 
                               onChange={this.handleChange} /> 
                    </div>

                    <div className="text-danger">{this.state.errors.email}</div>
                    <div className="form-group">
                        <label className="control-label">Email:</label>
                        <input name="email" 
                               type="text" 
                               value={this.state.email}  
                               className="form-control" 
                               onChange={this.handleChange} /> 
                    </div>

                    <div className="text-danger">{this.state.errors.body}</div>
                    <div className="form-group">
                        <label className="control-label">Body:</label>
                        <input name="body" 
                               type="text" 
                               value={this.state.body}  
                               className="form-control" 
                               onChange={this.handleChange} />
                    </div>

                    <div className="form-group">
                        <input type="submit" value="Create" className="btn btn-default" />
                    </div>

                </form>
            </div>
        );

        return this.state.redirect ? redirect : form; 
    }
}


function mapStateToProps(state) {  
    return {
        article : state.articlesReducer.article ?
                  state.articlesReducer.article :
                  {}
    }
}

export default connect(mapStateToProps, { fetchArticle, saveComment } )(ArticleInfo); 



