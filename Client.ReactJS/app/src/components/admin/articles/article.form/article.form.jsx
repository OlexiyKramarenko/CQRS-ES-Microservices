import React from 'react';
import PropTypes from 'prop-types';
import { Redirect } from 'react-router-dom';
import { editArticle, updateArticle, addArticle } from '../../../../actions/articles';
import { connect } from 'react-redux';

class ArticleForm extends React.Component {

//1
    componentDidMount = () => {
        const articleId = this.props.match.params.id;         
        if (articleId) {
            this.props.editArticle(articleId);
        }
    }

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
        errors: {},
        loading: false,
        redirect: false
    }
//2
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

    
//4
    saveArticle = ({
        id, categoryId,category, title, abstract, body,
        city, country, releaseDate, expireDate,
        approved, listed, commentsEnabled, onlyForMembers }) => {

        const articleId = this.props.match.params.id;
        
        if (articleId) {            
            console.log("id___:"+id);
            return this.props.updateArticle({
                id, 
                categoryId, category, title, abstract, body,
                city, country, releaseDate, expireDate,
                approved, listed, commentsEnabled, onlyForMembers
 
            }).then(() => { this.setState({ redirect: true }); });
            

        } else {
            return this.props.addArticle({
                categoryId, category, title, abstract, body,
                city, country, releaseDate, expireDate,
                approved, listed, commentsEnabled, onlyForMembers

            }).then(() => { this.setState({ redirect: true }); });
        }
    }

    //3
    handleSubmit = (e) => {
        e.preventDefault();
       
        // validation
        let errors = {};

        if (this.state.title === '') errors.title = "Title can't be empty";
        if (this.state.category === '') errors.category = "Сategory сan't be empty";
        if (this.state.abstract === '') errors.abstract = "Abstract  can't be empty";
        if (this.state.body === '') errors.body = "Body  can't be empty";
        if (this.state.city === '') errors.city = "City  can't be empty";
        if (this.state.country === '') errors.country = "Country  can't be empty";
        if (this.state.releaseDate === '') errors.releaseDate = "Release Date  can't be empty";
        if (this.state.expireDate === '') errors.expireDate = "Expire Date  can't be empty";
        if (this.state.approved === '') errors.approved = "Approved  can't be empty";
        if (this.state.listed === '') errors.listed = "'Listed'  can't be empty";
        if (this.state.commentsEnabled === '') errors.commentsEnabled = "'Comments Enabled'  can't be empty";
        if (this.state.onlyForMembers === '') errors.onlyForMembers = "'OnlyForMembers'  can't be empty";

        this.setState({ errors });
        const isValid = Object.keys(errors).length === 0
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if (!isValid) {

            const {
                id, categoryId, category, title, abstract, body,
                city, country, releaseDate, expireDate,
                approved, listed, commentsEnabled, onlyForMembers
            } = this.state;

            this.setState({ loading: true });

            this.saveArticle({
                id, categoryId, category, title, abstract, body,
                city, country, releaseDate, expireDate,
                approved, listed, commentsEnabled, onlyForMembers
            })
            .catch((err) =>err.response
                              .json()
                              .then(({ errors }) => this.setState({ errors, loading: false }))
            );
        }
    }

    render() {


        //const redirect = <Redirect to={`/manage_categories`} />
        console.log("__state");
        console.log(this.state);
        const redirect = <Redirect to={`/manage_articles/${this.state.categoryId}`} />
        const form = (
            <form onSubmit={this.handleSubmit}>
                <div className="text-danger"></div>
                <div className="form-group">
                    <input type="hidden" />
                </div>
                <div className="form-group">
                    <input type="hidden" />
                </div>
                <div className="form-group">
                    <label className="control-label">Category</label>
                    <input type="text" className="form-control" defaultValue={this.state.category} />
                </div>
                <div className="form-group">
                    <label className="control-label">Title</label>
                    <input type="text" className="form-control" defaultValue={this.state.title} />
                </div>
                <div className="form-group">
                    <label className="control-label">Abstract</label>
                    <input type="number" className="form-control" defaultValue={this.state.abstract} />
                </div>
                <div className="form-group">
                    <label className="control-label">Body</label>
                    <input type="text" name="body" className="form-control" defaultValue={this.state.body} value={this.state.body} onChange={e => this.setState({ body: e.target.value })} />
                </div>
                <div className="form-group">
                    <label className="control-label">City</label>
                    <input type="number" className="form-control" defaultValue={this.state.city} />
                </div>
                <div className="form-group">
                    <label className="control-label">Country</label>
                    <input type="text" className="form-control" defaultValue={this.state.country} />
                </div>
                <div className="form-group">
                    <label className="control-label">ReleaseDate</label>
                    <input type="text" className="datepicker form-control" defaultValue={this.state.releaseDate} />
                </div>
                <div className="form-group">
                    <label className="control-label">ExpireDate</label>
                    <input type="text" className="datepicker form-control" defaultValue={this.state.expireDate} />
                </div>
                <div className="form-group">
                    <label className="control-label">Approved</label>
                    {/* @Html.CheckBoxFor(m => m.Approved, new { @className = "form-control" }) */}
                </div>
                <div className="form-group">
                    <label className="control-label">Listed</label>
                    {/* @Html.CheckBoxFor(m => m.Listed, new { @className = "form-control" }) */}
                </div>
                <div className="form-group">
                    <label className="control-label">CommentsEnabled</label>
                    {/* @Html.CheckBoxFor(m => m.CommentsEnabled, new { @className = "form-control" }) */}
                </div>
                <div className="form-group">
                    <label className="control-label">OnlyForMembers</label>
                    {/* @Html.CheckBoxFor(m => m.OnlyForMembers, new { @className = "form-control" }) */}
                </div>
                <div className="form-group">
                    <input type="submit" value="Update" className="btn btn-default" value="Save" />
                </div>
            </form>
        );

        return this.state.redirect ? redirect : form;
    }
}

// ArticleForm.propTypes = {
//     category: PropTypes.element.isRequired,
//     title: PropTypes.element.isRequired,
//     abstract: PropTypes.element.isRequired,
//     body: PropTypes.element.isRequired,
//     city: PropTypes.element.isRequired,
//     country: PropTypes.element.isRequired,
//     approved: PropTypes.element.isRequired,
//     listed: PropTypes.element.isRequired,
//     commentsEnabled: PropTypes.element.isRequired,
//     onlyForMembers: PropTypes.element.isRequired
// };

//0
function mapStateToProps(_state, props) {
    
    const id = props.match.params.id;

    if (id) { 

        // const article = (state.articles.length > 0) ? 
        //                  state.articles.find(item => item.id === id) : 
        //                  null; 

        let article ;//= state.articles.find(item => item.id === id);

        for(var i = 0; i < _state.articles.length; i++){
            if(_state.articles[i].id===id){
                article = _state.articles[i];
                return;
            }
        }
        return {       
            article
        };
    }
    return { article: null
        //{id:"AAA", body:"sss"} 
    };
}

export default connect(mapStateToProps, { editArticle, updateArticle, addArticle })(ArticleForm);