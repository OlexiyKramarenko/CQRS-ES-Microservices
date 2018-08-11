// import { handleResponse } from './base';

export const SERVICE_BASE = "http://localhost:64510";

export const ARTICLES_FETCHED = "ARTICLES_FETCHED";
export function articlesFetched(articles) {
    return {
        type: ARTICLES_FETCHED,
        payload: articles
    }
}
export function browseArticles(categoryId) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/BrowseArticles/${categoryId}`)
            .then(res => res.json())  
            .then(json => dispatch(articlesFetched(json)));
    }
}
export function manageArticles(categoryId) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/ManageArticles/${categoryId}`)
            .then(res => res.json())
            .then(json => dispatch(articlesFetched(json)));
    }
}



export const ARTICLE_FETCHED = "ARTICLE_FETCHED";
export function articleFetched(article) {
    return {
        type: ARTICLE_FETCHED,
        payload: article
    }
}
export function showArticle(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/ShowArticle/${id}`)
            .then(res => res.json())  
            .then(json => dispatch(articleFetched(json)));
    }
}
export function editArticle(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/EditArticle/${id}`)
            .then(res => res.json()) //конвертированть в json обьект
            .then(json => dispatch(articleFetched(json)));
    }
}

export const ARTICLE_UPDATED = "ARTICLE_UPDATED";
export function articleUpdated(article) {
    
    return {
        type: ARTICLE_UPDATED,
        payload: article
    }
}

export function handleResponse(response) {
    
    if (response.ok) {
        return response.json();
    }
    else {
        let error = new Error(response.statusText);
        error.response = response;
        throw error;
    }
}
export function updateArticle(article) {
    console.log("__article");
    console.log(article);
    return dispatch => {
        return fetch(`${SERVICE_BASE}/api/ManageArticles/UpdateArticle/${article.id}`, {
            method: 'PUT',          
            body: JSON.stringify(article),
            headers: {
                "Content-Type": "application/json"
              }
        })
        .then(handleResponse)
        .then(data => dispatch(articleUpdated(data)));
    }
}

 

export const CATEGORY_FETCHED = "CATEGORY_FETCHED";
export function categoryFetched(category) {
    return {
        type: CATEGORY_FETCHED,
        payload: category
    }
} 
export function editCategory(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/EditCategory/${id}`)
            .then(res => res.json()) //конвертированть в json обьект
            .then(json => dispatch(categoryFetched(json)));
    }
}

export const CATEGORY_UPDATED = "CATEGORY_UPDATED";
export function categoryUpdated(category) {
    return {
        type: CATEGORY_UPDATED,
        payload: category
    }
}
export function updateCategory(category) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/EditCategory/${category.id}`, {
           
            method: 'put',
            body: JSON.stringify(category),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(categoryUpdated(data)));
    }
}



export const COMMENT_FETCHED = "COMMENT_FETCHED";
export function commentFetched(comment) {
    return {
        type: COMMENT_FETCHED,
        payload: comment
    }
} 
export function editComment(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/EditComment/${id}`)
            .then(res => res.json()) //конвертированть в json обьект
            .then(json => dispatch(commentFetched(json)));
    }
}

export const COMMENT_UPDATED = "COMMENT_UPDATED";
export function commentUpdated(comment) {
    return {
        type: COMMENT_UPDATED,
        payload: comment
    }
}
export function updateComment(comment) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/EditComment/${comment.id}`, {
            
            method: 'put',
            body: JSON.stringify(comment),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(commentUpdated(data.comment)));
    }
}



export const CATEGORIES_FETCHED = "CATEGORIES_FETCHED";
export function categoriesFetched(categories) {   
    return {
        type: CATEGORIES_FETCHED,
        payload: categories
    }
}
export function showCategories() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/ShowCategories`)
            .then(res => res.json())  
            .then(json => dispatch(categoriesFetched(json)));
    }
}
export function manageCategories() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/ManageCategories`)
            .then(res => res.json()) 
            .then(json => dispatch(categoriesFetched(json)));        
    }
}


export const COMMENT_ADDED = "COMMENT_ADDED";
export function commentAdded(comment) {
    return {
        type: COMMENT_ADDED,
        payload: comment
    }
}
export function leaveComment(comment) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/LeaveComment`, {
            method: 'post',
            body: JSON.stringify(comment),
            headers: {
                "Content-Type": "application/json"
            }
        }) 
            .then(handleResponse) 
            .then(data => dispatch(commentAdded(data.comment)));
    }
}




export const ARTICLE_DELETED = "ARTICLE_DELETED";
export function articleDeleted(articleId) {
    return {
        type: ARTICLE_DELETED,
        payload: articleId
    }
}
export function deleteArticle(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/DeleteArticle/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(articleDeleted(id)));
    }
}


export const ARTICLE_ADDED = "ARTICLE_ADDED";
export function articleAdded(article) {
    return {
        type: ARTICLE_ADDED,
        payload: article
    }
}
export function addArticle(article) {
    return dispatch => {
        return fetch(SERVICE_BASE + `/api/managearticles/AddArticle`, {
            method: 'post',
            body: JSON.stringify(article),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(articleAdded(data.article)));
    }
}


export const CATEGORY_DELETED = "CATEGORY_DELETED";
export function categoryDeleted(categoryId) {
    return {
        type: CATEGORY_DELETED,
        payload: categoryId
    }
}
export function deleteCategory(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/DeleteCategory/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(categoryDeleted(id)));
    }
}


export const CATEGORY_ADDED = "CATEGORY_ADDED";
export function categoryAdded(category) {
    return {
        type: CATEGORY_ADDED,
        payload: category
    }
}
export function addCategory(category) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/AddCategory`, {
            method: 'post',
            body: JSON.stringify(category),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(categoryAdded(data.category)));
    }
}




export const COMMENTS_FETCHED = "COMMENTS_FETCHED";
export function commentsFetched(comments) {
    return {
        type: COMMENTS_FETCHED,
        payload: comments
    }
}
export function manageComments(articleId) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/ManageComments/${articleId}`)
            .then(res => res.json())
            .then(json => dispatch(commentsFetched(json)));
    }
}


export const COMMENT_DELETED = "COMMENT_DELETED";
export function commentDeleted(commentId) {
    return {
        type: COMMENT_DELETED,
        payload: commentId
    }
}
export function deleteComment(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/managearticles/DeleteComment/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(commentDeleted(data.id)));
    }
}






