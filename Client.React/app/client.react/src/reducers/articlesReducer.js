
import { SET_ARTICLES, SET_ARTICLE, ARTICLE_DELETED, ARTICLE_ADDED, ARTICLE_UPDATED } from '../actions/articles';

export default function articlesReducer(state = [], action = {}){
    
    switch(action.type){
 
        case SET_ARTICLES: 
            return { ...state, articles: action.payload };

        case SET_ARTICLE:  
            return { ...state, article: action.payload };
 
        case ARTICLE_DELETED: 
            return { ...state, articles: state.articles.filter(item => item.id !== action.payload) };
 
        case ARTICLE_ADDED: 
            return { ...state, articles: (state.articles || []).concat([action.payload]) };

        case ARTICLE_UPDATED:
            
        default:
            return state;        
    } 
}