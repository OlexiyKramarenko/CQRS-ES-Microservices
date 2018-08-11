import {
    ARTICLES_FETCHED,
    ARTICLE_FETCHED,
    CATEGORY_FETCHED,
    COMMENT_FETCHED,
    COMMENT_ADDED,
    CATEGORIES_FETCHED,
    ARTICLE_UPDATED,
    ARTICLE_DELETED,
    ARTICLE_ADDED,
    CATEGORY_DELETED,
    CATEGORY_ADDED,
    CATEGORY_UPDATED,
    COMMENTS_FETCHED,
    COMMENT_DELETED,
    COMMENT_UPDATED
} from "../actions/articles";

export default function articles(state = [], action = {}) {

    switch (action.type) { 

        case ARTICLE_FETCHED:
            return { ...state, article : action.payload };

        case CATEGORY_FETCHED:
            return { ...state, category : action.payload };

        case COMMENT_FETCHED:
            return { ...state, comment : action.payload };

        case ARTICLES_FETCHED:
            return { ...state, articles : action.payload };

        case COMMENTS_FETCHED:
            return { ...state, comments : action.payload };

        case CATEGORIES_FETCHED: 
            return { ...state, categories : action.payload };

            // const index = state.findIndex(item => item._id == action.payload.id);            
            // if(index > -1) {
            //     return state.map(item => {
            //         if(item._id === action.payload.id)
            //             return item;
            //     });
            // }
            // else {
            //     return { ...state, payload : action.payload };
            // } 
           
        case COMMENT_ADDED:
        case ARTICLE_ADDED:
            return {...state, article : action.payload};

        case CATEGORY_ADDED:
            return {...state, payload : action.payload};

        case ARTICLE_UPDATED:  
            debugger;
            return state.articles.map(item => {
                if(item.id === action.payload.id)
                    return item;
            });    

        case CATEGORY_UPDATED:
        case COMMENT_UPDATED:


        case ARTICLE_DELETED:
        case CATEGORY_DELETED:
        case COMMENT_DELETED:
            return state.filter(item => item.id !== action.payload)

        default:
            return state;
    }
}
